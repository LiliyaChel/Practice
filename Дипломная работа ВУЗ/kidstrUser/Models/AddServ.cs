using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class AddServ
    {
        private int idAdd;
        private string name;
        private double cost;
        private bool outdated;

        public AddServ()
        {
        }

        public AddServ(string name, double cost, bool outdated)
        {
            this.name = name;
            this.cost = cost;
            this.outdated = outdated;
        }
        public AddServ(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }

        [JsonProperty("IdAdd")]
        public int IdAdd { get => idAdd; set => idAdd = value; }
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [DefaultValue(0)]
        [JsonProperty("Cost")]
        public double Cost { get => cost; set => cost = value; }
        [DefaultValue(false)]
        [JsonProperty("Outdated")]
        public bool Outdated { get => outdated; set => outdated = value; }
        [JsonIgnore]
        public int Count { get; set; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
