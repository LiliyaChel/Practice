using Newtonsoft.Json;
using System.ComponentModel;


namespace kidstrUser.Models
{
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

        [JsonProperty("IdEmp")]
        public string IdEmp { get => idEmp; set => idEmp = value; }
        [JsonProperty("Login")]
        public string Login { get => login; set => login = value; }
        [JsonProperty("Password")]
        public string Password { get => password; set => password = value; }
        [DefaultValue(false)]
        [JsonProperty("Root")]
        public bool Root { get => root; set => root = value; }
    }
}
