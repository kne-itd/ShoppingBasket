using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DAL
{
    public class DataAccess
    {
        public string GetCustomerList()
        {
            return ConvertToJason(GetCustomerObjects());
        }
        public string GetProductList()
        {
            return ConvertToJason(GetProductObjects());
        }

        private List<object> GetProductObjects()
        {
            List<object> output = new List<object>();

            output.Add(new ClothesProduct
            {
                Color = "Blue",
                Size = "L",
                Price = 400,
                Name = "Levis"

            }
            );
            output.Add(new ClothesProduct
            {
                Name = "T-Shirt",
                Price = 99.5,
                Color = "Red",
                Size = "L"
            }
            );
            output.Add(new TicketProduct
            {
                Name = "Summer Days",
                Price = 495,
                Venue = "Dyrskuepladsen",
                Date = new DateTime(2021, 7, 12, 16, 0, 0)
            }
           );
            return output;
        }

        private List<object> GetCustomerObjects()
        {
            List<object> output = new List<object>();
            output.Add(new Customer
            {
                Name = "Peter Plys",
                Email = "peter@plys.com",
                CustomerAddress = new Address
                {
                    City = "Odense",
                    StreetAddress = "Munkebjergvej 130",
                    Zip = "5200"
                }
            });
            output.Add(new Customer
            {
                Name = "Tigerdyret",
                Email = "tiger@dyr.com",
                CustomerAddress = new Address
                {
                    City = "Svendborg",
                    StreetAddress = "Tusindårskoven",
                    Zip = "5700"
                }
            });

            return output;

        }
        private string ConvertToJason(List<object> objects)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            string json = JsonSerializer.Serialize(objects, options);
            return json;
        }
    }
}
