using System;

public sealed class EntryPoint
{
    private static bool canQuitApplication = false;

    public static void Main()
    {
        ProjectLoopPattern loop = new();

        loop.Update(() =>
        {
            var input = Console.ReadLine();
            
            if (input == "0")
                loop.QuitApplication();
            
            Console.WriteLine(input);
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
    public List<Item> Items { get; private set; }
    public List<Putan> Putans { get; private set; }
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