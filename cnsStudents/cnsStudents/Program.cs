namespace cnsStudents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student x = new();
            x.name = "Иван";
            x.surname = "Петров";
            x.age = 19;
            Console.WriteLine(x.GetFullName());
        }
    }
}