using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using StationeersMods.Interface;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using Assets.Scripts.Objects.Motherboards;
using Assets.Scripts.Sound;
using Assets.Scripts.Serialization;

namespace CustomSpeakerSounds
{
    [StationeersMod("kreezy.customspeakersounds", "Custom Speaker Sounds", "0.1.0")]
    public class Plugin : ModBehaviour
    {
        static readonly SortedDictionary<int, GameAudioClipsData> clips = new SortedDictionary<int, GameAudioClipsData>();
        static readonly FieldInfo lookup = AccessTools.Field(typeof(Thing), "_audioEventLookup");
        static bool loading;
        public override void OnLoaded(ContentHandler contentHandler)
        {
            base.OnLoaded(contentHandler);
            new Harmony("kreezy.customspeakersounds").PatchAll(typeof(Plugin).Assembly);
            Debug.Log("[CustomSpeakerSounds] Loaded. Custom SoundAlert IDs: 100..199. WAV/OGG/MP3: sounds/<id>_<name>.<ext>");
        }
        void Update()
        {
            if (loading || AudioManager.Instance == null) return;
            loading = true;
            StartCoroutine(Load());
        }
        IEnumerator Load()
        {
            string dir = Path.Combine(Path.GetDirectoryName(typeof(Plugin).Assembly.Location), "sounds");
            Directory.CreateDirectory(dir);
            var seen = new HashSet<int>();
            foreach (string file in Directory.GetFiles(dir).OrderBy(x => x, StringComparer.Ordinal))
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".wav" && ext != ".ogg" && ext != ".mp3") continue;
                string name = Path.GetFileNameWithoutExtension(file);
                string number = name.Split('_')[0];
                if (!int.TryParse(number, out int id) || id < 100 || id > 199 || !seen.Add(id))
                { Debug.LogWarning("[CustomSpeakerSounds] Invalid or duplicate ID: " + Path.GetFileName(file)); continue; }
                using (var req = UnityWebRequestMultimedia.GetAudioClip(new Uri(file).AbsoluteUri,
                    ext == ".wav" ? AudioType.WAV : ext == ".ogg" ? AudioType.OGGVORBIS : AudioType.MPEG))
                {
                    yield return req.SendWebRequest();
                    if (req.result != UnityWebRequest.Result.Success)
                    { Debug.LogError("[CustomSpeakerSounds] " + req.error); continue; }
                    AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
                    if (clip == null) continue;
                    clip.name = "KreeZy.CustomSpeaker." + id;
                    var data = new GameAudioClipsData { Name = clip.name, NameHash = Animator.StringToHash(clip.name), ChannelName = "Large", Looping = false, RandomStartTime = false };
                    data.Clips.Add(clip);
                    var audio = new AudioData(); audio.AudioClipsData.Add(data);
                    try
                    {
                        AudioManager.Instance.LoadAudioData(new[] { audio });
                        clips.Add(id, data);
                        ExtendModes(id, name.Substring(number.Length).TrimStart('_'), data.NameHash);
                        Debug.Log("[CustomSpeakerSounds] Ready: ID " + id + " -> " + Path.GetFileName(file) + " (" + clip.length + " s)");
                    }
                    catch (Exception ex) { Debug.LogError("[CustomSpeakerSounds] Registration failed: " + ex); }
                }
            }
            foreach (Speaker speaker in UnityEngine.Object.FindObjectsOfType<Speaker>()) Attach(speaker);
            Debug.Log("[CustomSpeakerSounds] Ready, " + clips.Count + " custom sounds. Restart after editing files.");
        }
        static void ExtendModes(int id, string label, int hash)
        {
            var names = Speaker.modeStrings;
            var hashes = Speaker.ModeHashes;
            int old = names.Length;
            if (old <= id)
            {
                Array.Resize(ref names, id + 1); Array.Resize(ref hashes, id + 1);
                for (int i = old; i < names.Length; i++) names[i] = "Unused " + i;
            }
            names[id] = label; hashes[id] = hash;
            AccessTools.Field(typeof(Speaker), "modeStrings").SetValue(null, names);
            AccessTools.Field(typeof(Speaker), "ModeHashes").SetValue(null, hashes);
        }
        static void Attach(Speaker speaker)
        {
            if (speaker == null || clips.Count == 0) return;
            try
            {
                var mode = speaker.InteractMode;
                if (mode == null || mode.AssociatedAudioEvents == null || lookup == null) return;
                var dict = lookup.GetValue(speaker) as Dictionary<int, GameAudioEvent>;
                if (dict == null) return;
                foreach (var pair in clips)
                {
                    var data = pair.Value;
                    if (dict.ContainsKey(data.NameHash)) continue;
                    var ev = new GameAudioEvent { Name = data.Name, NameHash = data.NameHash, Parent = speaker, ClipsData = data, StopIfInvalid = true };
                    ev.Conditions.Add(new SoundEffectCondition { Type = InteractableType.Mode, Value = pair.Key });
                    ev.Conditions.Add(new SoundEffectCondition { Type = InteractableType.OnOff, Value = 1 });
                    ev.Conditions.Add(new SoundEffectCondition { Type = InteractableType.Powered, Value = 1 });
                    mode.AssociatedAudioEvents.Add(ev);
                    if (!ReferenceEquals(mode.AssociatedAudioEvents, speaker.AudioEvents)) speaker.AudioEvents.Add(ev);
                    dict.Add(data.NameHash, ev);
                }
            }
            catch (Exception ex) { Debug.LogError("[CustomSpeakerSounds] Speaker attach failed: " + ex); }
        }
        [HarmonyPatch(typeof(Thing), "Awake")]
        class SpawnPatch { static void Postfix(Thing __instance) { if (__instance is Speaker s) Attach(s); } }
        [HarmonyPatch(typeof(Speaker), "GetContextualName")]
        class NamePatch
        {
            static bool Prefix(Speaker __instance, Interactable interactable, ref string __result)
            {
                if (interactable.Action != InteractableType.Button1 || !clips.ContainsKey(__instance.Mode)) return true;
                __result = Speaker.modeStrings[__instance.Mode]; return false;
            }
        }
        [HarmonyPatch(typeof(Speaker), "SetLogicValue")]
        class SelectPatch
        {
            static bool Prefix(Speaker __instance, LogicType logicType, double value)
            {
                if ((logicType != LogicType.SoundAlert && logicType != LogicType.Mode) ||
                    double.IsNaN(value) || double.IsInfinity(value) || !clips.ContainsKey((int)value)) return true;
                Attach(__instance);
                OnServer.Interact(__instance.InteractMode, (int)value, false);
                return false;
            }
        }
    }
}
