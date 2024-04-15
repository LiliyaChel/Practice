using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class Direction
    {
        private int idDir;
        private string name;
        private bool outdated;

        public Direction()
        {
        }

        public Direction(string name, bool outdated)
        {
            this.name = name;
            this.outdated = outdated;
        }

        public Direction(string name)
        {
            this.name = name;
        }

        public Direction(int idDir, string name)
        {
            this.idDir = idDir;
            this.name = name;
        }

        [JsonProperty("IdDir")]
        public int IdDir { get => idDir; set => idDir = value; }
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [DefaultValue(false)]
        [JsonProperty("Outdated")]
        public bool Outdated { get => outdated; set => outdated = value; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
