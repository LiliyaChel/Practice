using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace kidstrWebApi.Models
{
    [Table("Employee")]
    public class Employee
    {
        private string idEmp;
        private string name;
        private string phone;

        public Employee()
        {
        }

        public Employee(string idEmp, string name, string phone)
        {
            this.idEmp = idEmp;
            this.name = name;
            this.phone = phone;
        }

        [Key]
        [Column("id_emp")]
        [JsonProperty("IdEmp")]
        public string IdEmp { get => idEmp; set => idEmp = value; }
        [Column("name")]
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [Column("phone")]
        [JsonProperty("Phone")]
        public string Phone { get => phone; set => phone = value; }
        [NotMapped]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
