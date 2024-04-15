using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class Age
    {
        private int idGroup;
        private string name;

        public Age()
        {
        }

        public Age(string name)
        {
            this.name = name;
        }

        [JsonProperty("IdGroup")]
        public int IdGroup { get => idGroup; set => idGroup = value; }
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
