using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinanceApp
{
    internal class Salary: Finance
    {
        public string Specialization { get; set; }
        public double Tax { get; set; }
        public double SumWithTax { get; set; }
        public override void FromString(string input)
        {
            string[] s = input.Trim().Split(' ');
            Date = DateTime.Parse(s[0]);
            Resource = s[1];
            Sum = Convert.ToDouble(s[2]);
            Specialization = s[3];
            Tax = Convert.ToDouble(s[4]);
            SumWithTax = Sum - Tax;
        }
        public override void InFile(string file, Finance[] finances)
        {
            string content = "";
            foreach (Finance finance in finances)
            {
                if (finance is Salary salary)
                {
                    content += string.Format(
                        "{0:yyyy-MM-dd} {1} {2} {3} {4} {5}\n",
                        salary.Date,
                        salary.Resource,
                        salary.Sum,
                        salary.Specialization,
                        salary.Tax,
                        salary.SumWithTax);
                }
            }
            File.AppendAllText(file, content);
        }
    }
}
