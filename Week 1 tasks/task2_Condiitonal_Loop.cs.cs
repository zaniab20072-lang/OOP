using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional_loop.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, sum = 0;
            Console.Write("Enter Number ");
            num = int.Parse(Console.ReadLine());
            while(num != 0)
            {
                sum += num;
                Console.Write("Enter Number ");
                num = int.Parse(Console.ReadLine());
            }
            Console.Write("The total sum is ");
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
