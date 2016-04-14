using Microsoft.VisualStudio.TestTools.UnitTesting;
using GiveMeDiscount.bill;
using GiveMeDiscount.stock;
using GiveMeDiscount.user;

namespace GiveMeDiscount
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestEmployee()
        {
            //Using Non-Grocery to test percentage discount
            Bill bill = new Bill(new StockItem[] {
                new StockItem("Bike", 100)
            });

            double total = bill.Checkout(new Employee());
            Assert.AreEqual(total, 70);
        }

        [TestMethod]
        public void TestAffiliate()
        {
            //Using Non-Grocery to test percentage discount
            Bill bill = new Bill(new StockItem[] {
                new StockItem("Bike", 100)
            });

            double total = bill.Checkout(new Affiliate());
            Assert.AreEqual(total, 90);
        }

        [TestMethod]
        public void TestCustomer()
        {
            //Using Non-Grocery to test percentage discount
            Bill bill = new Bill(new StockItem[] {
                new StockItem("Unicycle", 50)
            });

            double total = bill.Checkout(new Customer("2015-01-01"));
            Assert.AreEqual(total, 50);
        }

        [TestMethod]
        public void TestCustomerOver2Years()
        {
            //Using Non-Grocery to test percentage discount
            Bill bill = new Bill(new StockItem[] {
                new StockItem("Bike", 100)
            });

            double total = bill.Checkout(new Customer("2013-01-01"));
            Assert.AreEqual(total, 95);
        }

        [TestMethod]
        public void TestGroceries()
        {
            //Using Groceries to test Fixed Discount only
            Bill bill = new Bill(new StockItem[] {
                new GroceryItem("Banana", 20),
                new GroceryItem("Apple", 25),
                new GroceryItem("Bread", 55),
                new GroceryItem("Ice-Cream", 20),
                new GroceryItem("Chocolate", 25),
                new GroceryItem("Spices", 55)
            });

            double total = bill.Checkout(new Employee());
            Assert.AreEqual(total, 190);
        }

        [TestMethod]
        public void TestRealWorldScenario()
        {
            Bill bill = new Bill(new StockItem[] {
                new GroceryItem("Banana", 20),
                new GroceryItem("Apple", 25),
                new GroceryItem("Bread", 55),
                new StockItem("Mac Book", 4000),
                new StockItem("HTC", 500)
            });

            double total = bill.Checkout(new Employee());
            Assert.AreEqual(total, 3090);
        }
    }
}
