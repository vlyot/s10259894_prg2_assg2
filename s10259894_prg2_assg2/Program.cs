﻿using s10259894_prg2_assg2;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

List<Customer> customerList = new List<Customer>();

while (true)
{
    DisplayMenu();
    int userChoice = GetOption();
    switch (userChoice)
    {
        case 0:
            Console.WriteLine("\n[0] Exit\n");
            Console.WriteLine("Exiting the program.");
            return;

        case 1:
            Console.WriteLine("\n[1] List all customers: \n");
            DisplayCustomers();
            break;

        case 2:
            Console.WriteLine("You selected Option 2.");
            break;

        case 3:
            Console.WriteLine("\n[3] Register new customer: \n");

            break;

        case 4:
            Console.WriteLine("\n[4] Create new order: \n");

            break;
        case 5:
            Console.WriteLine("\nDisplay customer order. ");
            DisplayOrders();
            break;
        default:
            Console.WriteLine("Invalid option. Please choose again.");
            break;
    }




    void DisplayMenu()
    {
        Console.WriteLine("\n---------------Menu--------------");
        Console.WriteLine("[1] List all customers: ");
        Console.WriteLine("[2] List all current orders: ");
        Console.WriteLine("[3] Register new customer: ");
        Console.WriteLine("[4] Create customer order: ");
        Console.WriteLine("[5] Display customer order details: ");
        Console.WriteLine("[6] Modify order details: ");
        Console.WriteLine("[0] Exit: ");
        Console.WriteLine("---------------------------------");
    }

    int GetOption()
    {
        int choice;
        do
        {
            Console.Write("Enter your choice: ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 6);

        return choice;
    }
    void Main(string[] args)
    {
        //List<Order> orders = CreateOrders();
        //List<Customer> customers = CreateCustomer();
        List<IceCream> IceCreamList = new List<IceCream>();
        Queue<Order> Queue = new Queue<Order>();
        DisplayCustomers();
    }
    void DisplayCustomers()
    {
        string[] data = File.ReadAllLines("customers.csv");
        string[] header = data[0].Split(',');
        Console.WriteLine("{0,10}, {1,10}, {2,10}", header[0], header[1], header[2]);
        for (int i = 1; i < data.Length; i++)
        {
            string[] data2 = data[i].Split(",");
            Console.WriteLine("{0,10}, {1,10}, {2,10}", data2[0], data2[1], data2[2]);
        }
    }

    /*void DisplayOrders()
    {
        string[] ordersData = File.ReadAllLines("orders.csv");
        string[] customersData = File.ReadAllLines("customers.csv");

        List<string> goldMembers = new List<string>();
        List<string> regularMembers = new List<string>();

        // Populate the lists based on membership status
        for (int i = 1; i < customersData.Length; i++)
        {
            string[] customerInfo = customersData[i].Split(",");
            string memberId = customerInfo[1]; // Assuming MemberId is the second column

            if (customerInfo[3].Equals("Gold", StringComparison.OrdinalIgnoreCase))
            {
                goldMembers.Add(memberId);
            }
            else
            {
                regularMembers.Add(memberId);
            }
        }

        // Display header
        Console.WriteLine("{0,10}, {1,10}, {2,10}, {3,10}", "Name", "MemberId", "DOB", "Order Details");

        // Display orders for gold members
        DisplayOrders("Gold Members", goldMembers, ordersData);

        // Display orders for regular members
        DisplayOrders("Regular Members", regularMembers, ordersData);
    }*/

    void DisplayOrders(string memberType, List<string> memberIds, string[] ordersData)
    {
        Console.WriteLine($"\nDisplaying {memberType} Orders:");

        for (int i = 1; i < ordersData.Length; i++)
        {
            string[] orderInfo = ordersData[i].Split(",");
            string orderId = orderInfo[1]; // Assuming MemberId is the second column

            if (memberIds.Contains(orderId))
            {
                Console.WriteLine("{0,10}, {1,10}, {2,10}, {3,10}", orderInfo[0], orderInfo[1], orderInfo[2], orderInfo[3]);
            }
        }
    }
}
/*static List<Customer> CreateCustomer()
{
    List<Customer> customers = new List<Customer>();
    string[] data = File.ReadAllLines("customers.csv");
    string[] header = data[0].Split(',');
    for (int i = 1; i < data.Length; i++)
    {
        string[] data2 = data[i].Split(",");
        Customer c = new Customer(data2[0], Convert.ToInt32(data2[1]), Convert.ToDateTime(data2[2]));
        customers.Add(c);
    }
    Console.WriteLine("Customers have been created");
    return customers;
}*/