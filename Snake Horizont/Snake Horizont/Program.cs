int flag1 = 0;
while (flag1 != 1)
{
    int flag = 0;
    Console.Write("count of string: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.Write("count of column: ");
    int k = Convert.ToInt32(Console.ReadLine());


    Console.Write("clockwise/counterclockwise?: (1/2)");
    string? clock = Console.ReadLine();
    if (clock.ToLower() == "1")
    {
        flag = 1;
    }
    else if (clock.ToLower() == "2")
    {

        flag = 0;

    }
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 0; j < k; j++)
        {
            if (i == 1)
            {
                if (flag == 1)
                {
                    if ((j + 1) % 4 != 0)
                    {

                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    
                }
                else
                {
                    if (j % 4 != 1)
                    {

                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            else if (i == n)
            {
                if (flag == 1)
                {
                    if (j % 4 != 1)
                    {

                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    if ((j + 1) % 4 != 0)
                    {

                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            else
            {
                if(j % 2 != 0) 
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("■");
                }
            }

        }

        Console.WriteLine();
    }
    Console.WriteLine("Repeat? Yes/No");
    string? repeat = Console.ReadLine();
    if (repeat.ToLower() == "no")
    {
        flag1 = 1;
    }
    else if (repeat.ToLower() != "yes")
    {
        Console.WriteLine("bad value");
        flag1 = 1;

    }
}