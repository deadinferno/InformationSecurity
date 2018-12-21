using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    struct Letter
    {
        public char name;
        public double chance;

        public Letter(char name, double chance)
        {
            this.name = name;
            this.chance = chance;
        }
    }

    class Cryptanalyst : Encrypter
    {
        List<Letter> probability_table;
        List<Letter> probability_table_decrypted;
        string encryptedText;
        string decryptedText;
        double W = 0;
        int minA;
        double min = 100;

        public Cryptanalyst(string str, Key key, string dictionary, List<Letter> probability_table)
        {
            encryptedText = str;

            Dictionary = new List<char>();
            Dictionary.AddRange(dictionary);

            AffDictionary = new List<int>();
            FillUpAffineDictionary();

            this.probability_table = probability_table;


            TryKey();
        }

        void CalculateProbability(List<Letter> table, string text)
        {
            char temp;
            double P;
            int counter;

            // Проверка таблицы на уже существующие в ней символы
            // Если какой-то символ уже существует, то считываем следующий
            // true - совпадения есть
            // false - совпадений нет
            bool checkTable()
            {
                // Проверка на повторения добавляемых символов в таблицу
                for (int k = 0; k < table.Count; k++)
                {
                    if (temp == table[k].name)
                    {
                        return true;
                    }
                }
                return false;
            }            

            // Обход текста
            for (int i = 0; i < text.Length; i++)
            {
                counter = 0;
                temp = text[i];

                // Здесь проверка
                if (!checkTable())
                {
                    // Подсчет количества вхождений данного символа
                    for (int j = 0; j < text.Length; j++)
                    {
                        if (temp == text[j])
                            counter++;
                    }
                    P = (double)counter / text.Length;
                    table.Add(new Letter(temp, P));
                }                
            }
        }

        void TryKey()
        {
            for (int i = 1; i < 10; i++)
            {
                SetKey(new Key(i, 3)); // 3 - K

                decryptedText = DecryptWord(encryptedText);

                Console.WriteLine("\nРасшифрованный текст при A = " + i +
                    "\n.............................................");
                Console.WriteLine(decryptedText + "\n");

                probability_table_decrypted = new List<Letter>();
                CalculateProbability(probability_table_decrypted, decryptedText);

                CheckW(i);
                Console.WriteLine("|W = " + W);

            }
            Console.WriteLine("\n\n|Минимальное расхождение:\n|W = " + min + " при " + "\n|A = " + minA);
        }

        void CheckW(int minA)
        {
            W = 0;
            for (int i = 0; i < probability_table_decrypted.Count; i++)
            {
                for (int j = 0; j < probability_table.Count; j++)
                {
                    if (probability_table_decrypted[i].name == probability_table[j].name)
                    {
                        W += Math.Pow(probability_table[j].chance - probability_table_decrypted[i].chance, 2);
                    }
                }
            }

            if (W < min)
            {
                min = W;
                this.minA = minA;
            }
           

        }
    }
}
