using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace InformationSecurity
{
    class Program
    {
        static void Main()
        {
            bool isRunning;
            do
            {
                // Исходное ключевое слово (верхняя строка)
                List<char> keyRow = new List<char>();
                keyRow.AddRange("ё1234567890-=йцукенгшщзхъфывапролджэ\\ячсмитьбю.Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭ/ЯЧСМИТЬБЮ, ");
                keyRow.Sort();

                // Последовательность ключей
                List<char>[] table = new List<char>[keyRow.Count];
                table = FillUpTable(table, keyRow);
                //FormattedTablePrint(table, keyRow.Count);

                // Сообщение
                List<char> message = new List<char>();

                // Символьный ключ
                List<char> symbolicKey = new List<char>();

                // Ввод исходного сообщения
                Console.Write("#ВВОД СООБЩЕНИЯ#\n> ");
                message.AddRange(Convert.ToString(Console.ReadLine()));

                // Ввод ключа
                Console.Write("\n#ВВОД КЛЮЧА#\n> ");
                symbolicKey.AddRange(Convert.ToString(Console.ReadLine()));

                // Циклически дополняем ключ
                symbolicKey = FillUpKey(symbolicKey, message.Count);

                // Числовой ключ
                List<int> numericKey = FillUpNumericKey(symbolicKey, keyRow);

                // Шифрованное сообщение
                List<char> encryptedMessage = EncryptMessage(message, numericKey, table, keyRow);

                // Дешифрованное сообщение
                List<char> decryptedMessage = DecryptedMessage(encryptedMessage, numericKey, table, keyRow);

                // Вывод шифрованного сообщения
                Console.Write("\nШифрованное сообщение: " + ListToString(encryptedMessage));

                // Вывод дешифрованного сообщения
                Console.Write("\nДешифрованное сообщение: " + ListToString(decryptedMessage) + "\n\n");

                // Запрос на рестарт
                isRunning = IsProgramShouldRestart();
            } while (isRunning);
        }
        
        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="key"></param>
        /// <param name="table"></param>
        /// <param name="keyRow"></param>
        /// <returns></returns>
        static List<char> EncryptMessage(List<char> msg, List<int> key, List<char>[] table, List<char> keyRow)
        {
            List<char> encMsg = new List<char>();
            for (int i = 0; i < msg.Count; i++)
            {
                char temp1 = msg[i];
                int temp2 = key[i];
                encMsg.Add(table[temp2][keyRow.BinarySearch(temp1)]);
            }
            return encMsg;
        }

        /// <summary>
        /// Дешифрование
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="key"></param>
        /// <param name="table"></param>
        /// <param name="keyRow"></param>
        /// <returns></returns>
        static List<char> DecryptedMessage(List<char> msg, List<int> key, List<char>[] table, List<char> keyRow)
        {
            List<char> decMsg = new List<char>();
            for (int i = 0; i < msg.Count; i++)
            {
                char temp1 = msg[i];
                int temp2 = key[i];
                decMsg.Add(keyRow[table[temp2].IndexOf(temp1)]);
            }
            return decMsg;
        }
        
        /// <summary>
        /// Генерирует последовательность ключей опираясь на исходное ключевое слово
        /// </summary>
        /// <param name="table"></param>
        /// <param name="keyRow"></param>
        /// <returns></returns>
        static List<char>[] FillUpTable(List<char>[] table, List<char> keyRow)
        {
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new List<char>();
                table[i].AddRange(keyRow);
                for (int j = 0; j < i; j++)
                {
                    char temp = table[i][0];
                    table[i].RemoveAt(0);
                    table[i].Add(temp);
                }
            }
            return table;
        }

        /// <summary>
        /// Циклически заполняет ключ до заданного размера
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mSize"></param>
        /// <returns></returns>
        static List<char> FillUpKey(List<char> key, int mSize)
        {
            int forKeyCycleCounter = 0;
            int keyFixedSize = key.Count;

            for (int i = 0; i < (mSize - keyFixedSize); i++)
            {
                char temp = key[forKeyCycleCounter];
                key.Add(temp);
                forKeyCycleCounter++;
                if (forKeyCycleCounter == keyFixedSize)
                    forKeyCycleCounter = 0;
            }

            return key;
        }

        /// <summary>
        /// Перевод индексов символьного ключа в числовой ключ
        /// </summary>
        /// <param name="symbolicKey"></param>
        /// <param name="keyRow"></param>
        /// <returns></returns>
        static List<int> FillUpNumericKey(List<char> symbolicKey, List<char> keyRow)
        {
            List<int> key = new List<int>();
            for (int i = 0; i < symbolicKey.Count; i++)
            {
                key.Add(keyRow.IndexOf(symbolicKey[i]));
            }
            return key;
        }

        /// <summary>
        /// Форматированный вывод последовательности ключей
        /// </summary>
        /// <param name="table"></param>
        /// <param name="count"></param>
        static void FormattedTablePrint(List<char>[] table, int count)
        {
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write(String.Format("[{0, 1}]", table[i][j]));
                }
            }
        }

        /// <summary>
        /// Перевести элементы списка в строку
        /// </summary>
        /// <param name="lst"></param>
        static StringBuilder ListToString(List<char> lst)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < lst.Count; i++)
            {
                str.Insert(i, lst[i]);
            }
            return str;
        }

        /// <summary>
        /// Запрос на перезапуск программы
        /// </summary>
        /// <returns></returns>
        static bool IsProgramShouldRestart()
        {
            bool isRunning;
            bool isInputRight;

            do
            {
                Console.Write("Перезапустить программу?(Д/Н): ");
                List<char> inpStr = new List<char>();
                inpStr.AddRange(Console.ReadLine());
                char input = inpStr[0];
                switch (input)
                {
                    case 'Д':
                        isRunning = true;
                        isInputRight = true;
                        break;
                    case 'д':
                        isRunning = true;
                        isInputRight = true;
                        break;
                    case 'Н':
                        isRunning = false;
                        isInputRight = true;
                        break;
                    case 'н':
                        isRunning = false;
                        isInputRight = true;
                        break;
                    default:
                        isRunning = true;
                        isInputRight = false;
                        break;
                }

                if (!isInputRight)
                {
                    Console.Write("Ошибка, попробуйте снова...");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (!isInputRight);
            Console.Clear();
            return isRunning;
        }
    }
}

/*
 * var result = String.Join(", ", names.ToArray());
 * 
 * keyRow.AddRange("абвгдежзийклмнопрстуфхцчшщъыьэюя ");
 * 
 * абракадабр
 * нжэечесеох
 * 
 * КАКОЕ-ТО ПРЕДЛОЖЕНИЕ
 * КЛЮЧЕГКЛЮЧЕГКЛЮЧЕГКЛ
 * 
 * Stopwatch watch = new Stopwatch();
 * 
 * formattedTablePrint(table, keyRow.Count);
 * watch.Start();
 * watch.Stop();
 * Console.Write(String.Format("[{0, 2}]", matrix[i, j]));
 * 
 * 
 * 10.	Зашифровать и расшифровать сообщение, содержащее любые символы кодовой таблицы ASCII, 
 * с помощью шифра Вижинера. Длина ключа должна быть не менее 5 символов.
 *
 * 
 * Таблица Вижинера используется для зашифрования и расшифрования. Она имеет два входа:
 * - верхнюю строку символов, используемую для считывания очередной буквы исходного открытого текста;
 * - крайний левый столбец ключа.
 * Последовательность ключей образуется из кодов (числовых зна-чений) букв ключевого слова. При шифровании 
 * исходного сообщения его выписывают в строку, а под ним записывают ключевое слово (или фразу). Если ключ 
 * оказался короче сообщения, то его циклически по-вторяют. В процессе шифрования находят в верхней строке 
 * таблицы очередную букву исходного текста и в левом столбце очередное зна-чение ключа. Очередная буква шифртекста 
 * находится на пересечении столбца, определяемого шифруемой буквой, и строки, определяемой числовым значением ключа.
 * Например, применяя в качестве ключа слово «АРБУЗЫ», получа-ем для исходного сообщения «КРАСНАЯ ПЛОЩАДЬ» следующий шифртекст: «КАБДФЫЯ  ЯМБАЫДМ»
 * 
 */
