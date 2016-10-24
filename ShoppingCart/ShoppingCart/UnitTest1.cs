using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingBasket
{
    public struct ShoppingBasket
    {
        public string product;
        public decimal price;
        public ShoppingBasket(string product,decimal price)
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
            var shoppingBasket = new ShoppingBasket[] { new ShoppingBasket("Fridge", 400), new ShoppingBasket("Tv", 300), new ShoppingBasket("mp3 player", 100), new ShoppingBasket("Phone", 200) };
            Assert.AreEqual(1000, CalculateTotalCostOfProducts(shoppingBasket));
        }
        [TestMethod]
        public void TestFindCheapestProduct()
        {
            var shoppingBasket = new ShoppingBasket[] { new ShoppingBasket("Fridge", 400), new ShoppingBasket("Tv", 300), new ShoppingBasket("mp3 player", 100), new ShoppingBasket("Phone", 200) };
            Assert.AreEqual("mp3 player", CalculateCheapestProduct(shoppingBasket));
        }
        [TestMethod]
        public void TestEliminateMostExpensiveProduct()
        {
            var shoppingBasket = new ShoppingBasket[] { new ShoppingBasket("Fridge", 400), new ShoppingBasket("Tv", 300), new ShoppingBasket("mp3 player", 100), new ShoppingBasket("Phone", 200) };
            CollectionAssert.AreEqual( new ShoppingBasket[] {new ShoppingBasket("Tv", 300), new ShoppingBasket("mp3 player", 100), new ShoppingBasket("Phone", 200) }, EliminateMostExpensiveProduct(shoppingBasket));   
        }
        [TestMethod]
        public void TestAddingProductToShoppingBasket()
        {
            var shoppingBasket = new ShoppingBasket[] { new ShoppingBasket("Fridge", 400), new ShoppingBasket("Tv", 300), new ShoppingBasket("mp3 player", 100), new ShoppingBasket("Phone", 200) };
            CollectionAssert.AreEqual(new ShoppingBasket[] { new ShoppingBasket("Fridge", 400), new ShoppingBasket("Tv", 300), new ShoppingBasket("mp3 player", 100), new ShoppingBasket("Phone", 200), new ShoppingBasket("Bycicle", 1000) },AddProductToShoppingBasket(shoppingBasket, new ShoppingBasket("Bycicle",1000)));
        }
           
        static decimal CalculateTotalCostOfProducts(ShoppingBasket[] shoppingBasket)
        {
            decimal totalCost = 0;
            for (int i = 0; i < shoppingBasket.Length; i++)
            {
                totalCost += shoppingBasket[i].price;
            }
            return totalCost;
        }
        static string CalculateCheapestProduct(ShoppingBasket[] shoppingBasket)
        {
            string cheapestProduct = shoppingBasket[0].product;
            for (int i = 0; i < shoppingBasket.Length-1; i++)
            {
                if (shoppingBasket[i].price > shoppingBasket[i + 1].price) cheapestProduct = shoppingBasket[i+1].product;
            }
            return cheapestProduct;
        }
        static string CalculateMostExpensiveProduct(ShoppingBasket[] shoppingBasket)
        {
            string mostExpensiveProduct = shoppingBasket[0].product;
            decimal maxprice = 0;
            for (int i = 0; i < shoppingBasket.Length - 1; i++)
            {
                if (maxprice < shoppingBasket[i].price)
                {
                    maxprice = shoppingBasket[i].price;
                    mostExpensiveProduct = shoppingBasket[i].product;
                }
            }
            return mostExpensiveProduct;
        }
        static ShoppingBasket[] EliminateMostExpensiveProduct(ShoppingBasket[] shoppingBasket)
        {
            string mostExpesiveProduct = CalculateMostExpensiveProduct(shoppingBasket);
            int j = 0;
            var shoppingBasketWithoutMostExpensiveProduct = new ShoppingBasket[0];
            for(int i = 0; i < shoppingBasket.Length; i++)
            {
                if (shoppingBasket[i].product != mostExpesiveProduct)
                {
                    Array.Resize(ref shoppingBasketWithoutMostExpensiveProduct, shoppingBasketWithoutMostExpensiveProduct.Length + 1);
                    shoppingBasketWithoutMostExpensiveProduct[j] = shoppingBasket[i];
                    j++;
                }
            }           
            return shoppingBasketWithoutMostExpensiveProduct;
        }
        static ShoppingBasket[] AddProductToShoppingBasket(ShoppingBasket[] shoppingBasket,ShoppingBasket newProduct)
        {
            Array.Resize(ref shoppingBasket, shoppingBasket.Length + 1);
            shoppingBasket[shoppingBasket.Length - 1] = newProduct;
            return shoppingBasket;
        }
            
    }
    
}
