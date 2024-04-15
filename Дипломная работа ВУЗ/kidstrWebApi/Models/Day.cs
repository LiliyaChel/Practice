using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace kidstrWebApi.Models
{
    [Table("Days")]
    public class Day
    {
        private int idServ;
        private int dayNum;

        public Day()
        {
        }

        public Day(int idServ, int dayNum)
        {
            this.idServ = idServ;
            this.dayNum = dayNum;
        }

        [Key]
        [Column("id_serv")]
        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [Key]
        [Column("day_num")]
        [JsonProperty("DayNum")]
        public int DayNum { get => dayNum; set => dayNum = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
