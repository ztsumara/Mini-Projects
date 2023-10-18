Console.Write("введите ширину ");
int h = Convert.ToInt32(Console.ReadLine());
Console.Write("\nвыберете узор: лопата (1), крест (2) ");
string? or = Console.ReadLine();
Console.Write("\nвыберете символ ");
string? p = Console.ReadLine();
if (p == "")
{
    p = "█";
};

if (or == "1")
{
    char ch = char.Parse(p);
    double f1 = h / 3 + 1;
    int f2 = h / 3;
    int f3 = h - (h / 3);
    for (int j = 0; j < h / 3 + 1; j++)
    {
        for (int i = 1; i < f1; i++)
        {
            ConsoleColor color = (ConsoleColor)(i % 16);
            Console.ForegroundColor = color;
            Console.Write(ch);
        }
        for (int i1 = f2; i1 < f3; i1++)
        {
            if (f1 < 0)
                f1 = f1 * (-1);
            ConsoleColor color1 = (ConsoleColor)(f1 % 16);
            Console.ForegroundColor = color1;
            Console.Write(ch);
        }
        for (int i2 = f2; i2 > 0; i2--)
        {
            ConsoleColor color = (ConsoleColor)(i2 % 16);
            Console.ForegroundColor = color;
            Console.Write(ch);
        }
        f1--;
        f2--;
        f3++;
        Console.WriteLine();
    }
    Console.ResetColor();
}