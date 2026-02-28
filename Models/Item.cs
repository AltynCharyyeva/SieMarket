namespace SieMarket.Models
{


    public class Item
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Item(string productName, int quantity, decimal price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public decimal GetTotalPrice()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            return $"{ProductName} - Qty: {Quantity} ({Price}€)";
        }
    }
}