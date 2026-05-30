using System;

class Program
{
    static void Main(string[] args)
    {
        //(USA Customer)
        Address address1 = new Address(
            "123 Main St",
            "Phoenix",
            "AZ",
            "USA"
        );

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P100", 750.00, 1));
        order1.AddProduct(new Product("Mouse", "P200", 25.00, 2));
        order1.AddProduct(new Product("Keyboard", "P300", 45.00, 1));

        // order2(International Customer)
        Address address2 = new Address(
            "456 mujuni Road",
            "Ilala",
            "Dar es salaam",
            "Tanzania"
        );

        Customer customer2 = new Customer("Sarah Johnson", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Phone", "P400", 600.00, 1));
        order2.AddProduct(new Product("Headphones", "P500", 80.00, 2));

        // Order 1
        Console.WriteLine("ORDER 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Console.WriteLine("\n----------------------\n");

        // Order2
        Console.WriteLine("ORDER 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}