using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01_02
{
    class Program
    {
        static void Main(string[] args)
        {

            Encrypter encr = new Encrypter();
            encr.FillUpTable();
            encr.EncryptMessage();

        }
    }

    class Encrypter
    {
        // Variables
        string keyWord1, keyWord2;
        string inputString;
        List<string> Table;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Encrypter()
        {
            keyWord1 = "СКАНЕР";
            keyWord2 = "4123";
            inputString = "СИСТЕМНЫЙ ПАРОЛЬ ИЗМЕНЕН";
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="keyWord1"></param>
        /// <param name="keyWord2"></param>
        /// <param name="inputString"></param>
        public Encrypter(string keyWord1, string keyWord2, string inputString)
        {
            this.keyWord1 = keyWord1;
            this.keyWord2 = keyWord2;
            this.inputString = inputString;
        }

        /// <summary>
        /// Заполнение таблицы
        /// </summary>
        public void FillUpTable()
        {
            Table = new List<string>();
            StringBuilder builder = new StringBuilder();
            int carette = 0;

            for (int i = 0; i < keyWord2.Length; i++)
            {
                for (int j = 0; j < keyWord1.Length; j++, carette++)
                {
                    builder.Insert(j, inputString[carette]);
                }
                Table.Add(builder.ToString());
                builder.Clear();
            }
        }

        public void EncryptMessage()
        {
            // Сортируем столбцы
            SortColumns();
        }

        /// <summary>
        /// Перестановка столбцов
        /// </summary>
        void SortColumns()
        {
            StringBuilder builder = new StringBuilder();
            builder.Insert(0, Table[0]);

            //for (int i = 0; i < )
        }

        /// <summary>
        /// Перестановка строк
        /// </summary>
        void SortRows()
        {

        }

    }

    class Decrypter
    {

    }
}

/*
 * Алгоритм
 * 1. Заполнить таблицу построчно
 * 2. Переставить стобцы (алфавитный порядок) по первому ключу
 * 3. Переставить строки по второму ключу
 * 4. Считать итоговый шифртекст по столбцам
 * 5. Расшифровать в обратном порядке  
 
    #1 - СКАНЕР
    #2 - 4123
    #3 - СИСТЕМНЫЙ ПАРОЛЬ ИЗМЕНЕН

    Пример 4. Зашифруем фразу из третьего примера с помощью таблицы размером 4х6 и ключевых слов «СКАНЕР» и «4123». 
    После заполнения исходной таблицы по строкам (рис. 5а) пере-ставляем столбцы по порядку следования в алфавите 
    букв слова «СКАНЕР» (рис. 5б). Затем переставляем строки. Порядковый номер строки определяет цифра второго ключевого 
    слова «4123» (рис. 5в). На этом перестановки в таблице заканчиваются. Шифртекст считываем по столбцам и получаем: 
    «ЙЛЕСП_ЕЕЫОМИ_ЬНТАИНМНРЗС»

    В данном методе используются два ключевых слова. Первое слово определяет перестановку 
    и число столбцов, второе – перестановку и число строк таблицы. Перестановки производятся 
    согласно порядку следования в алфавите символов ключевых слов.
     
    На первом этапе исходный текст (или его фрагмент) построчно записывается в таблицу. Далее 
    перестанавливаются столбцы исходной таблицы по первому ключевому слову. Затем переставляются 
    строки полученной таблицы по второму ключевому слову. На последнем этапе из итоговой таблицы 
    считывается шифртекст по столбцам. Расшиф-рование осуществляется в строго обратном порядке.

    

     
     */
