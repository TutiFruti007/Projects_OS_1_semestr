using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Добавить из строки");
                Console.WriteLine("2 - Добавить в файл");
                Console.WriteLine("0 - Выход");

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        {
                            Console.WriteLine("1 - Добавить зарплату");
                            Console.WriteLine("2 - Добавить премию");
                            Console.WriteLine("3 - Добавить финансы");

                            string type = Console.ReadLine();

                            Console.WriteLine("Введите данные:");
                            string input = Console.ReadLine();

                            switch (type)
                            {
                                case "1":
                                    {
                                        Salary salary = new Salary();
                                        salary.FromString(input);

                                        Console.WriteLine(
                                            $"{salary.Date:yyyy-MM-dd} " +
                                            $"{salary.Resource} " +
                                            $"{salary.Sum} " +
                                            $"{salary.Specialization} " +
                                            $"{salary.Tax} " +
                                            $"{salary.SumWithTax}"
                                        );

                                        break;
                                    }

                                case "2":
                                    {
                                        Prize prize = new Prize();
                                        prize.FromString(input);

                                        Console.WriteLine(
                                            $"{prize.Date:yyyy-MM-dd} " +
                                            $"{prize.Resource} " +
                                            $"{prize.Sum} " +
                                            $"{prize.Name} " +
                                            $"{prize.Description}"
                                        );

                                        break;
                                    }

                                case "3":
                                    {
                                        Finance finance = new Finance();
                                        finance.FromString(input);

                                        Console.WriteLine(
                                            $"{finance.Date:yyyy-MM-dd} " +
                                            $"{finance.Resource} " +
                                            $"{finance.Sum}"
                                        );

                                        break;
                                    }

                                default:
                                    Console.WriteLine("Неверный выбор.");
                                    break;
                            }

                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("1 - Записать зарплату");
                            Console.WriteLine("2 - Записать премию");
                            Console.WriteLine("3 - Записать финансы");

                            string type = Console.ReadLine();

                            Console.WriteLine("Введите данные:");
                            string input = Console.ReadLine();

                            Console.WriteLine("Введите путь к файлу:");
                            string file = Console.ReadLine();

                            switch (type)
                            {
                                case "1":
                                    {
                                        Salary salary = new Salary();
                                        salary.FromString(input);

                                        Salary[] salaries = new Salary[]
                                        {
                                            salary
                                        };

                                        salary.InFile(file, salaries);

                                        Console.WriteLine("Зарплата записана в файл.");

                                        break;
                                    }

                                case "2":
                                    {
                                        Prize prize = new Prize();
                                        prize.FromString(input);

                                        Prize[] prizes = new Prize[]
                                        {
                                            prize
                                        };

                                        prize.InFile(file, prizes);

                                        Console.WriteLine("Премия записана в файл.");

                                        break;
                                    }

                                case "3":
                                    {
                                        Finance finance = new Finance();
                                        finance.FromString(input);

                                        Finance[] finances = new Finance[]
                                        {
                                            finance
                                        };

                                        finance.InFile(file, finances);

                                        Console.WriteLine("Финансы записаны в файл.");

                                        break;
                                    }

                                default:
                                    Console.WriteLine("Неверный выбор.");
                                    break;
                            }

                            break;
                        }

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}