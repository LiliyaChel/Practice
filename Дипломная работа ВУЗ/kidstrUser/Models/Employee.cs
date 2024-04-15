using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace kidstrUser.Models
{
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

        [JsonProperty("IdEmp")]
        public string IdEmp { get => idEmp; set => idEmp = value; }
        [JsonProperty("Name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("Phone")]
        public string Phone { get => phone; set => phone = value; }
        [JsonIgnore]
        public List<Service> Guide { get; set; }
        [Browsable(false)]
        [JsonProperty("Current")]
        public string Current { get; set; }
        [JsonIgnore]
        public List<Ordr> Orders { get; set; }
        public override string ToString() { return $"{IdEmp} | {Name} | {Phone}"; }
    }
}
