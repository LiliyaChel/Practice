using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace kidstrUser.Models
{
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

        [JsonProperty("IdOrdr")]
        public int IdOrdr { get => idOrdr; set => idOrdr = value; }
        [JsonProperty("School")]
        public string School { get => school; set => school = value; }
        [Browsable(false)]
        [JsonProperty("IdGroup")]
        public int IdGroup { get => idGroup; set => idGroup = value; }
        [JsonIgnore]
        public string AgeName { get => Age.Name; }
        [JsonProperty("PartyCount")]
        public int PartyCount { get => partyCount; set => partyCount = value; }
        [DefaultValue(0)]
        [JsonProperty("AccomCount")]
        public int AccomCount { get => accomCount; set => accomCount = value; }
        [JsonProperty("Contact")]
        public string Contact { get => contact; set => contact = value; }
        [JsonProperty("DateTime")]
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        [JsonProperty("MeetPoint")]
        public string MeetPoint { get => meetPoint; set => meetPoint = value; }
        [JsonProperty("Cost")]
        public double? Cost { get => cost; set => cost = value; }
        [JsonProperty("Prepay")]
        public double? Prepay { get => prepay; set => prepay = value; }
        [JsonIgnore]
        public string ServiceName { get => Service.Name; }
        [Browsable(false)]
        [JsonProperty("IdPrice")]
        public int IdPrice { get => idPrice; set => idPrice = value; }
        [Browsable(false)]
        [JsonProperty("IdStat")]
        public int IdStat { get => idStat; set => idStat = value; }
        [Browsable(false)]
        [JsonProperty("IdEmp")]
        public string IdEmp { get => idEmp; set => idEmp = value; }
        [JsonIgnore]
        public string Status { get; set; }
        [Browsable(false)]
        [JsonIgnore]
        public Service Service { get; set; }
        [Browsable(false)]
        [JsonIgnore]
        public Price Price { get; set; }
        [Browsable(false)]
        [JsonIgnore]
        public Age Age { get; set; }
        [Browsable(false)]
        [JsonIgnore]
        public Employee Employee { get; set; }
        [JsonIgnore]
        public List<AddServ> AddServs { get; set; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
