using System;
using Microsoft.VisualBasic;

public sealed class EntryPoint
{
    private static bool canQuitApplication = false;

    public static void Main()
    {
        ProjectLoopPattern loop = new();

        DataBase dataBase = new();

        Item axe = new Item
        {
            ID = 21234513,
            Name = "Axe",
            Description = "The legendary axe!"
        };

        Item sword = new Item
        {
            ID = 21234513,
            Name = "Sword",
            Description = "The low level sword!"
        };

        Putan katrin = new Putan()
        {
            Name = "Katrin",
            Age = 18
        };

        Putan patrik = new Putan()
        {
            Name = "Patric",
            Age = 13
        };

        dataBase.Items.Add(axe);
        dataBase.Items.Add(sword);

        dataBase.Putans.Add(katrin);
        dataBase.Putans.Add(patrik);

        loop.Update(() =>
        {
            var input = Console.ReadLine(); // Get intut

            // Is Application Quit?
            if (input == "0")
                loop.QuitApplication();

            // Наш код для выполнения
            {
                Foreach();
                Console.WriteLine();
                Linq();
            }

            Console.WriteLine(input); // Output input

            void Foreach()
            {
                foreach (var item in dataBase.Items)
                {
                    Console.Write("Item: ");
                    Console.WriteLine($"ID:{item.ID} Name: {item.Name} Description:{item.Description}");
                }

                foreach (var person in dataBase.Putans)
                {
                    Console.Write("Personal: ");
                    Console.WriteLine($"Name: {person.Name} Age:{person.Age}");
                }
            }

            void Linq()
            {
                // v1
                dataBase.Items
                    .Where(item => item.Name != "Axe")
                    .ToList()
                    .ForEach(item =>
                    {
                        Console.Write("Item: ");
                        Console.WriteLine($"ID:{item.ID} Name: {item.Name} Description:{item.Description}");
                    });

                // v 2
                dataBase.Putans.ForEach(person =>
                {
                    Console.Write("Personal: ");
                    Console.WriteLine($"Name: {person.Name} Age:{person.Age}");
                });
            }
        });
    }

    private static void Example_1() // ExampleActionSyntaxes.cs
    {
        ExampleActionSyntaxes exampleActionSyntaxes = new();
        exampleActionSyntaxes.RunExample();
    }
}

public sealed class DataBase // Model
{
    // Одновременно поле, метод Get, метод Set. Или опционально настраиваемо по отдельности или то или другое.
    public List<Item> Items { get; private set; } = new();
    public List<Putan> Putans { get; private set; } = new();

    // Old Property version.
    private List<Item> _Items;
    public List<Item> GetItems() => Items;
    public void SetItems(Item item) => Items.Add(item);

    // Old Property version.
    private List<Putan> _Putans;
    public List<Putan> GetPutans() => Putans;
    public void SetPutan(Putan person) => Putans.Add(person);
}

public class Putan // Model - Data
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Item // Model - Data
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}