/* 
10.	Зашифровать и расшифровать сообщение, содержащее любые символы кодовой 
таблицы ASCII, с помощью шифра Вижинера. Длина ключа должна быть не менее 5 символов. 
 */

/*
 Тесты

 // объявляем массив строк
 string[] arr = new string[] {};

 */

using System;

namespace InformationSecurity
{
    class Program
    {
        static void Main(string[] args)
        {

            String str = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            string[] table = new string[str.Length];

            table[0] = "иди нахуй";
            table[1] = "мудила ты бля";
            table[3] = "ууууу тупые дефки";

            //string[] a = new string[str.Length];

            String input;
            System.Console.Write("Введите строку\nВВОД: ");
            input = System.Console.ReadLine();

        }
    }
}
