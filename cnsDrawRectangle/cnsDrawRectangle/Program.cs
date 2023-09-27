int flag = 0;
while (flag != 1)
{
    Console.Write("Enter width: ");

    int width = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter height: ");
    int height = Convert.ToInt32(Console.ReadLine());

    Console.Write("Do you want to fill? Yes/No ");
    string? answer = Console.ReadLine();
    bool fill = false;
    if (answer.ToLower() == "no")
    {
        fill = false;
    }
    else
    {
        fill = true;
    }



    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (fill || i == 0 || i == height - 1 || j == 0 || j == width - 1)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
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