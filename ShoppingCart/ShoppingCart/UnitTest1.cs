using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart
{
    public struct ShoppingCart
    {
        public string product;
        public decimal price;
        public ShoppingCart(string product,decimal price)
        {
            this.product = product;
            this.price = price;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTotalPriceOfProducts()
        {
            var shoppingCart = new ShoppingCart[] { new ShoppingCart("Fridge", 400), new ShoppingCart("Tv", 300), new ShoppingCart("mp3 player", 100), new ShoppingCart("Phone", 200) };
            Assert.AreEqual(1000, CalculateTotalCostOfProducts(shoppingCart));
        }
        [TestMethod]
        public void TestFindCheapestProduct()
        {
            var shoppingCart = new ShoppingCart[] { new ShoppingCart("Fridge", 400), new ShoppingCart("Tv", 300), new ShoppingCart("mp3 player", 100), new ShoppingCart("Phone", 200) };
            Assert.AreEqual("mp3 player", CalculateCheapestProduct(shoppingCart));
        }
           
        static decimal CalculateTotalCostOfProducts(ShoppingCart[] shoppingCart)
        {
            decimal totalCost = 0;
            for (int i = 0; i < shoppingCart.Length; i++)
            {
                totalCost += shoppingCart[i].price;
            }
            return totalCost;
        }
        static string CalculateCheapestProduct(ShoppingCart[] shoppingCart)
        {
            string cheapestProduct = shoppingCart[0].product;
            for (int i = 0; i < shoppingCart.Length-1; i++)
            {
                if (shoppingCart[i].price > shoppingCart[i + 1].price) cheapestProduct = shoppingCart[i+1].product;
            }
            return cheapestProduct;
        }
    }
    
}
