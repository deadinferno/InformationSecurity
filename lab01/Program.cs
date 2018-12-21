using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    class Program
    {
        const int S_SIZE = 255;

        static void Main()
        {
            List<int> key = new List<int>();
            Console.Write("#ВВОД КЛЮЧА(1)#\n> ");
            key.Add(Convert.ToInt32(Console.ReadLine()));

            Console.Write("#ВВОД КЛЮЧА(2)#\n> ");
            key.Add(Convert.ToInt32(Console.ReadLine()));

            List<char> dict_table = new List<char>();
            dict_table.AddRange("йцукенгшщзхъфывапролджэячсмитьбю ");

            List<int> affine_table = new List<int>();
            for(int i = 0; i < dict_table.Count; i++)
            {
                affine_table.Add((key[0] * i + key[1]) % dict_table.Count); // I = (A * J + K) % M
            }


            Console.Write("#ВВОД СТРОКИ#\n> ");
            List<char> word = new List<char>();
            word.AddRange(Convert.ToString(Console.ReadLine()));
            

            List<char> wordEncr = new List<char>();
            for(int i = 0; i < word.Count; i++)
            {
                for(int k = 0; k < dict_table.Count; k++)
                {
                    if(dict_table[k] == word[i])
                    {
                        wordEncr.Add(dict_table[affine_table[k]]);
                    }
                }
            }


            char[] encrString = new char[S_SIZE];
            wordEncr.CopyTo(encrString);

            Console.Write("\n#ЗАШИФРОВАННАЯ СТРОКА: \n> ");
            for(int i = 0; i < S_SIZE; i++)
            {
                if (encrString[i] == '\0')
                    break;
                Console.Write(encrString[i]);
            }


            List<char> wordDecr = new List<char>();
            for(int i = 0; i < wordEncr.Count; i++)
            {
                for(int k = 0; k < dict_table.Count; k++)
                {
                    if(dict_table[k] == wordEncr[i])
                    {
                        for(int l = 0; l < affine_table.Count; l++)
                        {
                            if(affine_table[l] == k)
                            {
                                wordDecr.Add(dict_table[l]);
                            }
                        }
                    }
                }
            }


            char[] decrString = new char[S_SIZE];
            wordDecr.CopyTo(decrString);


            Console.Write("\n\n#РАСШИФРОВАННАЯ СТРОКА: \n> ");
            for (int i = 0; i < S_SIZE; i++)
            {
                if (decrString[i] == '\0')
                    break;
                Console.Write(decrString[i]);
            }

        }
    }

}