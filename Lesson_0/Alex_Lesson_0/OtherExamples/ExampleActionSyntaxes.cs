// Изучаем анонимные функции или лямбда синтаксис.
// => - это лямбда или expression bady

public sealed class ExampleActionSyntaxes
{
    public void RunExample()
    {
        Example_1();

        Example_2();
    }

    private static void Example_1()
    {
        Action method_1 = () =>
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Lambda syntax: {nameof(method_1)}");
            Console.ForegroundColor = default;
        };

        method_1?.Invoke(); // Вызываю код которых хранится в method_1
    }

    private void Example_2()
    {
        int index = 10;

        Action method_2 = Method2;

        method_2?.Invoke(); // Вызываю код которых хранится в method_2

        method_2 -= Method2;


        void Method2()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Default syntax: method_2");
            Console.ForegroundColor = default;
        }
    }
}