using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Handling.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path =  @"D:\OOP Lab\textfile.txt";
            if (File.Exists(path))
            {
                StreamReader firstLab = new StreamReader(path);
                string record;
                while ((record = firstLab.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                firstLab.Close();
            }
            else
            {
                Console.WriteLine("File not Exists ");
            }
        }
    }
}
