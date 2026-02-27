namespace SieMarket.Models
{

    public class Customer
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public List<Order> Orders { get; set; } = new List<Order>();

        public Customer(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void PlaceOrder(Order order)
        {
            Orders.Add(order);
        }

        public decimal GetTotalSpent()
        {
            return Orders.Sum(order => order.CalculateFinalPrice());
        }

    }
}