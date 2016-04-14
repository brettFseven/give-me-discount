using GiveMeDiscount.stock;
using GiveMeDiscount.user;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiveMeDiscount.bill
{
    public class Bill
    {
        const int DOLLAR_DISCOUNT_PER_HUNDRED = 5;

        public StockItem[] PurchasedItems;

        public Bill(StockItem[] purchasedItems)
        {
            this.PurchasedItems = purchasedItems;
        }

        public double Checkout(User user)
        {
            List<StockItem> items = new List<StockItem>(PurchasedItems);
            //Add up Non Groceries
            double totalNonGroceries = items.Where(x => x.GetType() != typeof(GroceryItem)).Sum(x => x.Price);
            //Apply % discount to Non Groceries
            totalNonGroceries *= (100 - user.getDiscountPercentage()) / 100;
            
            //Add up Groceries
            double totalGroceries = items.Where(x => x.GetType() == typeof(GroceryItem)).Sum(x => x.Price);

            //Apply fixed discount
            double currentTotal = ApplyFixedDiscounts(totalNonGroceries + totalGroceries);
            
            return currentTotal;
        }

        private double ApplyFixedDiscounts(double currentTotal)
        {
            int numberOfHundreds = (int) currentTotal / 100;
            double newTotal = currentTotal - (numberOfHundreds * DOLLAR_DISCOUNT_PER_HUNDRED);
            return newTotal;
        }
    }
}
