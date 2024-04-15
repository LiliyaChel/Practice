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
    [Table("Service")]
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

        [Key]
        [Column("id_serv")]
        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [Column("name")]
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [Column("duration")]
        [JsonProperty("Duration")]
        public string Duration { get => duration; set => duration = value; }
        [Column("descr")]
        [JsonProperty("Descr")]
        public string Descr { get => descr; set => descr = value; }
        [Column("condit")]
        [JsonProperty("Condit")]
        public string Condit { get => condit; set => condit = value; }
        [Column("id_type")]
        [JsonProperty("IdType")]
        public int IdType { get => idType; set => idType = value; }
        [Column("id_dir")]
        [JsonProperty("IdDir")]
        public int IdDir { get => idDir; set => idDir = value; }
        [Column("outdated")]
        [DefaultValue(false)]
        [JsonProperty("Outdated")]
        public bool Outdated { get => outdated; set => outdated = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
