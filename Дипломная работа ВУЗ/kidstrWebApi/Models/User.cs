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
    [Table("Users")]
    public class User
    {
        private string idEmp;
        private string login;
        private string password;
        private bool root;

        public User()
        {
        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public User(string login, string password, bool root)
        {
            this.login = login;
            this.password = password;
            this.root = root;
        }

        [Key]
        [Column("id_emp")]
        [JsonProperty("IdEmp")]
        public string IdEmp { get => idEmp; set => idEmp = value; }
        [Column("login")]
        [JsonProperty("Login")]
        public string Login { get => login; set => login = value; }
        [Column("password")]
        [JsonProperty("Password")]
        public string Password { get => password; set => password = value; }
        [Column("root")]
        [DefaultValue(false)]
        [JsonProperty("Root")]
        public bool Root { get => root; set => root = value; }
    }
}
