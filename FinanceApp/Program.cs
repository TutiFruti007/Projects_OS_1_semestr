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
            string input = Console.ReadLine();
            string input2 = Console.ReadLine();
            string input3 = Console.ReadLine();
            string input4 = Console.ReadLine();

            Finance finance = new Finance();
            Finance finance2 = new Finance();
            Finance finance3 = new Finance();
            Finance finance4 = new Finance();

            finance.FromString(input);
            finance2.FromString(input2);

            finance.MinDate(new Finance[] { finance, finance2 });

            finance.PlusDay();

            Finance days = new Finance().BetweenDays(new Finance[] { finance, finance2, finance3, finance4 });

            string path = "data.txt";

            string content = $"{finance.Date}, {finance.Resource}, {finance.Sum}" +
                $" \n {finance2.Date}, {finance2.Resource}, {finance2.Sum} " +
                $"\n {days} ";
            File.WriteAllText(path, content);
        }
    }
}
