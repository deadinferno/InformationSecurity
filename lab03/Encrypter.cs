using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    struct Key
    {
        public int A, K;

        /// <summary>
        /// Структура описывает ключ, состоящий из пары чисел
        /// <para>A - переход по алфавиту</para>
        /// <para>K - дополнительное смещение</para>
        /// </summary>
        /// <param name="A"></param>
        /// <param name="K"></param>
        public Key(int A, int K)
        {
            this.A = A;
            this.K = K;
        }
    }

    class Encrypter
    {
        protected Key Key { get; set; }
        protected List<char> Dictionary { get; set; } // входной словарь
        protected List<int> AffDictionary { get; set; } // таблица подстановок

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Encrypter()
        {
            Key = new Key(5, 3);

            Dictionary = new List<char>();
            Dictionary.AddRange(" -йцукенгшщзхъфывапролджэячсмитьбю");

            AffDictionary = new List<int>();
            FillUpAffineDictionary();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dictionary"></param>
        public Encrypter(Key key, string dictionary)
        {
            this.Key = key;

            this.Dictionary = new List<char>();
            this.Dictionary.AddRange(dictionary);

            AffDictionary = new List<int>();
            FillUpAffineDictionary();
        }

        /// <summary>
        /// Алгоритм заполняет таблицу подстановок на основе входного алфавита и ключа
        /// <para> I = (А ∙ J + K) mod M - формула </para>
        /// </summary>
        protected void FillUpAffineDictionary()
        {
            AffDictionary.Clear();
            for (int i = 0; i < Dictionary.Count; i++)
            {
                AffDictionary.Add((Key.A * i + Key.K) % Dictionary.Count); // I = (A * J + K) % M
            }
        }

        /// <summary>
        /// Шифрует строку и возвращает зашифрованное значение
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncryptWord(string str)
        {
            List<char> word = new List<char>();
            word.AddRange(str);

            StringBuilder wordEncr = new StringBuilder();
            for (int i = 0; i < word.Count; i++)
            {
                for (int k = 0; k < Dictionary.Count; k++)
                {
                    if (Dictionary[k] == word[i])
                    {
                        wordEncr.Insert(i, Dictionary[AffDictionary[k]]);
                    }
                }
            }
            return wordEncr.ToString();
        }

        /// <summary>
        /// Дешифрует строку и возвращает расшифрованное значение
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DecryptWord(string str)
        {
            List<char> word = new List<char>();
            word.AddRange(str);

            StringBuilder wordDecr = new StringBuilder();
            for (int i = 0; i < word.Count; i++)
            {
                for (int k = 0; k < Dictionary.Count; k++)
                {
                    if (Dictionary[k] == word[i])
                    {
                        for (int l = 0; l < AffDictionary.Count; l++)
                        {
                            if (AffDictionary[l] == k)
                            {
                                wordDecr.Insert(i, Dictionary[l]);
                            }
                        }
                    }
                }
            }
            return wordDecr.ToString();
        }
        
        /// <summary>
        /// Установить значение ключа
        /// </summary>
        /// <param name="key"></param>
        public void SetKey(Key key)
        {
            this.Key = key;
            FillUpAffineDictionary();
        }

        /// <summary>
        /// Установить входной словарь/алфавит
        /// </summary>
        /// <param name="str"></param>
        public void SetDictionary(string str)
        {
            List<char> temp = new List<char>();
            temp.AddRange(str);
            Dictionary = temp;
            FillUpAffineDictionary();
        }

    }

}