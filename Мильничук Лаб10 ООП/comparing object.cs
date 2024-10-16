using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    public string Name { get; }
    public int Age { get; }
    public string City { get; }

    public Person(string name, int age, string city)
    {
        Name = name;
        Age = age;
        City = city;
    }

    public int CompareTo(Person other)
    {
        int nameComparison = Name.CompareTo(other.Name);
        if (nameComparison != 0) return nameComparison;
        int ageComparison = Age.CompareTo(other.Age);
        if (ageComparison != 0) return ageComparison;
        return City.CompareTo(other.City);
    }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var parts = input.Split();
            var person = new Person(parts[0], int.Parse(parts[1]), parts[2]);
            people.Add(person);
        }

        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= people.Count)
        {
            Console.WriteLine("No matches");
            return;
        }

        var targetPerson = people[index];
        int equalCount = people.Count(p => p.CompareTo(targetPerson) == 0);
        int notEqualCount = people.Count - equalCount;

        Console.WriteLine($"{equalCount} {notEqualCount} {people.Count}");
    }
}
