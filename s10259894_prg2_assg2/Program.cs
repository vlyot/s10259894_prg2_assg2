﻿using s10259894_prg2_assg2;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    private static void Main(string[] args)
    {
        List<IceCream> IceCreamList = new List<IceCream>();
        Queue<Order> Queue = new Queue<Order>();
        DisplayCustomers();
    }
    static void DisplayCustomers()
    {
        string[] data = File.ReadAllLines("customers.csv");
        string[] header = data[0].Split(',');
        Console.WriteLine("{0,10}, {1,10}, {2,10}" , header[0], header[1], header[2]);
        for (int i = 1; i < data.Length; i++)
        {
            string[] data2 = data[i].Split(",");
            Console.WriteLine("{0,10}, {1,10}, {2,10}", data2[0], data2[1], data2[2]);
        }
    }
}