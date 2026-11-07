using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StardewAutoPilot
{
    /// <summary>Persist intent before side effects. An interrupted intent is never replayed automatically.</summary>
    internal sealed class ActionReceipts
    {
        internal sealed class Receipt
        {
            public string Scope { get; set; }
            public string Payload { get; set; }
            public Dictionary<string, object> Result { get; set; }
        }

        private readonly string path;
        private readonly Dictionary<string, Receipt> entries;

        public ActionReceipts(string path)
        {
            this.path = path;
            // Corrupt storage must fail closed, rather than forget paid operations.
            this.entries = File.Exists(path)
                ? JsonSerializer.Deserialize<Dictionary<string, Receipt>>(File.ReadAllText(path))
                    ?? throw new InvalidDataException("empty action receipts")
                : new Dictionary<string, Receipt>();
        }

        public Receipt Get(string id) => this.entries.TryGetValue(id, out var receipt) ? receipt : null;

        public bool Begin(string id, string scope, string payload)
        {
            if (this.entries.ContainsKey(id)) return false;
            this.entries.Add(id, new Receipt { Scope = scope, Payload = payload });
            try { this.Save(); }
            catch { this.entries.Remove(id); throw; }
            return true;
        }

        public void Complete(string id, Dictionary<string, object> result)
        {
            var receipt = this.entries[id];
            receipt.Result = result;
            try { this.Save(); }
            catch { receipt.Result = null; throw; }
        }

        private void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(this.path));
            string temporary = this.path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                using (var file = new FileStream(temporary, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    JsonSerializer.Serialize(file, this.entries);
                    file.Flush(true);
                }
                if (File.Exists(this.path)) File.Copy(this.path, this.path + ".bak", true);
                File.Move(temporary, this.path, true);
            }
            finally { if (File.Exists(temporary)) File.Delete(temporary); }
        }
    }
}
