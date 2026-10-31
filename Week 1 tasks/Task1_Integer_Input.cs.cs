using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integer_Input_in_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
            str = Console.ReadLine();
            int num = int.Parse(str);
            Console.Write("You entered number: ");
            Console.WriteLine(num);
            Console.ReadKey();
        }
    }
}
