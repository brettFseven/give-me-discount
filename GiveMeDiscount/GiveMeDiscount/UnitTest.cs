using System;
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
            Bill bill = new Bill(new StockItem[] {
                new StockItem("Bike", 100)
            });

            double total = bill.Checkout(new Employee());
            Assert.AreEqual(total, 70);
        }

        [TestMethod]
        public void TestAffiliate()
        {
            Bill bill = new Bill(new StockItem[] {
                new StockItem("Bike", 100)
            });

            double total = bill.Checkout(new Affiliate());
            Assert.AreEqual(total, 90);
        }

        [TestMethod]
        public void TestCustomer()
        {
            Bill bill = new Bill(new StockItem[] {
                new StockItem("Unicycle", 50)
            });

            double total = bill.Checkout(new Customer("2015-01-01"));
            Assert.AreEqual(total, 50);
        }

        [TestMethod]
        public void TestCustomerOver2Years()
        {
            Bill bill = new Bill(new StockItem[] {
                new StockItem("Bike", 100)
            });

            double total = bill.Checkout(new Customer("2013-01-01"));
            Assert.AreEqual(total, 95);
        }

        [TestMethod]
        public void TestGroceries()
        {

        }

        [TestMethod]
        public void TestNonGroceries()
        {

        }



    }
}
