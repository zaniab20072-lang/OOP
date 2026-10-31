using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_While_loop.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, sum = 0;
            do
            {
                Console.WriteLine(" Enter Number : ");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            } while (num != -1);
            sum = sum + 1;
            Console.WriteLine(" Sum of Numbers : " );
            Console.Write(sum);
            Console.ReadKey();
        }
    }
}
