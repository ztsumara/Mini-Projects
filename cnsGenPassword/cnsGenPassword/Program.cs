using System.Text;

namespace cnsGenPassword
{
    internal class Program
    {
        private const string StsmallLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string StbigLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string StNumbers = "1234567890";
        private const string StspecialSym = "!@#$%^&*()";

        static void GenPassword(int CountOfPasswords,int CountOfSymInPassword, bool numbers, bool smallLetters,bool bigLetters, bool specialSym, string symbols = "")
        {

            StringBuilder password = new StringBuilder();
            StringBuilder characters = new StringBuilder();
            Random random = new Random();
            if(numbers) { 
                characters.Append(StNumbers); 
            }
            if (smallLetters)
            {
                characters.Append(StsmallLetters);
            }
            if (bigLetters)
            {
                characters.Append(StbigLetters);
            }
            if (specialSym)
            {
                characters.Append(StspecialSym);
            }
            if (symbols.Length != 0)
            {
                characters.Append(symbols);
            }

            for (int i = 0; i < CountOfPasswords; i++)
            {
                for (int k = 0; k < CountOfSymInPassword; k++)
                {
                    int index = random.Next(characters.Length);
                    password.Append(characters[index]);
                }
                Console.WriteLine(password);
                password.Clear();
            }
        }
        static void Main(string[] args)
        {
            GenPassword(5, 20, true, true, true, true);
        }
    }
}