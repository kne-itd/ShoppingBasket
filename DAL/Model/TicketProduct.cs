using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class TicketProduct : Product
    {
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        private ProductType productType;
        public ProductType ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        public TicketProduct()
        {
            productType = ProductType.Tickets;
        }
    }
}
