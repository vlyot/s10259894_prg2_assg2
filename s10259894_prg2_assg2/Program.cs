﻿using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
abstract class IceCream
{
    private string option;
    public string Option
    {
        get { return option; }
        set { option = value.ToLower(); }
    }

    private int scoops;
    public int Scoops
    {
        get { return scoops; }
        set { scoops = value; }
    }

    private List<Flavour> flavours = new List<Flavour>();
    public List<Flavour> Flavours
    {
        get { return flavours; }
        set { flavours = value; }
    }

    private List<Topping> toppings = new List<Topping>();
    public List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public IceCream() { }

    public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) 
    { 
        this.Option = option;
        this.Scoops = scoops;
        this.Flavours = flavours;
        this.Toppings = toppings;
    }

    public abstract double CalculatePrice();
    public override string ToString()
    {
        return $"Option: {Option}, Scoops: {Scoops}, Flavours: {Flavours}, Toppings: {Toppings}";
    }
}

class Cup : IceCream
{
    public Cup() { }

    public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings):base(option,scoops, flavours, toppings)
    {
        Option = option;
        Scoops = scoops;
        Flavours = flavours;
        Toppings = toppings;
    }
    public override double CalculatePrice()
    {
        double total = 0;
        foreach (Flavour f in Flavours)
        {
            if (f.Type == "vanilla" || f.Type == "chocolate"|| f.Type == "strawberry")
            {
                continue;
            }
            else if (f.Type == "durian" || f.Type == "ube" || f.Type == "sea salt")
            {
                total += 2;
            }
        }
        if (Scoops == 1)
        {
            total += 4;
        }
        else if (Scoops == 2)
        {
            total += 5.50;
        }
        else if (Scoops == 3)
        {
            total += 6.50;
        }
        total += Toppings.Count;
        return total;
    }
    public override string ToString()
    {
        return $"Option: {Option}, Scoops: {Scoops}, Flavours: {Flavours}, Toppings: {Toppings}";
    }
}
class Cone : IceCream
{
    private bool dipped;
    public bool Dipped
    {
        get { return dipped; }
        set { dipped = value; }
    }
    public Cone() { }
    public Cone(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, bool dipped) : base(option, scoops, flavours, toppings)
    {
        Option = option;
        Scoops = scoops;
        Flavours = flavours;
        Toppings = toppings;
        Dipped = dipped;
    }

    public override double CalculatePrice()
    {
        double total = 0;
        foreach (Flavour f in Flavours)
        {
            if (f.Type == "vanilla" || f.Type == "chocolate" || f.Type == "strawberry")
            {
                continue;
            }
            else if (f.Type == "durian" || f.Type == "ube" || f.Type == "sea salt")
            {
                total += 2;
            }
        }
        if (Scoops == 1)
        {
            total += 4;
        }
        else if (Scoops == 2)
        {
            total += 5.50;
        }
        else if (Scoops == 3)
        {
            total += 6.50;
        }
        total += Toppings.Count;
        if (dipped)
        {
            total += 2;
        }
        return total;
    }

    public override string ToString()
    {
        return $"Option: {option}, Scoops: {scoops}, Flavours: {flavours}, Toppings: {toppings}";
    }
}

class Flavour
{
    private string type;
    public string Type
    {
        get { return type; }
        set { type = value.ToLower(); }
    }

    private bool premium;
    public bool Premium
    {
        get { return premium; }
        set { premium = value; }
    }

    private int quantity;
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public Flavour() { }

    public Flavour(string type, bool premium, int quantity) 
    { 
        this.Type = type;
        this.Premium = premium;
        this.Quantity = quantity;
    }
    public override string ToString()
    {
        return $"Flavour type: {Type}, premium: {Premium}, quantity: {Quantity}";
    }
}

class Topping
{
    private string type;
    public string Type
    {
        get { return type; }
        set { type = value.ToLower(); }
    }

    public Topping() { }

    public Topping(string type)
    {
        Type = type;
    }

    public override string ToString()
    {
        return $"Topping: {Type}";
    }
}