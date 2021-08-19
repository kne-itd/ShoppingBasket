using BLL;
using Front.Helpers;
using Front.Model;
using ShoppingBasket.BLL;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ShoppingBasket.Front
{
    class Program
    {
        private static List<Customer> Customers;
        private static List<Product> Products;
        private static Customer CurrentCustomer;
        private static Basket ShoppingBasket;
        static void Main(string[] args)
        {
            Customers = RetrieveCustomers();
            Products = RetrieveProducts();

            MainMenu();


            //shoppingBasket.Add(Products[0]);
            //shoppingBasket.Add(Products[0]);
            //shoppingBasket.Add(Products[2]);

            //Console.WriteLine(ShoppingBasket); ;
            Console.WriteLine("Check Out? Y/N");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                Console.WriteLine(ShoppingBasket); ;
            }
        }

        private static void HandleMainMenuSelection()
        {
            throw new NotImplementedException();
        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Select a customer");
            Console.WriteLine("2) Add new customer");
            Console.WriteLine("3) Select a product");
            Console.WriteLine("4) Add new product");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowCustomerList();
                    CurrentCustomer = SelectCustomer();
                    ShoppingBasket = new Basket(CurrentCustomer);
                    MainMenu();
                    break;
                case "3":
                    ShowProductList();
                    bool exit = false;
                    Product p = new Product();
                    while (!exit)
                    {
                        p = SelectProduct();
                        if (p is null)
                        {
                            exit = true;
                        }
                        else
                        {
                            ShoppingBasket.Add(p);
                            Console.WriteLine(ShoppingBasket.Products.Count);
                        }
                    }

                    Console.WriteLine(ShoppingBasket); ;

                    break;
                case "2":
                case "4":
                default:
                    break;
            }
        }

        private static Product SelectProduct()
        {
            Console.WriteLine("Select a product to add it to the shoppingbasket");
            if (Int32.TryParse(Console.ReadLine(), out int i ))
            {
                i--;
                return Products[i];
            }
            return null;
           
        }

        private static Customer SelectCustomer()
        {
            Console.WriteLine("Select a customer");
            int i = Int32.Parse( Console.ReadLine()) - 1;
            return Customers[i];
        }

        private static void ShowProductList()
        {
            Products = RetrieveProducts();
            foreach (Product product in Products)
            {
                Console.WriteLine($"{Products.IndexOf(product) + 1} {product.Name} {product.Price}");
            }
            Console.WriteLine("x) Finito!");
        }

        private static void ShowCustomerList()
        {
            Customers = RetrieveCustomers();
            Console.Clear();
            foreach (Customer customer in Customers)
            {
                Console.WriteLine($"{Customers.IndexOf(customer) + 1}) {customer.Name} {customer.Email}");
            }
        }

        private static List<Customer> RetrieveCustomers()
        {
            CustomerRepository customerPepository = new CustomerRepository();
            string customersJson = customerPepository.GetCustomers();
            var options = new JsonSerializerOptions
            {
                // CustomerJsonConverter handles the different ways addresses are handled in
                // the json-objects compared to Front.Model.Customer
                Converters =
                {
                   new CustomerJsonConverter()
                }
            };

           return JsonSerializer.Deserialize<List<Customer>>(customersJson, options);
        }
        private static List<Product> RetrieveProducts()
        {
            ProductRepository productRepository = new ProductRepository();
            string productJson = productRepository.GetProducts();
            return JsonSerializer.Deserialize<List<Product>>(productJson);
        }
       
    }
}
