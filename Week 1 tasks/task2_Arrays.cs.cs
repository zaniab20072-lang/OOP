using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter Numbers : ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int largest = numbers[0];
            if(largest < numbers[1])
            {
                largest = numbers[1];
            }
            if (largest < numbers[2])
            {
                largest = numbers[2];
            }
            Console.WriteLine("The largest number is: " );
            Console.WriteLine(largest);
            Console.ReadKey();
        }
    }
}
