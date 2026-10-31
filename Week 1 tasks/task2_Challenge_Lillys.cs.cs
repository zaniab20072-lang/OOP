using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Lillys.cs
{
    internal class Program
    {
        static void Buying(int age, int WM, int TP)
        {
            int money = 0, toy = 0, gift = 10;
            int TotalMoney = 0;
            for (int i = 0; i < age; i++)
            {
                if (i % 2 == 0)
                {
                    money = money + gift - 1;
                    gift = gift + 10;
                }
                else
                {
                    toy = toy + 1;
                }
            }
                TotalMoney = money + (toy * TP);
                if(TotalMoney >= WM)
                {
                    Console.WriteLine("Yes! You can buy the washing machine.");
                Console.WriteLine(TotalMoney - WM);
                }
                else
                {
                    Console.WriteLine("No! You can't buy the washing machine.");
                Console.WriteLine(WM - TotalMoney);
            }
        }
        static void Main(string[] args)
        {
            int age, WM, TP;
            Console.Write("Enter your age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter your washing machine price: ");
            WM = int.Parse(Console.ReadLine());
            Console.Write("Enter your Toy price : ");
            TP = int.Parse(Console.ReadLine());
            Buying(age, WM, TP);
        }
    }
}
