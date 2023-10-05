namespace cnsOOPrectangle
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyRectangle x = new();
            Console.WriteLine(x.GetArea());
            MyRectangle x2 = new(2,3);
            Console.WriteLine(x2.GetArea());
        }
    }
}