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
            Finance finance = new Finance(); 
            finance.FromString(input); 
            string path = "data.txt"; 
            string content = $"{finance.Date}, {finance.Resource}, {finance.Sum}"; 
            File.WriteAllText(path, content);
        }
    }
}
