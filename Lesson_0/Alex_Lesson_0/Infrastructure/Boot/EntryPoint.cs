using System;

public sealed class EntryPoint
{
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
                Example_2(dataBase);
            }

            Console.WriteLine(input); // Output input
        });
    }

    private static void Example_1() // ExampleActionSyntaxes.cs
    {
        ExampleActionSyntaxes exampleActionSyntaxes = new();
        exampleActionSyntaxes.RunExample();
    }

    private static void Example_2(DataBase dataBase)
    {
        Foreach();
        Console.WriteLine();
        Linq();

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
    }
}