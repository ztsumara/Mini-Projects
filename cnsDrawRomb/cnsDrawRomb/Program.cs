int flag = 0;
while (flag != 1)
{
    Console.Write("count of string: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int space = n - 1;

    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < space; j++)
        {
            Console.Write(" ");
        }

        for (int j = 0; j <= i; j++)
        {
            Console.Write("* ");
        }

        Console.WriteLine();
        space--;
    }

    space = 0;

    for (int i = n - 1; i >= 0; i--)
    {
        for (int j = 0; j < space; j++)
        {
            Console.Write(" ");
        }

        for (int j = 0; j <= i; j++)
        {
            Console.Write("* ");
        }

        Console.WriteLine();
        space++;
    }
    Console.WriteLine("Repeat? Yes/No");
    string? repeat = Console.ReadLine();
    if (repeat.ToLower() == "no")
    {
        flag = 1;
    }
    else if (repeat.ToLower() != "yes")
    {
        Console.WriteLine("bad value");
        flag = 1;

    }
}