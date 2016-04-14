namespace GiveMeDiscount.stock
{
    public class StockItem
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public StockItem(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

    }
}
