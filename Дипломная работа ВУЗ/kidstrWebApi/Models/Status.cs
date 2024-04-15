using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace kidstrWebApi.Models
{
    [Table("Status")]
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

        [Key]
        [Column("id_stat")]
        [JsonProperty("IdStat")]
        public int IdStat { get => idStat; set => idStat = value; }
        [Column("name")]
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
