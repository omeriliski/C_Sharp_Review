﻿using C__Basics.Entities;
using Microsoft.Extensions.Logging;

namespace C__Basics
{
    internal class Basics
    {
        public static void BasicExamples()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();

            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogWarning("Uygulama başlatılıyor..........................................................................");

            int a = 10;
            Console.WriteLine("a: " + a ?? "no a");     // if there is a , it will be written, if not, "no a" will be written

            Console.WriteLine("------------ Variables -------------------");
            // type Casting
            decimal valueA = 10;
            int valueB = (int)valueA;   // Explicit conversion

            decimal valueC = valueA;    // Implicit conversion

            int valueD = 3;

            // it returns decimal
            Console.WriteLine("Type of Value:" + (valueA / valueB).GetType());

            // GetType()
            Console.WriteLine("Type of Value:" + valueA.GetType());

            // Float    6-9 digits      4 bytes
            // Double   15-17 digits    8 bytes
            // Decimal  28-29 digits    16bytes


            Console.WriteLine("------------ Date Types -------------------");
            DateTime today = new DateTime(2024, 11, 01, 16, 2, 0);
            Console.WriteLine("today: " + today);
            Console.WriteLine("timeOfDay:" + today.TimeOfDay);
            Console.WriteLine("tomorrow: " + today.AddDays(2));

            Console.WriteLine("now:" + DateTime.Now);

            Console.WriteLine("------------ Classes and Methods -------------------");
            Helper.WriteSomething();    // to check puclic...etc
            Console.WriteLine("test:" + Product.test);

            Product product1 = new Product(1, "tisch", 150);
            Console.WriteLine("description: " + product1.Description("new", "expensive", "amazing"));
            Console.WriteLine("id: " + product1.Id + " name: " + product1.Name + " price: " + product1.Price + "Euro");

            Product product2 = new Product("stuhl", 50);
            Console.WriteLine("id: " + product2.Id + " name: " + product2.Name + " price: " + product2.Price + "Euro");
            product2.Description();
            product2.Description("description: new, cheap, ok");

            Console.WriteLine("------------ Delegates -------------------");
            var manpHandler = new Product.ManipulatePrice(product1.Increase);
            var result = product1.Manipulate(100, 10, manpHandler);
            Console.WriteLine("result: " + result);

            var multiply = new Product.ManipulatePrice((arg1, arg2) => arg1 * arg2);
            Console.WriteLine("multiply: " + product1.Manipulate(10, 5, multiply));

            Console.WriteLine("------------ partial-------------------");
            Customer customer = new Customer() { Id = 1, Name = "John", LastName = "Doe" };
            Console.WriteLine("id: " + customer.Id + " name: " + customer.Name + " lastname: " + customer.LastName);

            Console.WriteLine("------------ Enums-------------------");
            Console.WriteLine("Enum: " + Product.TaxRate.Normal);

            Console.WriteLine("------------ Test -------------------");

            var increasedPrice = product1.Increase(product1.Price, 10);
            Console.WriteLine("increasedPrice: " + increasedPrice);

            Console.WriteLine("------------ Copilot Test -------------------");

            //use converttoDollar method to convert the price to dollar
            var dollarPrice = product1.ConvertToDollar(increasedPrice);

            //write the dollar price to the console
            Console.WriteLine("dollarPrice: " + dollarPrice);

            // create a list of products, use the constructor with 3 parameters
            List<Product> productList = new List<Product>();
            // add 3 products to the list
            productList.Add(new Product(1, "tisch", 150));
            productList.Add(new Product(2, "stuhl", 50));
            productList.Add(new Product(3, "lampe", 20));



            // use foreach to write the name of the products to the console
            foreach (var item in productList)
            {
                Console.WriteLine("name: " + item.Name);
            }

            // find the product with the highest price
            var maxPrice2 = productList.Max(x => x.Price);

            // write the name of the product with the highest price to the console
            var maxPriceProduct2 = productList.Where(x => x.Price == maxPrice2).FirstOrDefault();
            Console.WriteLine("maxPriceProduct2: " + maxPriceProduct2.Name);
        }
    }
}
