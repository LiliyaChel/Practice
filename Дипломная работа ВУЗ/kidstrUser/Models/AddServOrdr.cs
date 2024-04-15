using Newtonsoft.Json;
using System.ComponentModel;

namespace kidstrUser.Models
{
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

        [JsonProperty("IdAdd")]
        public int IdAdd { get => idAdd; set => idAdd = value; }
        [JsonProperty("IdOrdr")]
        public int IdOrdr { get => idOrdr; set => idOrdr = value; }
        [DefaultValue(1)]
        [JsonProperty("AddCount")]
        public int AddCount { get => addCount; set => addCount = value; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
    }
}
