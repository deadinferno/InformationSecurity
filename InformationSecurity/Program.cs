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
using System.Collections.Generic;
using System.Diagnostics;

namespace InformationSecurity
{
    class Program
    {
        static void Main()
        {
            Stopwatch watch = new Stopwatch();
            List<char> keyRow = new List<char>();
            keyRow.AddRange("абвгдежзийклмнопрстуфхцчшщъыьэюя");
            List<char>[] table = new List<char>[keyRow.Count];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new List<char>();
                table[i].AddRange(keyRow);
            }
        }
    }
}
