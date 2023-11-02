internal class Program
{
    private static void Main(string[] args)
    {

        Student student = new("ivanov", "ivan");

        //Student.get_FullName();
        //Console.WriteLine(StudentExt.get_FullName());
        Console.WriteLine(student.get_FullName());
        

    }
}