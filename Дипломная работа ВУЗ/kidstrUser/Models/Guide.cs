using Newtonsoft.Json;
using System.ComponentModel;


namespace kidstrUser.Models
{
    public class Guide
    {
        private string idEmp;
        private int idServ;

        public Guide()
        {
        }

        public Guide(string idEmp, int idServ)
        {
            this.idEmp = idEmp;
            this.idServ = idServ;
        }

        [JsonProperty("IdEmp")]
        public string IdEmp { get => idEmp; set => idEmp = value; }
        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
