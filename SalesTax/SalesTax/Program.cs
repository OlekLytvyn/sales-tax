using System;
using System.Collections.Generic;
using Application;
using Domain;
using Domain.Entities;
using Infrastructure;

namespace SalesTax
{
    public class Program
    {
        private static TaxRateProvider taxRateProvider = new TaxRateProvider();
        private static TotalSalesTaxCalculator _totalSalesTaxCalculator;
        static void Main(string[] args)
        {
            _totalSalesTaxCalculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> { 
                new BasicSalesTaxCalculator(taxRateProvider), 
                new ImportDutySalesTaxCalculator(taxRateProvider)});

            Console.WriteLine("Output 1:");
            GenerateOutput1();
            Console.WriteLine("Output 2:");
            GenerateOutput2();
            Console.WriteLine("Output 3:");
            GenerateOutput3();

            Console.ReadKey();
        }

        private static void GenerateOutput1()
        {
            var shoppintCart = new ShoppingCart();
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Book, "1 book"), false, 12.49m));
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Music, "1 music CD"), false, 14.99m));
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Food, "1 chocolate bar"), false, 0.85m));

            Console.WriteLine(shoppintCart.Render());
        }

        private static void GenerateOutput2()
        {
            var shoppintCart = new ShoppingCart();
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Book, "1 imported box of chocolate"), true, 10.00m));
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Perfume, "1 imported bottle of perfume"), true, 47.50m));

            Console.WriteLine(shoppintCart.Render());
        }

        private static void GenerateOutput3()
        {
            var shoppintCart = new ShoppingCart();
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Perfume, "1 imported bottle of perfume"), true, 27.99m));
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Perfume, "1 bottle of perfume"), false, 18.99m));
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Medical, "1 packet of headache pills"), false, 9.75m));
            shoppintCart.Add(new ShoppingCartItem(_totalSalesTaxCalculator, new Product(ProductType.Food, "1 box of imported chocolates"), true, 11.25m));

            Console.WriteLine(shoppintCart.Render());
        }
    }
}
