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
using Assets.Scripts.UI;

namespace CustomSpeakerSounds
{
    [StationeersMod("kreezy.customspeakersounds", "Custom SoundAlerts", "0.2.0")]
    public class Plugin : ModBehaviour
    {
        static readonly SortedDictionary<int, GameAudioClipsData> clips = new SortedDictionary<int, GameAudioClipsData>();
        static readonly FieldInfo lookup = AccessTools.Field(typeof(Thing), "_audioEventLookup");
        static ManualLogSource log;
        static readonly SortedDictionary<int, string> labels = new SortedDictionary<int, string>();
        static string[] originalNames;
        static int[] originalHashes;
        static string[] modeNames;
        static readonly HashSet<StationpediaPage> speakerPages = new HashSet<StationpediaPage>();
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
            originalNames = (string[])((string[])AccessTools.Field(typeof(Speaker), "modeStrings").GetValue(null)).Clone();
            originalHashes = (int[])((int[])AccessTools.Field(typeof(Speaker), "ModeHashes").GetValue(null)).Clone();
            try
            {
                new Harmony("kreezy.customspeakersounds").PatchAll(typeof(Plugin).Assembly);
                Info("0.2.0 loaded; waiting for the game's existing initialized AudioManager. No singleton creation. IDs 100..199; sounds/<id>_<name>.<ext>");
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
            clips.Clear(); labels.Clear();
            Info("Scanning sounds folder: " + dir);
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
                    { Error("Failed loading ID " + id + " / " + Path.GetFileName(file) + ": " + req.error); continue; }
                    if (!IsReady(manager)) { Warn("AudioManager disappeared during file loading; registration postponed."); yield break; }
                    AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
                    if (clip == null) { Error("Decoder returned no clip for " + Path.GetFileName(file)); continue; }
                    clip.name = "KreeZy.CustomSpeaker." + id;
                    var data = new GameAudioClipsData { Name = clip.name, NameHash = Animator.StringToHash(clip.name), ChannelName = "Large", Looping = false, RandomStartTime = false, ConcurrencyIds = new List<int>(), SoundAlert = (SoundAlert)id };
                    data.Clips.Add(clip);
                    var audio = new AudioData(); audio.AudioClipsData.Add(data);
                    try
                    {
                        manager.LoadAudioData(new[] { audio });
                        clips.Add(id, data);
                        string label = name.Substring(number.Length).TrimStart('_');
                        labels.Add(id, string.IsNullOrWhiteSpace(label) ? name : label);
                        Info("[CustomSpeakerSounds] Ready: ID " + id + " -> " + Path.GetFileName(file) + " (" + clip.length + " s)");
                    }
                    catch (Exception ex) { Error("Registration failed for ID " + id + " / " + Path.GetFileName(file) + ": " + ex); }
                }
            }
            BuildModes();
            registeredManager = manager;
            foreach (Speaker speaker in UnityEngine.Object.FindObjectsOfType<Speaker>()) Attach(speaker);
            Info("[CustomSpeakerSounds] Ready, " + clips.Count + " custom sounds. Restart after editing files.");
        }
        static void BuildModes()
        {
            // Build one table from all successful loads, rather than resizing readonly statics per file.
            var names = ModeCatalog.BuildNames(originalNames, labels);
            var hashes = (int[])originalHashes.Clone();
            if (labels.Count > 0)
            {
                int length = Math.Max(names.Length, labels.Keys.Max() + 1);
                Array.Resize(ref names, length); Array.Resize(ref hashes, length);
                foreach (var entry in labels) { names[entry.Key] = entry.Value; hashes[entry.Key] = clips[entry.Key].NameHash; }
            }
            modeNames = names;
            AccessTools.Field(typeof(Speaker), "modeStrings").SetValue(null, names);
            AccessTools.Field(typeof(Speaker), "ModeHashes").SetValue(null, hashes);
            foreach (var page in speakerPages) RefreshPage(page);
            RefreshGlobalSoundAlertPage();
            Info("Sound list committed: " + string.Join(", ", labels.Select(x => x.Key + "=" + x.Value)));
        }
        static IEnumerable<KeyValuePair<int, string>> VisibleModes() => ModeCatalog.Visible(originalNames, labels);
        static void RefreshPage(StationpediaPage page)
        {
            page.ModeInsert.Clear();
            foreach (var entry in VisibleModes())
                page.ModeInsert.Add(new StationLogicInsert { LogicAccessTypes = entry.Key.ToString(), LogicName = entry.Value });
        }
        [HarmonyPatch(typeof(Speaker), "get_ModeStrings")]
        class ModesPatch { static void Postfix(ref string[] __result) { if (modeNames != null) __result = modeNames; } }
        [HarmonyPatch(typeof(Stationpedia), "AddLogicModeInfo")]
        class StationpediaModesPatch
        {
            static bool Prefix(Thing __0, ref StationpediaPage __1)
            {
                if (!(__0 is Speaker) || originalNames == null) return true;
                speakerPages.Add(__1);
                RefreshPage(__1);
                return false;
            }
        }
        [HarmonyPatch(typeof(Stationpedia), "AddModeStrings")]
        class StationpediaTextPatch
        {
            static bool Prefix(Thing __0, ref StationpediaPage __1)
            {
                if (!(__0 is Speaker) || originalNames == null) return true;
                if (Stationpedia.ModeStringItem != null)
                    foreach (var entry in VisibleModes())
                        __1.Text += string.Format("\n" + Stationpedia.ModeStringItem.Parsed, entry.Key, entry.Value);
                return false;
            }
        }
        static void RefreshGlobalSoundAlertPage()
        {
            if (Stationpedia.StationpediaPages == null) return;
            foreach (var page in Stationpedia.StationpediaPages.Where(p => p.Key == "LogicType.SoundAlert"))
            {
                page.ModeInsert.RemoveAll(x => int.TryParse(x.LogicAccessTypes, out int id) && id >= 100 && id <= 199);
                foreach (var entry in labels)
                    page.ModeInsert.Add(new StationLogicInsert { LogicAccessTypes = entry.Key.ToString(), LogicName = entry.Value });
            }
        }
        [HarmonyPatch(typeof(Stationpedia), "PopulateLogicVariables")]
        class GlobalListPatch { static void Postfix() => RefreshGlobalSoundAlertPage(); }
        [HarmonyPatch]
        class EquipmentAlertPatch
        {
            static IEnumerable<MethodBase> TargetMethods()
            {
                // Include inherited implementations: some equipment handles logic in a base class.
                return typeof(Thing).Assembly.GetTypes()
                    .Where(t => !t.IsInterface && typeof(ISoundAlert).IsAssignableFrom(t))
                    .Select(t => AccessTools.Method(t, "SetLogicValue", new[] { typeof(LogicType), typeof(double) }))
                    .Where(m => m != null && !m.IsAbstract).Distinct().Cast<MethodBase>();
            }
            static bool Prefix(object __instance, LogicType __0, double __1)
            {
                var logicType = __0; var value = __1;
                if (logicType != LogicType.SoundAlert || !(__instance is ISoundAlert) ||
                    double.IsNaN(value) || double.IsInfinity(value) || value < 100 || value > 199 ||
                    value != Math.Truncate(value) || !clips.ContainsKey((int)value)) return true;
                var setter = AccessTools.Property(__instance.GetType(), "SoundAlert")?.GetSetMethod(true);
                if (setter == null) { Warn("No SoundAlert setter on " + __instance.GetType().FullName); return true; }
                try
                {
                    // Native setter preserves existing networking and playback; only bypass vanilla ID clamp.
                    setter.Invoke(__instance, new object[] { (byte)value });
                    Info("Custom SoundAlert " + (int)value + " written to " + __instance.GetType().Name);
                    return false;
                }
                catch (Exception ex) { Error("Custom SoundAlert write failed: " + ex); return true; }
            }
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
                __result = labels[__instance.Mode]; return false;
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
