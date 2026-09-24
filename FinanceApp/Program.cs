using System;

namespace FinanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Finance finance = new Finance();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Добавить из строки");
                Console.WriteLine("2 - Добавить из файла");
                Console.WriteLine("0 - Выход");

                string answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.WriteLine("Введите данные:");

                    string input = Console.ReadLine();

                    Finance result = Finance.Create(input);

                    Console.WriteLine(result);
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Введите путь к файлу:");

                    string file = Console.ReadLine();

                    Finance[] finances = finance.FromFile(file);

                    foreach (Finance item in finances)
                    {
                        Console.WriteLine(item);
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