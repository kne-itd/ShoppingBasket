using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class Basket
    {
        public Customer Shopper { get; set; }
        public DateTime OrderDate;
        public List<BasketProduct> Products { get; set; }
        private decimal netPrice = 0;

        private int timeLimit = 30;


        public Basket(Customer customer)
        {
            Shopper = customer;
            OrderDate = DateTime.Now;
            Products = new List<BasketProduct>();
        }
        public void Add(Product product)
        {
            BasketProduct item = new BasketProduct();
            item.AddedTime = DateTime.Now;
            item.Item = product;
            item.Amount = 1;
            // Check if product is already in basket
            // if so just add 1 to amount
            foreach (var p in Products)
            {
                if (p.Item == product)
                {
                    item.Amount++;
                    p.Amount = item.Amount;
                }
            }
            // if amount still is 1, the product was not found in baskte, so we add it
            if (item.Amount == 1)
            {
                Products.Add(item);
            }
            
            // add products price to basket's netprice
            netPrice += product.Price;
        }
        private decimal CalculateTotalVat()
        {
            decimal output = 0;
            foreach (var item in Products)
            {
                output += item.Item.Price / 100 * 25;
            }
            return output;
        }
        public override string ToString()
        {
            List<BasketProduct> ToBeRemoved = new List<BasketProduct>();
            foreach (var item in Products)
            {
                if (item.Item.Category != "tickets")
                {
                    continue;
                }
                if (item.AddedTime.AddSeconds(timeLimit) < DateTime.Now)
                {
                    ToBeRemoved.Add(item);
                }
            }
            foreach (var item in ToBeRemoved)
            {
                Products.Remove(item);
            }
            const int lineLength = 45;
            string ZipCity = $"{Shopper.Zip} {Shopper.City}";
            string dashes = string.Empty;
            for (int i = 0; i < lineLength; i++)
            {
                dashes += "-";
            }
            string output = $"{OrderDate.ToString("dd-MM-yyyy"),lineLength}" +  Environment.NewLine;
            output += $"{OrderDate.ToString("T"),lineLength}" +                 Environment.NewLine;
            output += $"Name: {Shopper.Name,lineLength-6} " +                   Environment.NewLine;
            output += $"Email: {Shopper.Email,lineLength-7} " +                 Environment.NewLine;
            output += $"Address: {Shopper.StreetAddress,lineLength-9} " +       Environment.NewLine;
            output += $"{ZipCity, lineLength}" +                                Environment.NewLine;
            output += dashes +                                                  Environment.NewLine;
            foreach (BasketProduct p in Products)
            {
                decimal itemTotal = p.Amount * p.Item.Price;
                output += $" {p.Amount, 5}: {p.Item.Name, -20}     {p.Item.Price, 5 } {itemTotal, 6}" + Environment.NewLine;
            }
            output += dashes +                                                  Environment.NewLine;
            output += $"Vat: {CalculateTotalVat(), 40}" +                       Environment.NewLine;
            output += dashes +                                                  Environment.NewLine;
            output += $"Total: {CalculateTotalPrice(),38}";
            output +=                                                           Environment.NewLine;

            return output;
        }

        private decimal CalculateTotalPrice()
        {
            decimal output = 0;
            foreach (var item in Products)
            {
                output += item.Item.Price;
            }
            return output + CalculateTotalVat();
        }
    }
}
