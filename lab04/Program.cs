using System;
using System.Runtime.InteropServices;
using System.Text;

namespace lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 0x0410 ... 0x042F - А ... Я
             * 0x0430 ... 0x044F - а ... я
             * 0x20 - разница */

            string str1 = "some string whatever1";
            string str2 = "string some idi nahuy";
            byte[] bytes = new byte[str1.Length];
            byte[] bytes2 = new byte[str2.Length];


            // заполняем
            for (int i = 0; i < str1.Length; i++)
            {
                bytes[i] = (byte)str1[i];
                bytes2[i] = (byte)str2[i];
                Console.WriteLine("[" + i + "]: " + bytes[i] + "   |   [" + i + "]: " + bytes2[i] +
                    "   |   XOR: " + (byte)(bytes[i] ^ bytes2[i]) + 
                    "   |   BXOR: " + (byte)(bytes[i] ^ ((byte)(bytes[i] ^ bytes2[i]))));
            }


            Console.Read();


            byte a = 5, b = 3, c, d;
            c = (byte)(a ^ b);

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            int test = 0b1111_1111_1111_1111;
            char ch1 = (char)0b0110_0001;
            Console.WriteLine("Result: " + (a ^ c));

            Console.Read();








            const int sz = 1024;
            char[] chars = new char[sz];
            for(int i = 0; i < sz; i++)
            {
                chars[i] = (char)i;
                Console.Write(chars[i]);
                if (i % (16 * 4) == 0) { Console.WriteLine(); }
            }

            Console.Read();
            char ch = (char)(0x9FD5);
            string str = (char)0x274E + " Строка ебать";
            Console.WriteLine(str1);

            String text = "some text";
            int seed = 3;
            

            Encrypter encrypter = new Encrypter(text, seed);

        }
    }
}

/*      #Шифрование
 *      1. Данные -> перевести в двоичный вид
 *      2. Сгенерировать гамму шифра на основе определенного
 *      порождающего значения(seed)
 *      3. Разбить данные и гамму на блоки одинаковой длины
 *      4. Применить гамму шифра к данным поблочно (по XOR)
 *          Один блок шифруется по формуле: 
 *          ### [БДш] = [БГШ] <XOR> [БДо], где
 *           БДш - шифрованный блок данных
 *           БГШ - блок гаммы шифра
 *           БДо - нешифрованный блок данных
 * 
 *      #Дешифровка
 *      1. Сгенерировать гамму на основе изначального(seed)
 *      2. Применить шифртекст к гамме шифра поблочно (по XOR)
 *          Один блок дешифруется по формуле:
 *          ### [БДо] = [БГШ] <XOR> [БДш]
 * 
 */
