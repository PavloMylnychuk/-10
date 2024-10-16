using System;
using System.Collections.Generic;

public class Pet
{
    public string Name { get; }
    public int Age { get; }
    public string Kind { get; }

    public Pet(string name, int age, string kind)
    {
        Name = name;
        Age = age;
        Kind = kind;
    }
}

public class Clinic
{
    public string Name { get; }
    private Pet[] rooms;
    private int capacity;

    public Clinic(string name, int roomsCount)
    {
        if (roomsCount % 2 == 0)
            throw new InvalidOperationException();

        Name = name;
        rooms = new Pet[roomsCount];
        capacity = roomsCount;
    }

    public bool AddPet(Pet pet)
    {
        for (int i = 0; i < capacity; i++)
        {
            int roomIndex = (capacity / 2) + (i % (capacity / 2)) * (i % 2 == 0 ? -1 : 1);
            if (rooms[roomIndex] == null)
            {
                rooms[roomIndex] = pet;
                return true;
            }
        }
        return false;
    }

    public bool ReleasePet()
    {
        for (int i = 0; i < capacity; i++)
        {
            int roomIndex = (capacity / 2) + (i % (capacity / 2)) * (i % 2 == 0 ? 1 : -1);
            if (rooms[roomIndex] != null)
            {
                rooms[roomIndex] = null;
                return true;
            }
        }
        return false;
    }

    public bool HasEmptyRooms()
    {
        foreach (var room in rooms)
        {
            if (room == null) return true;
        }
        return false;
    }

    public void PrintRoom(int room)
    {
        if (rooms[room - 1] == null)
        {
            Console.WriteLine("Room empty");
        }
        else
        {
            Console.WriteLine($"{rooms[room - 1].Name} {rooms[room - 1].Age} {rooms[room - 1].Kind}");
        }
    }

    public void PrintAll()
    {
        foreach (var room in rooms)
        {
            if (room == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine($"{room.Name} {room.Age} {room.Kind}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var pets = new Dictionary<string, Pet>();
        var clinics = new Dictionary<string, Clinic>();

        for (int i = 0; i < n; i++)
        {
            var commandParts = Console.ReadLine().Split();
            var command = commandParts[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        if (commandParts[1] == "Pet")
                        {
                            var pet = new Pet(commandParts[2], int.Parse(commandParts[3]), commandParts[4]);
                            pets[commandParts[2]] = pet;
                        }
                        else if (commandParts[1] == "Clinic")
                        {
                            var clinic = new Clinic(commandParts[2], int.Parse(commandParts[3]));
                            clinics[commandParts[2]] = clinic;
                        }
                        break;
                    case "Add":
                        var petName = commandParts[1];
                        var clinicName = commandParts[2];
                        Console.WriteLine(clinics[clinicName].AddPet(pets[petName]));
                        break;
                    case "Release":
                        Console.WriteLine(clinics[commandParts[1]].ReleasePet());
                        break;
                    case "HasEmptyRooms":
                        Console.WriteLine(clinics[commandParts[1]].HasEmptyRooms());
                        break;
                    case "Print":
                        if (commandParts.Length > 2)
                        {
                            clinics[commandParts[1]].PrintRoom(int.Parse(commandParts[2]));
                        }
                        else
                        {
                            clinics[commandParts[1]].PrintAll();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
