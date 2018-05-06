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

namespace CorrectLogon
{
    class Program
    {
        static bool GenericLoginCheck(string sLogin, int iMinLength, int iMaxLength)
        {
            bool bPasswordLengthReqs;
            bool bPasswordConsystencyReqs = true;

            bPasswordLengthReqs = (sLogin.Length >= iMinLength && sLogin.Length <= iMaxLength) ? true : false;

            foreach(char cCharacter in sLogin.ToCharArray())
                bPasswordConsystencyReqs = bPasswordConsystencyReqs && Char.IsLetterOrDigit(cCharacter);

            return bPasswordLengthReqs && bPasswordConsystencyReqs;
        }


        static void Main(string[] args)
        {
            const int MIN_LENGTH = 2;
            const int MAX_LENGTH = 10;

            string sLogin;
            bool bSelectedMethod = true;
            ConsoleKeyInfo key;

            Console.Title = "Login test 1.0";
            Console.WriteLine("Приложение позволяет проверить введенный логин на соответствие внутренним требованиям." +
                              "\nДлина должна составлять от {0} до {1} символов, являющихся буквами или цифрами." +
                              "\nЧтобы начать - выберите метод для проверки с помощью клавиш со стрелками." +
                              "Вверх или вниз для пролистывания списка, Enter для выбора:", MIN_LENGTH, MAX_LENGTH);
            Console.WriteLine(Console.CursorLeft);
            do
            {
                Console.Write(bSelectedMethod ? "Классический метод проверки логина" : "Метод проверки с использованием регулярных выражений");





                key = Console.ReadKey();
                Console.CursorLeft = 0;

                bSelectedMethod = (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow) ? !bSelectedMethod : bSelectedMethod;

            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(key.GetType());






            Console.Write("Пожалуйста, введите желаемый логин: ");



            while (!GenericLoginCheck(sLogin = Console.ReadLine(), MIN_LENGTH, MAX_LENGTH))
            {
                Console.Write("Введенный логин не соответствует требованиям. Повторите попытку: ");
            }

            Console.WriteLine("Логин {0} зарегистрирован успешно.", sLogin);

            Console.ReadKey();

        }
    }
}
