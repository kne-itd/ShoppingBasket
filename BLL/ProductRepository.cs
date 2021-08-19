using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductRepository
    {
        DataAccess dataAccess = new DataAccess();
        public string GetProducts()
        {
            string json = dataAccess.GetProductList();
            return json;
        }
    }
}
