using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writing_File.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\OOP Lab\textfile.txt";
            StreamWriter SecondFile = new StreamWriter(path, true);
            Console.WriteLine("Hello this is me Zainab Nice to meet you ");
            SecondFile.Flush();
            SecondFile.Close();
        }
    }
}
