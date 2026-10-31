using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float_Input_in_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
            str = Console.ReadLine();
            float num = float.Parse(str);
            Console.Write("You entered number: ");
            Console.WriteLine(num);
            Console.ReadKey();
        }
    }
}
