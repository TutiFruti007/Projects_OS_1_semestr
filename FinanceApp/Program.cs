using System;
using System.Collections.Generic;
using System.IO;

namespace FinanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Finance finance = new Finance();
            List<Finance> finances = new List<Finance>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Добавить из строки");
                Console.WriteLine("2 - Добавить из файла");
                Console.WriteLine("3 - Сохранить в файла");
                Console.WriteLine("4 - Вывести");
                Console.WriteLine("0 - Выход");

                string answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.WriteLine("Введите данные:");

                    string input = Console.ReadLine();

                    finances.Add(Finance.Create(input));
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Введите путь к файлу:");

                    string file = Console.ReadLine();

                    foreach (Finance item in finance.FromFile(file))
                    {
                        finances.Add(item);
                    }
                }
                else if (answer == "3") {
                    Console.WriteLine("Файл куда записывать");
                    string file_appand = Console.ReadLine();
                    Console.WriteLine("сколько хотите добавить строк");
                    int num = int.Parse(Console.ReadLine());
                    for (int i = 0; i < num; i++) {
                        string line = Console.ReadLine();
                        finances.Add(Finance.Create(line));
                    }
                    finance.InFile(file_appand, finances);                    
                }
                else if (answer == "4")
                {
                    foreach (var item in finances) {
                        Console.WriteLine(item.ToString());
                    }

                }
                else if (answer == "0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Неверный выбор.");
                }
            }
        }
    }
}