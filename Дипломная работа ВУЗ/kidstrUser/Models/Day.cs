using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
    public class Day
    {
        private int idServ;
        private int dayNum;

        public Day()
        {
        }

        public Day(int idServ, int dayNum)
        {
            this.idServ = idServ;
            this.dayNum = dayNum;
        }

        [JsonProperty("IdServ")]
        public int IdServ { get => idServ; set => idServ = value; }
        [JsonProperty("DayNum")]
        public int DayNum { get => dayNum; set => dayNum = value; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
