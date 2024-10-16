using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class NameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int nameLengthComparison = x.Name.Length.CompareTo(y.Name.Length);
        if (nameLengthComparison != 0) return nameLengthComparison;
        return x.Name[0].ToString().CompareTo(y.Name[0].ToString());
    }
}

public class AgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        SortedSet<Person> nameSet = new SortedSet<Person>(new NameComparer());
        SortedSet<Person> ageSet = new SortedSet<Person>(new AgeComparer());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var person = new Person(input[0], int.Parse(input[1]));
            nameSet.Add(person);
            ageSet.Add(person);
        }

        foreach (var person in nameSet)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }

        foreach (var person in ageSet)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
