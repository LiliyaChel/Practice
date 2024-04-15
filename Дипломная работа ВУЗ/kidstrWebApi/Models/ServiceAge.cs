using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace kidstrWebApi.Models
{
    [Table("Service_Age")]
    public class ServiceAge
    {
        private int idServ;
        private int idGroup;

        public ServiceAge()
        {
        }

        public ServiceAge(int idServ, int idGroup)
        {
            this.idServ = idServ;
            this.idGroup = idGroup;
        }

        [Key]
        [Column("id_serv")]
        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [Key]
        [Column("id_group")]
        [JsonProperty("IdGroup")]
        public int IdGroup { get => idGroup; set => idGroup = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
