using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Front.Model
{
    public class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("ProductType")]
        public string Category { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
