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
        public void TestMethod1()
        {
            var shoppingCart = new ShoppingCart[] { new ShoppingCart("Fridge", 400), new ShoppingCart("Tv", 300), new ShoppingCart("mp3 player", 100), new ShoppingCart("Phone", 200) };
            Assert.AreEqual(1000, CalculateTotalCostOfProducts(shoppingCart));
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
    }
    
}
