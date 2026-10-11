using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx.Logging;
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
    [StationeersMod("kreezy.customspeakersounds", "Custom Speaker Sounds", "0.1.1")]
    public class Plugin : ModBehaviour
    {
        static readonly SortedDictionary<int, GameAudioClipsData> clips = new SortedDictionary<int, GameAudioClipsData>();
        static readonly FieldInfo lookup = AccessTools.Field(typeof(Thing), "_audioEventLookup");
        static ManualLogSource log;
        AudioManager registeredManager;
        bool loading;
        float nextCheck;
        static void Info(string message) => log?.LogInfo(message);
        static void Warn(string message) => log?.LogWarning(message);
        static void Error(string message) => log?.LogError(message);
        public override void OnLoaded(ContentHandler contentHandler)
        {
            base.OnLoaded(contentHandler);
            log = BepInEx.Logging.Logger.CreateLogSource("CustomSpeakerSounds");
            try
            {
                new Harmony("kreezy.customspeakersounds").PatchAll(typeof(Plugin).Assembly);
                Info("0.1.1 loaded; waiting for the game's existing initialized AudioManager. No singleton creation. IDs 100..199; sounds/<id>_<name>.<ext>");
            }
            catch (Exception ex) { enabled = false; Error("Patch installation failed: " + ex); }
        }
        void Update()
        {
            if (loading || Time.unscaledTime < nextCheck) return;
            nextCheck = Time.unscaledTime + 0.5f;
            // Singleton.Instance calls Create() in the game; never use it for a readiness check.
            var manager = UnityEngine.Object.FindObjectOfType<AudioManager>();
            if (!IsReady(manager) || manager == registeredManager) return;
            Info("Existing AudioManager is ready; starting custom file loading.");
            loading = true;
            StartCoroutine(Load(manager));
        }
        static bool IsReady(AudioManager manager) => manager != null &&
            manager.AudioSourcePrefab != null && manager.LoadedChannelData != null &&
            manager.LoadedChannelData.Count > 0 && manager.MixerGroups != null && manager.MixerGroups.Count > 0;
        IEnumerator Load(AudioManager manager)
        {
            try { yield return LoadFiles(manager); }
            finally { loading = false; }
        }
        IEnumerator LoadFiles(AudioManager manager)
        {
            string dir = Path.Combine(Path.GetDirectoryName(typeof(Plugin).Assembly.Location), "sounds");
            string[] files;
            try { Directory.CreateDirectory(dir); files = Directory.GetFiles(dir).OrderBy(x => x, StringComparer.Ordinal).ToArray(); }
            catch (Exception ex) { Error("Cannot read sounds folder: " + ex); registeredManager = manager; yield break; }
            clips.Clear();
            var seen = new HashSet<int>();
            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".wav" && ext != ".ogg" && ext != ".mp3") continue;
                string name = Path.GetFileNameWithoutExtension(file);
                string number = name.Split('_')[0];
                if (!int.TryParse(number, out int id) || id < 100 || id > 199 || !seen.Add(id))
                { Warn("[CustomSpeakerSounds] Invalid or duplicate ID: " + Path.GetFileName(file)); continue; }
                using (var req = UnityWebRequestMultimedia.GetAudioClip(new Uri(file).AbsoluteUri,
                    ext == ".wav" ? AudioType.WAV : ext == ".ogg" ? AudioType.OGGVORBIS : AudioType.MPEG))
                {
                    yield return req.SendWebRequest();
                    if (req.result != UnityWebRequest.Result.Success)
                    { Error("[CustomSpeakerSounds] " + req.error); continue; }
                    if (!IsReady(manager)) { Warn("AudioManager disappeared during file loading; registration postponed."); yield break; }
                    AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
                    if (clip == null) continue;
                    clip.name = "KreeZy.CustomSpeaker." + id;
                    var data = new GameAudioClipsData { Name = clip.name, NameHash = Animator.StringToHash(clip.name), ChannelName = "Large", Looping = false, RandomStartTime = false };
                    data.Clips.Add(clip);
                    var audio = new AudioData(); audio.AudioClipsData.Add(data);
                    try
                    {
                        manager.LoadAudioData(new[] { audio });
                        clips.Add(id, data);
                        ExtendModes(id, name.Substring(number.Length).TrimStart('_'), data.NameHash);
                        Info("[CustomSpeakerSounds] Ready: ID " + id + " -> " + Path.GetFileName(file) + " (" + clip.length + " s)");
                    }
                    catch (Exception ex) { Error("[CustomSpeakerSounds] Registration failed: " + ex); }
                }
            }
            registeredManager = manager;
            foreach (Speaker speaker in UnityEngine.Object.FindObjectsOfType<Speaker>()) Attach(speaker);
            Info("[CustomSpeakerSounds] Ready, " + clips.Count + " custom sounds. Restart after editing files.");
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
            catch (Exception ex) { Error("[CustomSpeakerSounds] Speaker attach failed: " + ex); }
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
