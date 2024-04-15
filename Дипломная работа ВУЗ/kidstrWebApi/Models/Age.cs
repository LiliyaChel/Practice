using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace kidstrWebApi.Models
{
    [Table("Age")]
    public class Age
    {
        private int idGroup;
        private string name;

        public Age()
        {
        }

        public Age(string name)
        {
            this.name = name;
        }

        [Key]
        [Column("id_group")]
        [JsonProperty("IdGroup")]
        public int IdGroup { get => idGroup; set => idGroup = value; }
        [Column("name")]
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
