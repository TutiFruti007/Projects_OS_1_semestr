using System;

namespace FinanceApp
{
    public class Salary : Finance
    {
        public string Specialization { get; set; }
        public double Tax { get; set; }
        public double SumWithTax { get; set; }

        public override string ToString()
        {
            return $"{NameClass} {Date:yyyy-MM-dd} {Resource} {Sum} {Specialization} {Tax} {SumWithTax}";
        }

        public override bool FromString(string input)
        {
            string[] s = input.Trim().Split(' ');
            if (s.Length < 6) { return false; }

            NameClass = s[0];

            bool dateOk = DateTime.TryParse(s[1], out DateTime date);
            Date = date;

            Resource = s[2];

            bool sumOk = double.TryParse(s[3], out double sum);
            Sum = sum;

            Specialization = s[4];

            bool taxOk = double.TryParse(s[5], out double tax);
            Tax = tax;

            bool allOk = dateOk && sumOk && taxOk;
            SumWithTax = allOk ? Sum - Tax : 0;

            return allOk;
        }
    }
}