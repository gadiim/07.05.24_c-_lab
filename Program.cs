using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Тема: Взаємодія з файловою системою
//Модуль 12. Часть 1

namespace _07._05._24_c__lab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //            Завдання 1:
            //Додаток дозволяє користувачеві переглядати вміст файлу.
            //Користувач вводить шлях до файлу. Якщо файл існує, його вміст
            //відображається на екрані. Якщо файл не існує, виведіть
            //повідомлення про помилку.

            Console.WriteLine($"Task 1\n");


            Console.Write("enter path:\t\t");
            string user_path_1 = Console.ReadLine();
            Console.WriteLine();
            try
            {
                StreamReader sr_1 = new StreamReader(user_path_1);
                Console.WriteLine($"file content:\t\t{sr_1.ReadToEnd()}");
                sr_1.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("file not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 2:
            //Користувач вводить значення елементів масиву з клавіатури.
            //Додаток надає можливість зберігати вміст масиву у файл.

            Console.WriteLine($"Task 2\n");

            Console.Write("enter path:\t\t");
            string user_path_2 = Console.ReadLine();
            Console.WriteLine();

            try
            {
                Console.Write("enter value (with space):\t");
                string values_2 = Console.ReadLine();

                using (StreamWriter sw_2 = new StreamWriter(user_path_2, true))
                {
                    string[] arr_2 = values_2.Split(' ');
                    for (int i = 0; i < arr_2.Length; i++)
                    {
                        sw_2.Write($"{arr_2[i]} ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }


            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 3:
            //Додайте до другого завдання можливість завантажувати масив
            //із файлу.

            Console.WriteLine($"Task 3\n");

            try
            {
                using (StreamReader sr_3 = new StreamReader(user_path_2))
                {
                    string file_data_3 = sr_3.ReadToEnd();
                    string[] arr_3 = file_data_3.Split(new char[] { ' ' });
                    Console.Write("arr_3:\t\t\t");
                    foreach (string s in arr_3)
                    {
                        Console.Write($"{s} ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 4:
            //Додаток генерує випадковим чином 10000 цілих чисел.
            //Збережіть парні числа в один файл, непарні – в інший. За
            //підсумками роботи додатка потрібно відобразити статистику на
            //екрані.

            Console.WriteLine($"Task 4\n");

            int even_count_4 = 0, odd_count_4 = 0;

            Random random_4 = new Random();

            try
            {
                for (int i = 0; i < 10000; i++)
                {
                    int random_number_4 = random_4.Next();
                    if (random_4.Next() % 2 == 0)
                    {
                        even_count_4++;
                        using (StreamWriter sw_even_4 = new StreamWriter("even.txt", true))
                        {
                            sw_even_4.Write($"{random_number_4} ");
                        }
                    }
                    else
                    {
                        odd_count_4++;
                        using (StreamWriter sw_odd_4 = new StreamWriter("odd.txt", true))
                        {
                            sw_odd_4.Write($"{random_number_4} ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }

            Console.WriteLine($"even:\t\t{even_count_4}");
            Console.WriteLine($"odd:\t\t{odd_count_4}");

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 5:
            //Додаток надає користувачеві можливість пошуку по файлу:
            // Пошук заданого слова. Додаток показує, чи знайдено слово.
            //Крім того, відображається інформація про те, де знайдено
            //збіг.
            // Пошук кількості входження слова у файл. Додаток
            //відображає кількість знайденого слова.
            // Пошук заданого слова у зворотному порядку. Наприклад,
            //користувач шукає слово «moon». Це означає, що додаток
            //шукає слово «moon» у зворотному напрямку: «noom». За
            //результатами пошуку, додаток відображає кількість
            //входжень.

            Console.WriteLine($"Task 5\n");

            Console.Write("enter path:\t\t");
            string user_path_5 = Console.ReadLine();

            Console.Write("enter word:\t\t");
            string user_word_5 = Console.ReadLine();

            string reversed_user_word_5 = "";
            for (int i = user_word_5.Length - 1; i >= 0; i--)
            {
                reversed_user_word_5 += user_word_5[i];
            }

            try
            {
                using (StreamReader sr_5 = new StreamReader(user_path_5))
                {
                    string file_data_5 = sr_5.ReadToEnd();
                    FindWord(file_data_5, user_word_5);
                    FindWord(file_data_5, reversed_user_word_5);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }

            void FindWord(string file_data, string user_word)
            {
                bool is_contain = file_data.Contains(user_word);
                Console.WriteLine($"the word \"{user_word}\" {(is_contain ? "found" : "not found")}");
                if (is_contain)
                {
                    int word_counter_5 = 0;
                    string[] arr_5 = file_data.Split(' ');
                    ArrayList index_list_5 = new ArrayList();
                    for (int i = 0; i < arr_5.Length; i++)
                    {
                        if (arr_5[i] == user_word)
                        {
                            word_counter_5++;
                            index_list_5.Add(i);
                        }
                    }
                    Console.WriteLine($"{word_counter_5} matches found");
                    Console.Write($"word number in the sentence:\t");
                    foreach (int i in index_list_5)
                    {
                        Console.Write($"{i + 1} ");
                    }
                }
            }

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 6:
            //Користувач вводить шлях до файлу. Додаток відображає
            //статистичну інформацію про файл:
            // кількість речень;
            // кількість великих літер;
            // кількість маленьких літер;
            // кількість голосних літер;
            // кількість приголосних літер;
            // кількість цифр.

            Console.WriteLine($"Task 6\n");

            Console.Write("enter path:\t\t");
            string user_path_6 = Console.ReadLine();
            Console.WriteLine();

            int sentence_counter = 0;
            int upper_counter = 0;
            int lower_counter = 0;
            int vowel_counter = 0;
            int consonant_counter = 0;
            int digit_counter = 0;
            using (StreamReader sr_6 = new StreamReader(user_path_6))
            {
                string file_data_6 = sr_6.ReadToEnd();
                foreach (char i in file_data_6)
                {
                    if (i == '.' || i == '!' || i == '?')
                    {
                        sentence_counter++;
                    }

                    if (char.IsUpper(i))
                    {
                        upper_counter++;
                    }
                    else if (char.IsLower(i))
                    {
                        lower_counter++;
                    }

                    if ("aeiouyAEIOUY".Contains(i))
                    {
                        vowel_counter++;
                    }
                    else if (char.IsLetter(i))
                    {
                        consonant_counter++;
                    }

                    if (char.IsDigit(i))
                    {
                        digit_counter++;
                    }
                }
            }
            Console.WriteLine($"file contains {sentence_counter} sentence(s)\n");
            Console.WriteLine($"file contains {upper_counter} upper letter(s)\n");
            Console.WriteLine($"file contains {lower_counter} lower letter(s)\n");
            Console.WriteLine($"file contains {vowel_counter} vowel letter(s)\n");
            Console.WriteLine($"file contains {consonant_counter} consonant letter(s)\n");
            Console.WriteLine($"file contains {digit_counter} digit(s)\n");
            Console.WriteLine();
        }
    }
}

