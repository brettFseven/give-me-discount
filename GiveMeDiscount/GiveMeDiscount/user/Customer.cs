using System;
using System.Globalization;

namespace GiveMeDiscount.user
{
    public class Customer : User
    {
        public DateTime JoinDate { get; set; }

        public Customer(String dateString)
        {
            string pattern = "yyyy-MM-dd";
            DateTime parsedDate;
            if (!DateTime.TryParseExact(dateString, pattern, null, DateTimeStyles.None, out parsedDate))
            {
                throw new Exception("Invalid date provided. Please use yyyy-MM-dd format");
            }

            this.JoinDate = parsedDate;
        }

        public override double GetDiscountPercentage()
        {
            DateTime TwoYearsLater = JoinDate.AddYears(2);
            if (TwoYearsLater < DateTime.Now)
            {
                return 5;
            }
           
            return 0;
        }
    }
}
