/*
 * Лихачев Юра
 * 2. Разработать методы для решения следующих задач. Дано сообщение:
 * а) Вывести только те слова сообщения, которые содержат не более чем n букв;
 * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
 * в) Найти самое длинное слово сообщения;
 * г) Найти все самые длинные слова сообщения.
 * Постараться разработать класс MyString.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace MyStringClass
{
    class MyString
    {
        // По ссылке не передаётся!
        static string[] ShorterThan(int iMaxLength, ref string rsInputText)
        {
            MatchCollection resultWords;
            //Regex mustMatch = new Regex("\b[а-я]{1," + iMaxLength +"}", RegexOptions.IgnoreCase);
            string pew = rsInputText;
            Regex mustMatch = new Regex("[а-я]+");
            //resultWords = mustMatch.Matches(rsInputText);
            resultWords = mustMatch.Matches(pew);
            string[] asResultString = new string[resultWords.Count];
            Console.WriteLine(mustMatch.IsMatch(rsInputText));
            resultWords.CopyTo(asResultString, 0);
            return asResultString;
        }

        static void Main(string[] args)
        {
            string sInputText = File.ReadAllText("InputText.txt", Encoding.GetEncoding(65001));
            string[] asFilteredData;

            asFilteredData = ShorterThan(6, ref sInputText);

            foreach(string sWord in asFilteredData)
            {
                Console.WriteLine(sWord);
            }

            Console.ReadKey();
        }
    }
}
