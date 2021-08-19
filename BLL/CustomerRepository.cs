using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.BLL
{
    public class CustomerRepository
    {
        public string GetCustomers()
        {
            DataAccess dataAccess = new DataAccess();
            string json = dataAccess.GetCustomerList();
            return json;
        }
    }
}
