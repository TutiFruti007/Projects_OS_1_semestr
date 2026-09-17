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
            Finance finance1 = new Finance();
            Finance finance2 = new Finance();
            Finance finance3 = new Finance();
            finance1.FromString("2026-09-15 Salary 50000");
            finance2.FromString("2026-09-10 Food 3000");
            finance3.FromString("2026-09-20 Bonus 10000");

            Date date = new Date();

            Finance min = date.MinDate(new Finance[]
            {
                finance1,
                finance2,
                finance3
            });

            Console.WriteLine("Минимальная дата:");
            Console.WriteLine($"{min.Date:yyyy-MM-dd} {min.Resource} {min.Sum}");

            date.PlusDay(finance1);

            Console.WriteLine("\nДата finance1 после PlusDay:");
            Console.WriteLine($"{finance1.Date:yyyy-MM-dd}");

            Finance close = date.BetweenDays(new Finance[]
            {
                finance1,
                finance2,
                finance3
            });

            Console.WriteLine("\nОбъект, ближайший к середине:");
            Console.WriteLine($"{close.Date:yyyy-MM-dd} {close.Resource} {close.Sum}");
    }
    }
}
