using System.Runtime.CompilerServices;

namespace Complex
{
    public class Program
    {
        public static void Main()
        {
            Complex complex = new Complex(3, 2);

            Console.WriteLine($"{complex} + 2j");

            complex += "2j";

            Console.WriteLine($"{complex} + 3"); 

            complex += 3;

            Console.WriteLine($"{complex} - 2j");

            complex -= "2j";

            Console.WriteLine($"{complex} - 3");

            complex -= 3;

            Console.WriteLine($"({complex}) * (-3j)");

            complex *= "-3j";

            Console.WriteLine(complex);
        }
    }
}

