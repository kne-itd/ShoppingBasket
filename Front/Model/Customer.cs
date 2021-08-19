using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Front.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonPropertyName("Address.StreetAddress")]
        public string StreetAddress { get; set; }
        [JsonPropertyName("Address.Zip")]
        public string Zip { get; set; }
        [JsonPropertyName("Address.City")]
        public string City { get; set; }
    }
}
