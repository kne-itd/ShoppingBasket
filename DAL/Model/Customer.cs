using System;
namespace DAL.Model
{
    public class Customer : Person
    {
        public Address CustomerAddress { get; set; }
    }
}
