using System;
using System.Collections.Generic;
using System.Linq;
namespace CustomSpeakerSounds
{
    public static class ModeCatalog
    {
        public static string[] BuildNames(string[] original, IReadOnlyDictionary<int, string> custom)
        {
            var names = (string[])original.Clone();
            int length = custom.Count == 0 ? names.Length : Math.Max(names.Length, custom.Keys.Max() + 1);
            Array.Resize(ref names, length);
            foreach (var entry in custom) names[entry.Key] = entry.Value;
            return names;
        }
        public static IEnumerable<KeyValuePair<int, string>> Visible(string[] original, IReadOnlyDictionary<int, string> custom)
        {
            for (int i = 0; i < original.Length; i++)
                if (!string.IsNullOrEmpty(original[i])) yield return new KeyValuePair<int, string>(i, original[i]);
            foreach (var entry in custom.OrderBy(x => x.Key)) yield return entry;
        }
    }
}
