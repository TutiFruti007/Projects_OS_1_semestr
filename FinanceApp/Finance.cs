using System;
using System.Collections.Generic;
using System.IO;

namespace FinanceApp
{
    internal class Finance
    {
        public DateTime Date { get; set; }
        public string Resource { get; set; }
        public double Sum { get; set; }

        public static Finance Create(string input)
        {
            string[] s = input.Trim().Split(' ');

            Finance finance;

            if (s.Length == 6)
            {
                finance = new Salary();
            }
            else if (s.Length == 5)
            {
                finance = new Prize();
            }
            else
            {
                finance = new Finance();
            }

            finance.FromString(input);

            return finance;
        }

        public List<Finance> FromFile(string file)
        {
            List<Finance> finances = new List<Finance>();

            using (StreamReader streamReader = new StreamReader(file))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        finances.Add(Create(line));
                    }
                }
            }

            return finances;
        }

        public virtual void FromString(string input)
        {
            string[] s = input.Trim().Split(' ');

            Date = DateTime.Parse(s[0]);
            Resource = s[1];
            Sum = Convert.ToDouble(s[2]);
        }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} {Resource} {Sum}";
        }

        public virtual void InFile(string file, List<Finance> finances)
        {
            foreach (Finance finance in finances)
            {
                File.AppendAllText(file, Create(finance.ToString()).ToString() + "\n");
            }
        }

        public Finance()
        {
        }
    }
}