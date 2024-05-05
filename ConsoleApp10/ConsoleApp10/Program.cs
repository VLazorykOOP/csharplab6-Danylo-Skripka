using System;

// Інтерфейс для віку та виведення інформації про персону
interface IPersona
{
    void DisplayInfo();
    int CalculateAge();
}

// Інтерфейс, який успадковує інтерфейси .NET
interface IDotNetInterface : IDisposable
{
    void DotNetMethod();
}

// Базовий клас - Персона
class Person : IPersona
{
    protected string LastName { get; set; }
    protected DateTime DateOfBirth { get; set; }

    public Person(string lastName, DateTime dateOfBirth)
    {
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Last Name: {LastName}");
        Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
    }

    public int CalculateAge()
    {
        DateTime now = DateTime.Now;
        int age = now.Year - DateOfBirth.Year;
        if (now.Month < DateOfBirth.Month || (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day))
            age--;
        return age;
    }
}

// Похідний клас - Абітурієнт
class Applicant : Person, IDotNetInterface
{
    public string Faculty { get; set; }

    public Applicant(string lastName, DateTime dateOfBirth, string faculty)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Faculty: {Faculty}");
    }

    public void DotNetMethod()
    {
        Console.WriteLine(".NET Interface Method implemented by Applicant");
    }

    public void Dispose()
    {
        Console.WriteLine("Applicant object disposed");
    }
}

// Похідний клас - Студент
class Student : Person, IDotNetInterface
{
    public string Faculty { get; set; }
    public int Course { get; set; }

    public Student(string lastName, DateTime dateOfBirth, string faculty, int course)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
        Course = course;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Faculty: {Faculty}");
        Console.WriteLine($"Course: {Course}");
    }

    public void DotNetMethod()
    {
        Console.WriteLine(".NET Interface Method implemented by Student");
    }

    public void Dispose()
    {
        Console.WriteLine("Student object disposed");
    }
}

// Похідний клас - Викладач
class Professor : Person, IDotNetInterface
{
    public string Faculty { get; set; }
    public string Position { get; set; }
    public int Experience { get; set; }

    public Professor(string lastName, DateTime dateOfBirth, string faculty, string position, int experience)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
        Position = position;
        Experience = experience;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Faculty: {Faculty}");
        Console.WriteLine($"Position: {Position}");
        Console.WriteLine($"Experience: {Experience} years");
    }

    public void DotNetMethod()
    {
        Console.WriteLine(".NET Interface Method implemented by Professor");
    }

    public void Dispose()
    {
        Console.WriteLine("Professor object disposed");
    }
}

class Program
{
    static void Main(string[] args)
    {
        const int n = 3; // Кількість персон

        Person[] people = new Person[n];
        people[0] = new Applicant("Smith", new DateTime(2000, 5, 10), "Computer Science");
        people[1] = new Student("Johnson", new DateTime(1998, 12, 25), "Mathematics", 3);
        people[2] = new Professor("Williams", new DateTime(1975, 8, 15), "Physics", "Associate Professor", 15);

        Console.WriteLine("All people:");
        foreach (var person in people)
        {
            person.DisplayInfo();
            Console.WriteLine($"Age: {person.CalculateAge()} years\n");
        }

        Console.WriteLine("People within age range 20-30:");
        var peopleInRange = people.Where(p => p.CalculateAge() >= 20 && p.CalculateAge() <= 30);
        foreach (var person in peopleInRange)
        {
            person.DisplayInfo();
            Console.WriteLine($"Age: {person.CalculateAge()} years\n");
        }
    }
}
