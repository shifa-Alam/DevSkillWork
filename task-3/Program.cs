namespace Task3
{

    public class Customer
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class Order
    {
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Order> orders = new List<Order>();
            for (int i = 1; i < 6; i++)
            {
                Customer customer = new Customer();
                customer.Id = i;
                customer.Name = "Customer  Name " + i.ToString();
                customers.Add(customer);

                Order order = new Order();
                order.CustomerId = i;
                order.ProductName = "Product Name" + i.ToString();
                order.Quantity = i + 10;
                orders.Add(order);
            }

            var query =
                    from customer in customers
                    join order in orders on customer.Id equals order.CustomerId
                    where customer.Id == order.CustomerId
                    select new { CustomerName = customer.Name, ProductName = order.ProductName, Quantity = order.Quantity };

            foreach (var x in query.ToList())
            {
                Console.WriteLine(x.ToString());
            }
        }


    }
}

