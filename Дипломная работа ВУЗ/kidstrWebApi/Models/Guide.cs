using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace kidstrWebApi.Models
{
    [Table("Guide")]
    public class Guide
    {
        private string idEmp;
        private int idServ;

        public Guide()
        {
        }

        public Guide(string idEmp, int idServ)
        {
            this.idEmp = idEmp;
            this.idServ = idServ;
        }

        [Key]
        [Column("id_emp")]
        [JsonProperty("IdEmp")]
        public string IdEmp { get => idEmp; set => idEmp = value; }
        [Key]
        [Column("id_serv")]
        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
