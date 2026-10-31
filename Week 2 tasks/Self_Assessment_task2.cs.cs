using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_task2.cs
{
    public class Calculator
    {
        public int Operator;
         public int op(int Operator, int num1, int num2)
        {
           if(Operator== 1)
            {
                return num1 + num2;
            }
            else if (Operator == 2)
            {
                return num1 - num2;
            }
            else if (Operator == 3)
            {
                return num1 * num2;
            }
            else if (Operator == 4)
            {
                return num1 / num2;
            }
            else
            {
                return 0;
            }
        }
    }
     
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine("Enter first number:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter operator (1 for addition, 2 for subtraction, 3 for multiplication," +
                " 4 for division):");
            int Operator = int.Parse(Console.ReadLine());
            int result = calculator.op(Operator, num1, num2);
            Console.Write("Result: " );
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
