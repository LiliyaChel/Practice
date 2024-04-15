using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace kidstrWebApi.Models
{
    [Table("Price")]
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

        [Key]
        [Column("id_price")]
        [JsonProperty("IdPrice")]
        public int IdPrice { get => idPrice; set => idPrice = value; }
        [Column("id_serv")]
        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [Column("member_min")]
        [DefaultValue(0)]
        [JsonProperty("MemberMin")]
        public int MemberMin { get => memberMin; set => memberMin = value; }
        [Column("member_max")]
        [JsonProperty("MemberMax")]
        public int? MemberMax { get => memberMax; set => memberMax = value; }
        [Column("accom_count")]
        [DefaultValue(0)]
        [JsonProperty("AccomCount")]
        public int AccomCount { get => accomCount; set => accomCount = value; }
        [Column("condit")]
        [JsonProperty("Condit")]
        public string Condit { get => condit; set => condit = value; }
        [Column("cost")]
        [DefaultValue(0)]
        [JsonProperty("Cost")]
        public double Cost { get => cost; set => cost = value; }
        [Column("outdated")]
        [DefaultValue(false)]
        [JsonProperty("Outdated")]
        public bool Outdated { get => outdated; set => outdated = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
