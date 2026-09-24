using System;

namespace FinanceApp
{
    internal class Salary : Finance
    {
        public string Specialization { get; set; }
        public double Tax { get; set; }
        public double SumWithTax { get; set; }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} " +
                   $"{Resource} " +
                   $"{Sum} " +
                   $"{Specialization} " +
                   $"{Tax} " +
                   $"{SumWithTax}";
        }

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
    }
}