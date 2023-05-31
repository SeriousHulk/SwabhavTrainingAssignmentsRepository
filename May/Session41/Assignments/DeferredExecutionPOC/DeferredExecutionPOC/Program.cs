using DeferredExecutionPOC.Model;

List<Customer> customers = new List<Customer>(){
    new Customer { Id = 1, Name = "Vikrant", City = "Hyderabad" },
    new Customer { Id = 2, Name = "Anekant", City = "Banglore" },
    new Customer { Id = 3, Name = "Manjunath", City = "Hyderabad" },
    new Customer { Id = 4, Name = "Ravi", City = "Banglore" },
    new Customer { Id = 5, Name = "Gautam", City = "Hyderabad" },
};
List<Order> orders = new List<Order>(){
    new Order { OrderId = 101, CustomerId = 1, Amount = 100 },
    new Order { OrderId = 102, CustomerId = 2, Amount = 200 },
    new Order { OrderId = 103, CustomerId = 3, Amount = 300 },
    new Order { OrderId = 104, CustomerId = 4, Amount = 400 },
    new Order { OrderId = 105, CustomerId = 5, Amount = 500 },
};

var query = from o in orders
            join c in customers on o.CustomerId equals c.Id
            where c.City == "Hyderabad"
            select new { OrderId = o.OrderId, CustomerName = c.Name };


foreach (var item in query)
{
    Console.WriteLine("Order ID: " + item.OrderId + " Customer Name :" + item.CustomerName);
}

