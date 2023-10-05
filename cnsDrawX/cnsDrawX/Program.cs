Console.WriteLine("Введите размер буквы X:");
int size = int.Parse(Console.ReadLine());

for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        if (i == j || i == size - 1 - j)
        {
            Console.Write("\\\\");
        }
        else
        {
            Console.Write(" ");
        }
    }
    Console.WriteLine();
}