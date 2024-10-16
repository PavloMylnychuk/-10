using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private List<T> elements;
    private int currentIndex;

    public ListyIterator(params T[] items)
    {
        elements = new List<T>(items);
        currentIndex = 0;
    }

    public bool Move()
    {
        if (HasNext())
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return currentIndex < elements.Count - 1;
    }

    public void Print()
    {
        if (elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(elements[currentIndex]);
    }

    public void PrintAll()
    {
        foreach (var item in elements)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        ListyIterator<string> iterator = null;
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var commands = input.Split();

            if (commands[0] == "Create")
            {
                iterator = new ListyIterator<string>(commands[1..]);
            }
            else if (commands[0] == "Move")
            {
                Console.WriteLine(iterator.Move());
            }
            else if (commands[0] == "Print")
            {
                try
                {
                    iterator.Print();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (commands[0] == "HasNext")
            {
                Console.WriteLine(iterator.HasNext());
            }
            else if (commands[0] == "PrintAll")
            {
                try
                {
                    iterator.PrintAll();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
