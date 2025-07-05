using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, string productId, double price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return Price * Quantity;
    }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsUSA()
    {
        return Country.ToLower() == "usa";
    }
}

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool LivesInUSA()
    {
        return Address.IsUSA();
    }
}

public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalPrice();
        }

        // Add shipping cost
        if (customer.LivesInUSA())
        {
            total += 5; // Flat rate inside USA
        }
        else
        {
            total += 35; // Flat rate international
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"- {product.Name} ({product.ProductId})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        Address addr = customer.Address;
        return $"Shipping Label:\n{customer.Name}\n{addr.Street}\n{addr.City}, {addr.State}\n{addr.Country}";
    }
}

public static class OnlineOrderingProgram
{
    public static void Run()
    {
        Address addr = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer = new Customer("John Doe", addr);

        Product product1 = new Product("Book", "B123", 10.50, 2);
        Product product2 = new Product("Pen", "P456", 1.25, 5);

        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);

        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.GetTotalCost()}");
    }
}
