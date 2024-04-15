using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class Price
    {
        private int idPrice;
        private int idServ;
        private int memberMin;
        private int? memberMax;
        private int accomCount;
        private string condit;
        private double cost;
        private bool outdated;

        public Price()
        {
        }

        public Price(int idServ, int memberMin, int? memberMax, int accomCount, string condit, double cost, bool outdated)
        {
            this.idServ = idServ;
            this.memberMin = memberMin;
            this.memberMax = memberMax;
            this.accomCount = accomCount;
            this.condit = condit;
            this.cost = cost;
            this.outdated = outdated;
        }

        [JsonProperty("IdPrice")]
        public int IdPrice { get => idPrice; set => idPrice = value; }
        [Browsable(false)]
        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [DefaultValue(0)]
        [JsonProperty("MemberMin")]
        public int MemberMin { get => memberMin; set => memberMin = value; }
        [JsonProperty("MemberMax")]
        public int? MemberMax { get => memberMax; set => memberMax = value; }
        [DefaultValue(0)]
        [JsonProperty("AccomCount")]
        public int AccomCount { get => accomCount; set => accomCount = value; }
        [JsonProperty("Condit")]
        public string Condit { get => condit; set => condit = value; }
        [DefaultValue(0)]
        [JsonProperty("Cost")]
        public double Cost { get => cost; set => cost = value; }
        [DefaultValue(false)]
        [JsonProperty("Outdated")]
        public bool Outdated { get => outdated; set => outdated = value; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
        public override string ToString()
        {
            string max = MemberMax.HasValue ? MemberMax.ToString() : "..";
            return $"{IdPrice} | {MemberMin}-{max} чел., {AccomCount} сопр. | {Condit} | {Cost} р.";
        }
    }
}

