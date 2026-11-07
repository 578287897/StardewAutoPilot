using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace StardewAutoPilot
{
    /// <summary>
    /// Local copy of pixelharvestwiki, one tab-separated record per line in wiki.txt.
    /// The mod looks up by Chinese name, English name, or slug. It does not fetch the website.
    /// </summary>
    internal static class WikiText
    {
        private static List<Row> rows = new List<Row>();

        private sealed class Row
        {
            public string Dataset;
            public string Slug;
            public string Zh;
            public string En;
            public string Summary;
            public Dictionary<string, string> Attrs;
        }

        public static int Count => rows.Count;

        public static void Load(string directory)
        {
            string path = Path.Combine(directory, "wiki.txt");
            var loaded = new List<Row>();
            if (File.Exists(path))
            {
                foreach (string line in File.ReadLines(path))
                {
                    if (line.Length == 0 || line[0] == '#')
                        continue;
                    string[] parts = line.Split('\t');
                    if (parts.Length < 5)
                        continue;
                    var attrs = new Dictionary<string, string>();
                    for (int i = 5; i < parts.Length; i++)
                    {
                        int eq = parts[i].IndexOf('=');
                        if (eq > 0)
                            attrs[parts[i].Substring(0, eq)] = parts[i].Substring(eq + 1);
                    }
                    loaded.Add(new Row
                    {
                        Dataset = parts[0],
                        Slug = parts[1],
                        Zh = parts[2],
                        En = parts[3],
                        Summary = parts[4],
                        Attrs = attrs
                    });
                }
            }
            rows = loaded;
        }

        public static List<Dictionary<string, object>> Find(string query, int limit = 5)
        {
            limit = Math.Clamp(limit, 1, 20);
            var ranked = new List<(int score, int catalog, int length, Row row)>();
            foreach (Row row in rows)
            {
                int value = Score(row, query);
                if (value > 0)
                    ranked.Add((-value, row.Dataset == "catalog" ? 1 : 0, row.Zh.Length, row));
            }
            return ranked
                .OrderBy(item => item.score).ThenBy(item => item.catalog).ThenBy(item => item.length)
                .Take(limit)
                .Select(item => (Dictionary<string, object>)new Dictionary<string, object>
                {
                    ["dataset"] = item.row.Dataset,
                    ["slug"] = item.row.Slug,
                    ["zh"] = item.row.Zh,
                    ["en"] = item.row.En,
                    ["summary"] = item.row.Summary,
                    ["attrs"] = item.row.Attrs
                })
                .ToList();
        }

        private static int Score(Row row, string query)
        {
            if (string.IsNullOrWhiteSpace(query) || query.Trim().Length < 2)
                return 0;
            string folded = query.Trim();
            if (folded.Equals(row.Zh, StringComparison.OrdinalIgnoreCase)
                || folded.Equals(row.En, StringComparison.OrdinalIgnoreCase)
                || folded.Equals(row.Slug, StringComparison.OrdinalIgnoreCase))
                return 100;
            string qCjk = Cjk(query);
            if (qCjk.Length > 0)
            {
                int covered = SubseqLen(qCjk, Cjk(row.Zh));
                if (covered == qCjk.Length && covered >= 2)
                    return 80;
                if (covered >= 2)
                    return 40 + covered;
            }
            var names = new HashSet<string>(Words(row.En + " " + row.Slug.Replace('-', ' ')));
            string[] qWords = Words(query);
            if (qWords.Length > 0 && qWords.All(names.Contains))
                return 70;
            return 0;
        }

        private static string Cjk(string text)
        {
            return string.Concat(text.Where(ch => ch >= 0x4e00 && ch <= 0x9fff));
        }

        private static int SubseqLen(string needle, string hay)
        {
            int i = 0;
            foreach (char ch in hay)
            {
                if (i < needle.Length && needle[i] == ch)
                    i++;
            }
            return i;
        }

        private static string[] Words(string text)
        {
            return Regex.Matches(text.ToLowerInvariant(), "[a-z0-9]+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
        }
    }
}
