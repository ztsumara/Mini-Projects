namespace cnsGenDice
{
    internal class Program
    {
        public static (int[], int) RollCube(int countOfCubes, int countOfSides = 6, int[] sidesValues = null)
        {
            Random random = new Random();
            int[] results = new int[countOfCubes];

            if (sidesValues == null)
            {
                sidesValues = new int[countOfSides];
                for (int i = 0; i < countOfSides; i++)
                {
                    sidesValues[i] = i + 1;
                }
            }

            for (int i = 0; i < countOfCubes; i++)
            {
                int randomIndex = random.Next(countOfSides);
                results[i] = sidesValues[randomIndex];
            }

            return (results, countOfCubes);
        }

        static void Main(string[] args)
        {
            (int[] results, int numOfDice) = RollCube(3, 4, new int[] { 1, 2, 3, 4});
            Console.WriteLine($"Результаты подбрасывания {numOfDice} кубиков: {string.Join(", ", results)}");
        }
    }
}