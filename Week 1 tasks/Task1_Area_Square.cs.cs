using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Area_Square.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Length of Square : ");
            float length = float.Parse(Console.ReadLine());
            float area = length * length;
            Console.Write("Area of Square : " );
            Console.WriteLine(area);
            Console.ReadKey();
        }
    }
}
