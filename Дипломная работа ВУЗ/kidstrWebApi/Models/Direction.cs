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
    [Table("Direction")]
    public class Direction
    {
        private int idDir;
        private string name;
        private bool outdated;

        public Direction()
        {
        }

        public Direction(string name, bool outdated)
        {
            this.name = name;
            this.outdated = outdated;
        }

        public Direction(string name)
        {
            this.name = name;
        }

        [Key]
        [Column("id_dir")]
        [JsonProperty("IdDir")]
        public int IdDir { get => idDir; set => idDir = value; }
        [Column("name")]
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [Column("outdated")]
        [DefaultValue(false)]
        [JsonProperty("Outdated")]
        public bool Outdated { get => outdated; set => outdated = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
