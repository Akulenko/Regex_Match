using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            string way = "";
            string [] regex = { "^(25[0-5]|2[0-4][0-9]|[0-1][0-9]{2}|[0-9]{2}|[0-9])(\\.(25[0-5]|2[0-4][0-9]|[0-1][0-9]{2}|[0-9]{2}|[0-9])){3}$", "^(https?)?(:\\/\\/)?(www)?.([A-Za-z1-9]+)\\.([a-z]{2,3})(\\/)?(\\.[a-z]{2,3})?$" };
             
            Console.Write("What do you want check: IP-address (enter 1) or URL-address (enter 2) : ");
            n = Convert.ToInt32(Console.ReadLine());
            while (way == "")
            {
                Console.Write("Enter the way to the text file: ");
                way = Console.ReadLine();
            }
            if (n == 1)
            {
                reger_match(way, regex[0]);
            }
            if (n == 2)
            {
                reger_match(way, regex[1]);
            }
        }

        public static void reger_match(string pathToTxtFileWithDataList, string regex)
        {
            string[] list = new string[100];
            int i = 0;

         
            try
            {
                StreamReader StreamReader = new StreamReader(pathToTxtFileWithDataList);
                while (!StreamReader.EndOfStream)
                {
                    list[i] = StreamReader.ReadLine();
                    i++;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Could not find file", e);
            }
            FileInfo file = new FileInfo(pathToTxtFileWithDataList.Substring(0, pathToTxtFileWithDataList.Length - 4) + "_result.txt");
            StreamWriter w = file.CreateText();
            Regex regex1 = new Regex(regex);
            Console.WriteLine(regex1);
            for(i = 0; i <= list.Length; i++)
            {
                if (list[i] == null) break;
                if (list[i] != null)
                {
                    if (regex1.IsMatch(list[i]))
                    {
                        w.WriteLine(list[i] + "\t match \n");
                        Console.WriteLine("есть совпадение {0} num= {1}", list[i], i);
                    }
                    else
                    {
                        w.WriteLine(list[i] + "\t unmatch \n");
                        Console.WriteLine("нет совпадение {0} num= {1}", list[i], i);
                    }
                }
                   
            }
            Console.WriteLine("num of list {0} and num of i={1}", list.Length, i);
            w.Close();
            Console.WriteLine();        
        }
    }
}
