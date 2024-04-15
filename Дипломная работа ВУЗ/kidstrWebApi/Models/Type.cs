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
    [Table("Types")]
    public class Type
    {
        private int idType;
        private string name;
        private bool outdated;

        public Type()
        {
        }

        public Type(string name)
        {
            this.name = name;
        }

        public Type(string name, bool outdated)
        {
            this.name = name;
            this.outdated = outdated;
        }

        [Key]
        [Column("id_type")]
        [JsonProperty("IdType")]
        public int IdType { get => idType; set => idType = value; }
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
