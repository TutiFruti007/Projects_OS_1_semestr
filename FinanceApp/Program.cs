using System;
using System.Collections.Generic;

namespace FinanceApp
{
    public class Program
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

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Введите данные:");
                            Finance created = FinanceNull(Console.ReadLine());
                            if (created != null) finances.Add(created);
                            break;
                        case "2":
                            Console.WriteLine("Введите путь к файлу:");
                            foreach (Finance item in finance.FromFile(Console.ReadLine()))
                            {
                                finances.Add(item);
                            }
                            break;
                        case "3":
                            Console.WriteLine("Файл куда записывать:");
                            string file = Console.ReadLine();
                            Console.WriteLine("Сколько хотите добавить строк:");
                            if (!int.TryParse(Console.ReadLine(), out int num) || num < 0)
                            {
                                Console.WriteLine("Нужно ввести целое число.");
                                break;
                            }
                            List<Finance> newItems = new List<Finance>();
                            for (int i = 0; i < num; i++)
                            {
                                Finance item = FinanceNull(Console.ReadLine());
                                if (item != null) newItems.Add(item);
                            }
                            Finance.InFile(file, newItems);
                            foreach (Finance item in newItems)
                            {
                                finances.Add(item);
                            }
                            break;
                        case "4":
                            foreach (Finance item in finances)
                            {
                                Console.WriteLine(item);
                            }
                            break;

                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }
        static Finance FinanceNull(string line) { 
            Finance created = Finance.Create(line);
            if (created == null) 
            {
                Console.WriteLine("не удалось считать файл");
            }
            return created;

        }
         public static Dictionary<string, List<List<string>>>  Def(string input) {
            return new Dictionary<string, List<List<string>>>();
        }
    }
}