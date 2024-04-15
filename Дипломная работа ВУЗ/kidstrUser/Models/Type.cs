using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class Type
    {
        private int idType;
        private string name;
        private bool outdated;

        public Type()
        {
        }

        public Type(string name)
        {
            this.name = name;
        }

        public Type(string name, bool outdated)
        {
            this.name = name;
            this.outdated = outdated;
        }

        public Type(int idType, string name)
        {
            this.idType = idType;
            this.name = name;
        }

        [JsonProperty("IdType")]
        public int IdType { get => idType; set => idType = value; }
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
