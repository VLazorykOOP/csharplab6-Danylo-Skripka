using System;

interface IUserInterface
{
    void Display();
}

interface IDotNetInterface
{
    void DotNetMethod();
}

// Базовий клас - Корабель
class Ship : IUserInterface, IDotNetInterface
{
    public string Name { get; set; }
    public int YearBuilt { get; set; }
    public string Country { get; set; }
    public double Length { get; set; }

    public Ship(string name, int yearBuilt, string country, double length)
    {
        Name = name;
        YearBuilt = yearBuilt;
        Country = country;
        Length = length;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Year Built: {YearBuilt}");
        Console.WriteLine($"Country: {Country}");
        Console.WriteLine($"Length: {Length} meters");
    }

    public void Display()
    {
        Console.WriteLine("User Interface Display");
    }

    public void DotNetMethod()
    {
        Console.WriteLine(".NET Interface Method");
    }
}

// Похідний клас - Пароплав
class Steamship : Ship
{
    public int BoilerCapacity { get; set; }

    public Steamship(string name, int yearBuilt, string country, double length, int boilerCapacity)
        : base(name, yearBuilt, country, length)
    {
        BoilerCapacity = boilerCapacity;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Boiler Capacity: {BoilerCapacity} tons");
    }
}

// Похідний клас - Вітрильник
class Sailboat : Ship
{
    public int NumberOfMasts { get; set; }

    public Sailboat(string name, int yearBuilt, string country, double length, int numberOfMasts)
        : base(name, yearBuilt, country, length)
    {
        NumberOfMasts = numberOfMasts;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Number of Masts: {NumberOfMasts}");
    }
}

// Похідний клас - Корвет
class Corvette : Ship
{
    public string Weaponry { get; set; }

    public Corvette(string name, int yearBuilt, string country, double length, string weaponry)
        : base(name, yearBuilt, country, length)
    {
        Weaponry = weaponry;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Weaponry: {Weaponry}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання:
        Steamship titanic = new Steamship("Titanic", 1912, "United Kingdom", 269.1, 10000);
        Sailboat bounty = new Sailboat("Bounty", 1960, "United States", 40.5, 3);
        Corvette victory = new Corvette("Victory", 1765, "United Kingdom", 69.3, "Cannons");

        Console.WriteLine("Details of Titanic:");
        titanic.Show();
        titanic.Display();
        titanic.DotNetMethod();

        Console.WriteLine("\nDetails of Bounty:");
        bounty.Show();
        bounty.Display();
        bounty.DotNetMethod();

        Console.WriteLine("\nDetails of Victory:");
        victory.Show();
        victory.Display();
        victory.DotNetMethod();
    }
}
