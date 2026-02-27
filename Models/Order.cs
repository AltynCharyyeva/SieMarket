namespace SieMarket.Models
{

    public class Order
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public DateTime OrderDate { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        // method for calculating the final price taking into consideratin the discount logic as well
        public decimal CalculateFinalPrice()
        {
            decimal total = Items.Sum(item => item.GetTotalPrice());

            if (total > 500m)
            {
                total *= 0.9m;
            }

            return total;
        }
    }
    }