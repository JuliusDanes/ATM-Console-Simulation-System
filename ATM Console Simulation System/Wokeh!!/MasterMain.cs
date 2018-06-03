using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using ConsoleTables;
using System.Threading.Tasks;
using System.Threading;

namespace Wokeh
{
    class ProgramMain
    {
        static string nokartu = "";
        static string path = (@"" + Environment.CurrentDirectory + "\\");
        
        static void Main()
        {
            Console.Title = "ATM Console Simulation";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool a = true;
            while (a)
            {
                Console.WriteLine("Waiting for card swipe...");
                if (string.IsNullOrWhiteSpace(nokartu))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    nokartu = Console.ReadLine();
                    Console.ResetColor();
                }
                Console.Clear();
                Console.WriteLine("Input PIN");
                string pin = "";
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pin += key.KeyChar;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("*");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pin.Length > 0)
                        {
                            pin = pin.Substring(0, (pin.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                while (key.Key != ConsoleKey.Enter);
                var data = new object[20];
                foreach (string line in File.ReadLines(path + "UserData.txt"))
                {
                    data = line.Split('#');
                    if (nokartu.Equals(data[16]))
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (nokartu.Equals(data[16]) && pin.Equals(data[12]))
                {
                    int NoRek = Convert.ToInt32(data[11]);
                    a = false;
                    if (data[15].Equals("user"))
                    {
                        Console.Clear();
                        MasterMenuUser.User(NoRek);
                    }
                    else
                    {
                        Console.Clear();
                        MasterMenuAdmin.Admin();
                    }
                }
                else
                {
                    Warning("\n\u0416\u0416\u0416 Wrong card or PIN \u0416\u0416\u0416");
                    Console.ReadKey();
                    Console.Clear();
                    nokartu = "";
                }
            }
        }

        public static void Emphasis(string message)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
