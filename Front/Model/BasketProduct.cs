using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class BasketProduct
    {
        public Product Item { get; set; }
        public DateTime AddedTime { get; set; }
        public int Amount { get; set; }
    }
}
