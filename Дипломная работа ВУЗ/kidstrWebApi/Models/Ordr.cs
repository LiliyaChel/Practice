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
    [Table("Ordr")]
    public class Ordr
    {
        private int idOrdr;
        private string school;
        private int idGroup;
        private int partyCount;
        private int accomCount;
        private string contact;
        private DateTime dateTime;
        private string meetPoint;
        private double? cost;
        private double? prepay;
        private int idPrice;
        private int idStat;
        private string idEmp;

        public Ordr()
        {
        }

        [Key]
        [Column("id_ordr")]
        [JsonProperty("IdOrdr")]
        public int IdOrdr { get => idOrdr; set => idOrdr = value; }
        [Column("school")]
        [JsonProperty("School")]
        public string School { get => school; set => school = value; }
        [Column("id_group")]
        [JsonProperty("IdGroup")]
        public int IdGroup { get => idGroup; set => idGroup = value; }
        [Column("party_count")]
        [JsonProperty("PartyCount")]
        public int PartyCount { get => partyCount; set => partyCount = value; }
        [Column("accom_count")]
        [DefaultValue(0)]
        [JsonProperty("AccomCount")]
        public int AccomCount { get => accomCount; set => accomCount = value; }
        [Column("contact")]
        [JsonProperty("Contact")]
        public string Contact { get => contact; set => contact = value; }
        [Column("date_time", TypeName = "datetime")]
        [JsonProperty("DateTime")]
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        [Column("meet_point")]
        [JsonProperty("MeetPoint")]
        public string MeetPoint { get => meetPoint; set => meetPoint = value; }
        [Column("cost")]
        [JsonProperty("Cost")]
        public double? Cost { get => cost; set => cost = value; }
        [Column("prepay")]
        [JsonProperty("Prepay")]
        public double? Prepay { get => prepay; set => prepay = value; }
        [Column("id_price")]
        [JsonProperty("IdPrice")]
        public int IdPrice { get => idPrice; set => idPrice = value; }
        [Column("id_stat")]
        [JsonProperty("IdStat")]
        public int IdStat { get => idStat; set => idStat = value; }
        [Column("id_emp")]
        [JsonProperty("IdEmp")]
        public string IdEmp { get => idEmp; set => idEmp = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
