using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turboazmini.Exstensions
{
    public static class Helper
    {
        public static void Print(string message)
        {
            var backupColor = Console.ForegroundColor;
            var backupBgColor = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(message);

            Console.ForegroundColor = backupColor;
            Console.BackgroundColor = backupBgColor;
        }

        public static int ReadInt(string caption, string errorMessage)
        {
            var backupColor = Console.ForegroundColor;

        l1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = backupColor;

            string aStr = Console.ReadLine();

            bool state = int.TryParse(aStr, out int a);

            if (!state)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = backupColor;
                goto l1;
            }

            return a;
        }

        public static string ReadString(string caption, string errorMessage)
        {
            var backupColor = Console.ForegroundColor;

        l1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = backupColor;

            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = backupColor;
                goto l1;
            }

            return value;
        }

        public static double ReadDouble(string caption, string errorMessage)
        {
            var backupColor = Console.ForegroundColor;

        l1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = backupColor;

            string aStr = Console.ReadLine();

            bool state = double.TryParse(aStr, out double a);

            if (!state)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = backupColor;
                goto l1;
            }

            return a;
        }
    }
}
