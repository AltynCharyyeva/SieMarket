using SieMarket.Models;

namespace SieMarket
{
    class Program
    {
        static void Main()
        {
            
            var ana = new Customer("Ana", "ana@email.com", "123-456");
            var tom = new Customer("Tom", "tom@email.com", "789-012");
            var sara = new Customer("Sara", "sara@email.com", "230-191");


            
            var order1 = new Order(); 
            order1.AddItem(new Item("Laptop", 1, 800)); 

            var order2 = new Order();
            order2.AddItem(new Item("Phone", 3, 20));

            var order3 = new Order();
            order3.AddItem(new Item("Mouse", 2, 300));

            var order4 = new Order();
            order4.AddItem(new Item("Headphones", 1, 400));

            var order5 = new Order();
            order5.AddItem(new Item("Charger", 2, 50));

            ana.PlaceOrder(order1);
            ana.PlaceOrder(order2);

            tom.PlaceOrder(order3);

            sara.PlaceOrder(order4);
            sara.PlaceOrder(order5);

            var customers = new List<Customer> { ana, tom };

            Console.WriteLine($"Alice total: {ana.GetTotalSpent()}€");
            Console.WriteLine($"Bob total: {tom.GetTotalSpent()}€");
            Console.WriteLine($"Sara total: {sara.GetTotalSpent()}€");


            string winner = GetTopSpenderName(customers);
            Console.WriteLine("Top customer: " + winner);
        }

        // Method for finding a customer who has the most money
        public static string GetTopSpenderName(List<Customer> customers)
            {
                if (customers == null || !customers.Any()) return "No customers found";

                var topCustomer = customers
                    .OrderByDescending(c => c.GetTotalSpent())
                    .FirstOrDefault();

                return topCustomer?.Name ?? "Unknown";
        }
    }
}
