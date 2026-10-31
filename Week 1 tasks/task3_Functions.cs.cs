using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.cs
{
    internal class Program
    {
        static int sum(int n1, int n2)
        {
            return n1 + n2;
        }
        static void Main(string[] args)
        {
            int n1, n2;
            Console.WriteLine("Enter first number: ");
            n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second Number : ");
            n2 = int.Parse(Console.ReadLine());
            int result = sum(n1, n2);
            Console.Write("The sum of numbers : ");
            Console.WriteLine(result);
            Console.ReadKey();


        }
    }
}
