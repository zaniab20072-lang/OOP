using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_task1.cs
{
    public class Dog
    {
        public string Name;
        public int age;
        public void Bark()
        {
            Console.WriteLine($"{Name} is barking.");
        }
        public void Eat(string food)
        {
            Console.WriteLine($"{Name} is eating {food}.");
        }
        public int ConvertToHumanYears()
        {
            return age * 7; //assuming 1 dog year = 7 human years
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.Name = "Buddy";
            myDog.age = 3;

            myDog.Bark();
            myDog.Eat("dog food");

            int humanYears = myDog.ConvertToHumanYears();

            Console.WriteLine($"{myDog.Name} is {humanYears} human years old.");
            Console.ReadKey();
        }
    }
}
