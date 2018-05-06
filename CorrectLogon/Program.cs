/* 
 * Лихачев Юра
 * 1. Создать программу, которая будет проверять корректность ввода логина.
 * Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, 
 * и при этом цифра не может быть первой.
 * а) без использования регулярных выражений;
 * б) ** с использованием регулярных выражений.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CorrectLogon
{
    class Program
    {
        // Requiriments checking without regular expressions
        static bool GenericLoginCheck(string sLogin, int iMinLength, int iMaxLength)
        {
            bool bPasswordLengthReqs;
            bool bPasswordConsystencyReqs = true;

            bPasswordLengthReqs = (sLogin.Length >= iMinLength && sLogin.Length <= iMaxLength) ? true : false;

            foreach(char cCharacter in sLogin.ToCharArray())
                bPasswordConsystencyReqs = bPasswordConsystencyReqs && Char.IsLetterOrDigit(cCharacter);

            if (Char.IsDigit(sLogin[0]))
                bPasswordConsystencyReqs = false;

            return bPasswordLengthReqs && bPasswordConsystencyReqs;
        }

        // Requiriments checking with regular expressions
        static bool RegexLoginCheck(string sLogin, int iMinLength, int iMaxLength)
        {
            Regex mustNotMatch = new Regex("[^0-9a-z]|.{" + (iMaxLength + 1) + ",}", RegexOptions.IgnoreCase);  // If not digit\letter or if too long
            Regex mustMatch = new Regex("^[^0-9].{" + (iMinLength > 0 ? iMinLength - 1 : 0) + "}");             // If longer or equal than Min Length and starts from letter

            return !mustNotMatch.IsMatch(sLogin) && mustMatch.IsMatch(sLogin);
        }


        static void Main(string[] args)
        {
            const int MIN_LENGTH = 2;
            const int MAX_LENGTH = 10;

            string sLogin;

            const string GENERIC_METHOD_TEXT = "Классический метод проверки логина";
            const string REGEX_METHOD_TEXT = "Метод проверки с использованием регулярных выражений";

            bool bSelectedMethod = true;     // If true - "generic method" will be used. And "Regexp method" if false
            ConsoleKeyInfo key;              // Pressed key storing purposes

            // Introduction
            Console.Title = "Login test 1.0";
            Console.WriteLine("Приложение позволяет проверить введенный логин на соответствие внутренним требованиям." +
                              "\nДлина должна составлять от {0} до {1} символов, являющихся буквами или цифрами, не может начинаться с цифры." +
                              "\nЧтобы начать - выберите метод для проверки с помощью клавиш со стрелками." +
                              "\nВверх или вниз для пролистывания списка, Enter для выбора:", MIN_LENGTH, MAX_LENGTH);

            // Method selection part
            Console.ForegroundColor = ConsoleColor.Cyan;
            do
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(bSelectedMethod ? GENERIC_METHOD_TEXT : REGEX_METHOD_TEXT);

                key = Console.ReadKey();

                bSelectedMethod = (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow) ? !bSelectedMethod : bSelectedMethod;

            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.ResetColor();


            // Executing of chosen method
            switch (bSelectedMethod)
            {
                case true:
                    Console.Write("Пожалуйста, введите желаемый логин: ");

                    while (!GenericLoginCheck(sLogin = Console.ReadLine(), MIN_LENGTH, MAX_LENGTH))
                    {
                        Console.Write("Введенный логин не соответствует требованиям. Повторите попытку: ");
                    }

                    Console.WriteLine("Логин {0} зарегистрирован успешно.", sLogin);

                    Console.ReadKey();
                    break;
                case false:
                    Console.Write("Пожалуйста, введите желаемый логин: ");

                    while (!RegexLoginCheck(sLogin = Console.ReadLine(), MIN_LENGTH, MAX_LENGTH))
                    {
                        Console.Write("Введенный логин не соответствует требованиям. Повторите попытку: ");
                    }

                    Console.WriteLine("Логин {0} зарегистрирован успешно.", sLogin);
                    Console.ReadKey();
                    break;
            }

        }
    }
}
