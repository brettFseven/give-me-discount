
namespace GiveMeDiscount.user
{
    public class Affiliate : User
    {
        public override double GetDiscountPercentage()
        {
            return 10;
        }
    }

}

