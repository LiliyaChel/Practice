using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class Status
    {
        private int idStat;
        private string name;

        public Status()
        {
        }

        public Status(int idStat, string name)
        {
            this.idStat = idStat;
            this.name = name;
        }

        [JsonProperty("IdStat")]
        public int IdStat { get => idStat; set => idStat = value; }
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
