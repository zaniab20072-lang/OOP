using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Intro.cs
{
    
    internal class Program
    {
        public class Student
        {
            public string Name;
            public float EcatMark;
            public float FscMark;
            public float MatricMark;
            public float Aggregate;
        }
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = "Ali";
            student.EcatMark = 150;
            student.FscMark = 800;
            student.MatricMark = 1050;

            Student student2 = new Student();
            student2.Name = "Ahmed";

            Console.WriteLine(student2.Name);
            Console.WriteLine(student.Name);
            Console.ReadKey();
        }
    }
}
