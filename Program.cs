using SieMarket.Models;
using System.Collections;

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
            order1.AddItem(new Item("Headphones", 1, 800)); 

            var order2 = new Order();
            order2.AddItem(new Item("PhoneCase", 3, 20));

            var order3 = new Order();
            order3.AddItem(new Item("Headphones", 2, 300));

            var order4 = new Order();
            order4.AddItem(new Item("Headphones", 1, 400));

            var order5 = new Order();
            order5.AddItem(new Item("Charger", 2, 50));

            
            ana.PlaceOrder(order1);
            ana.PlaceOrder(order2);

            tom.PlaceOrder(order3);

            sara.PlaceOrder(order4);
            sara.PlaceOrder(order5);

            var customers = new List<Customer> { ana, tom, sara };

            Console.WriteLine($"Alice total: {ana.GetTotalSpent()}€");
            Console.WriteLine($"Bob total: {tom.GetTotalSpent()}€");
            Console.WriteLine($"Sara total: {sara.GetTotalSpent()}€");


            string winner = GetTopSpenderName(customers);
            Console.WriteLine("Top customer: " + winner);

            FindPopularProducts(customers);
        }

        // Method for finding a customer who has spent the most money
        public static string GetTopSpenderName(List<Customer> customers)
            {
                if (customers == null || !customers.Any()) return "No customers found";

                var topCustomer = customers
                    .OrderByDescending(c => c.GetTotalSpent())
                    .FirstOrDefault();

                return topCustomer?.Name ?? "Unknown";
        }

        
        // Method for finding popular products
        public static void FindPopularProducts(List<Customer> customers)
        {
            // Flatten all Orders from all Customers into one single list
            var allOrders = customers.SelectMany(c => c.Orders).ToList();
            Console.WriteLine("allOrders: \n");
            PrintEnumerable(allOrders);


            // Flatten all Items from those orders into one single list
            var allItemsSold = allOrders.SelectMany(o => o.Items).ToList();
            Console.WriteLine("allItemsSold: \n");
            PrintEnumerable(allItemsSold);


            // Group the items by their Product Name
            var groupedByProduct = allItemsSold.GroupBy(i => i.ProductName);

            foreach (var group in groupedByProduct)
            {
                // The 'Key' is the Product Name
                Console.WriteLine($"Bucket Key: {group.Key}");

                // The 'group' itself is iterable (it's the list of items in that bucket)
                foreach (var item in group)
                {
                    Console.WriteLine($"   -> {item}");
                }
            }

            // Convert the groups into a Dictionary (Name -> Total)
            var productTotals = groupedByProduct.ToDictionary(
                g => g.Key,            
                g => g.Sum(i => i.Quantity)
            );

            foreach (var entry in productTotals)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        public static void PrintEnumerable(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
