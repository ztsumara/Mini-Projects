namespace cnsStudents
{
    internal class Student
    {
        public string name { get; internal set; }
        public string surname { get; internal set; }
        public int age { get; internal set; }

        internal string GetFullName()
        {
            return $"{name} {surname} ({age})";
        }
    }
}