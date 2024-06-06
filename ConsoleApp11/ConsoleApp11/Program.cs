using System;
using System.Collections;
using System.Collections.Generic;

// Клас, що представляє окремий корабель
public class Ship
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Ship(string name, string type)
    {
        Name = name;
        Type = type;
    }
}

// Клас, що представляє флот кораблів та реалізує інтерфейси IEnumerable і IEnumerator
public class Fleet : IEnumerable<Ship>, IEnumerator<Ship>
{
    private List<Ship> ships = new List<Ship>();
    private int position = -1;

    // Додаємо корабель до флоту
    public void AddShip(Ship ship)
    {
        ships.Add(ship);
    }

    // Реалізація інтерфейсу IEnumerable
    public IEnumerator<Ship> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Реалізація інтерфейсу IEnumerator
    public bool MoveNext()
    {
        position++;
        return (position < ships.Count);
    }

    public void Reset()
    {
        position = -1;
    }

    public Ship Current
    {
        get
        {
            try
            {
                return ships[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        // Нічого не робимо
    }
}

// Головний клас програми
class Program
{
    static void Main(string[] args)
    {
        Fleet fleet = new Fleet();
        fleet.AddShip(new Ship("Black Pearl", "Корвет"));
        fleet.AddShip(new Ship("HMS Victory", "Вітрильник"));
        fleet.AddShip(new Ship("Titanic", "Пароплав"));
        fleet.AddShip(new Ship("USS Enterprise", "Корабель"));

        // Використовуємо foreach для ітерації по кораблях у флоті
        foreach (Ship ship in fleet)
        {
            Console.WriteLine($"{ship.Name} - {ship.Type}");
        }
    }
}
