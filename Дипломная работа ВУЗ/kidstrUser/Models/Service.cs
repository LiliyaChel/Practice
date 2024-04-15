using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class Service
    {
        private int idServ;
        private string name;
        private string duration;
        private string descr;
        private string condit;
        private int idType;
        private int idDir;
        private bool outdated;

        public Service()
        {
        }

        public Service(string name, string duration, string descr, string condit, int idType, int idDir)
        {
            this.name = name;
            this.duration = duration;
            this.descr = descr;
            this.condit = condit;
            this.idType = idType;
            this.idDir = idDir;
        }

        public Service(string name, string duration, string descr, string condit, int idType, int idDir, bool outdated)
        {
            this.name = name;
            this.duration = duration;
            this.descr = descr;
            this.condit = condit;
            this.idType = idType;
            this.idDir = idDir;
            this.outdated = outdated;
        }

        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("Duration")]
        public string Duration { get => duration; set => duration = value; }
        [JsonProperty("Descr")]
        public string Descr { get => descr; set => descr = value; }
        [JsonProperty("Condit")]
        public string Condit { get => condit; set => condit = value; }
        [JsonProperty("IdType")]
        public int IdType { get => idType; set => idType = value; }
        [JsonProperty("IdDir")]
        public int IdDir { get => idDir; set => idDir = value; }
        [DefaultValue(false)]
        [JsonProperty("Outdated")]
        public bool Outdated { get => outdated; set => outdated = value; }
        [JsonIgnore]
        public string Type { get; set; }
        [JsonIgnore]
        public string Direction { get; set; }
        [JsonIgnore]
        public List<Price> Prices { get; set; }
        [JsonIgnore]
        public List<Day> Days { get; set; }
        [JsonIgnore]
        public List<Age> Ages { get; set; }
        [JsonIgnore]
        public bool Checked { get; set; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
        public override string ToString() { return $"{IdServ} | {Type} | {Duration} | {Descr} | {Condit}"; }

    }
}
