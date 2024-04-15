using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class ServiceAge
    {
        private int idServ;
        private int idGroup;

        public ServiceAge()
        {
        }

        public ServiceAge(int idServ, int idGroup)
        {
            this.idServ = idServ;
            this.idGroup = idGroup;
        }

        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [JsonProperty("IdGroup")]
        public int IdGroup { get => idGroup; set => idGroup = value; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
