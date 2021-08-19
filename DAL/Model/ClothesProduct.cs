using DAL.Model;
using System;

namespace DAL.Model
{
    public class ClothesProduct : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }
       
        private ProductType productType;
        public ProductType ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        public ClothesProduct()
        {
            productType = ProductType.Clothes;
        }
    }
}
