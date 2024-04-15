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
    [Table("AddServ_Ordr")]
    public class AddServOrdr
    {
        private int idAdd;
        private int idOrdr;
        private int addCount;

        public AddServOrdr()
        {
        }

        public AddServOrdr(int idAdd, int idOrdr, int addCount)
        {
            this.idAdd = idAdd;
            this.idOrdr = idOrdr;
            this.addCount = addCount;
        }
        public AddServOrdr(int idAdd, int idOrdr)
        {
            this.idAdd = idAdd;
            this.idOrdr = idOrdr;
        }

        [Key]
        [Column("id_add")]
        [JsonProperty("IdAdd")]
        public int IdAdd { get => idAdd; set => idAdd = value; }
        [Key]
        [Column("id_ordr")]
        [JsonProperty("IdOrdr")]
        public int IdOrdr { get => idOrdr; set => idOrdr = value; }
        [Column("add_count")]
        [DefaultValue(1)]
        [JsonProperty("AddCount")]
        public int AddCount { get => addCount; set => addCount = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
