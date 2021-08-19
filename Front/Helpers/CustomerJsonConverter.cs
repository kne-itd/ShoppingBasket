using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Front.Helpers
{
    public class CustomerJsonConverter : JsonConverter<Customer>
    {
        public override Customer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var customer = new Customer();
            var bogy = "";
            var bb = 1;

            var startDepth = reader.CurrentDepth;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject && reader.CurrentDepth == startDepth)
                {
                    return customer;
                }
                //if (reader.TokenType != JsonTokenType.PropertyName)
                //{
                //    throw new JsonException("Expected PropertyName token");
                //}
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propName = reader.GetString();
                    reader.Read();
                    switch (propName)
                    {
                        case "StreetAddress":
                            customer.StreetAddress = reader.GetString();
                            break;
                        case "Zip":
                            customer.Zip = reader.GetString();
                            break;
                        case "City":
                            customer.City = reader.GetString();
                            break;
                        case "Name":
                            customer.Name = reader.GetString();
                            break;
                        case "Email":
                            customer.Email = reader.GetString();
                            break;
                        default:
                            break;
                    }
                }

                
            }
            var test = customer;
            return customer;
            throw new JsonException("Expected EndObject token");
        }

        public override void Write(Utf8JsonWriter writer, Customer value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
