namespace GiveMeDiscount.user
{
    public class Employee : User
    {
        public override double GetDiscountPercentage()
        {
            return 30;
        }
    }
}
