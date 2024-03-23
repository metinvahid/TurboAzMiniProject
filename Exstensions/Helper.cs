using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turboazmini.Exstensions;

namespace Turboazmini.Extensions
{
    public static class Helper
    {
        public static void Print(string message, MessageType type = MessageType.Success)
        {
            var backupColor = Console.ForegroundColor;
            var backupBgColor = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine(message);

            Console.ForegroundColor = backupColor;

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
        public static void Printline(string message, MessageType type = MessageType.Success)
        {
            Print($"{message}\n", type);

        }

        public static T ChooseOption<T>(string caption, string? message = null)
    where T : Enum
        {
            if (string.IsNullOrEmpty(message))
            {
                message = "An option must be chosen";
            }

            Type type = typeof(T);
            var backupColor = Console.ForegroundColor;



            Console.WriteLine("==========CHOOSE OPTION==========");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in Enum.GetValues(type))
            {
                Console.WriteLine($"{Convert.ChangeType(item, Enum.GetUnderlyingType(type))}. {item}");
            }
            Console.ForegroundColor = backupColor;
            Console.WriteLine("=================================");


        l1:
            Print(caption);
            if (!(Enum.TryParse(type, Console.ReadLine(), ignoreCase: true, out object? value)) || !(Enum.IsDefined(type, value!)))
            {
                Printline(message, MessageType.Error);
                goto l1;
            }

            return (T)value;
        }


    }
}