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
    [Table("AddServ")]
    public class AddServ
    {
        private int idAdd;
        private string name;
        private double cost;
        private bool outdated;

        public AddServ()
        {
        }

        public AddServ(string name, double cost, bool outdated)
        {
            this.name = name;
            this.cost = cost;
            this.outdated = outdated;
        }
        public AddServ(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }

        [Key]
        [Column("id_add")]
        [JsonProperty("IdAdd")]
        public int IdAdd { get => idAdd; set => idAdd = value; }
        [Column("name")]
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
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
