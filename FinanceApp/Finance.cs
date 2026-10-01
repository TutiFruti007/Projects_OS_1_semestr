using System;
using System.Collections.Generic;
using System.IO;

namespace FinanceApp
{
    public class Finance
    {
        public string NameClass { get; set; }
        public DateTime Date { get; set; }
        public string Resource { get; set; }
        public double Sum { get; set; }

        public static Finance Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            string[] s = input.Trim().Split(' ');

            Finance finance;

            if (s[0] == "Зарплата")
            {
                finance = new Salary();
            }
            else if (s[0] == "Добавка")
            {
                finance = new Prize();
            }
            else if (s[0] == "Финансы")
            {
                finance = new Finance();
            }
            else
            {
                return null;
            }

            bool ok = finance.FromString(input);

            return ok ? finance : null;
        }

        public List<Finance> FromFile(string file)
        {
            List<Finance> finances = new List<Finance>();
            if (File.Exists(file))
            {

                using (StreamReader streamReader = new StreamReader(file))
                {
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            Finance created = Create(line);
                            if (created != null)
                            {
                                finances.Add(created);
                            }
                        }
                    }
                }
            }

            return finances;
        }

        public virtual bool FromString(string input)
        {
            string[] s = input.Trim().Split(' ');
            if (s.Length < 4) { return false; }

            NameClass = s[0];

            bool dateOk = DateTime.TryParse(s[1], out DateTime date);
            Date = date;

            Resource = s[2];

            bool sumOk = double.TryParse(s[3], out double sum);
            Sum = sum;

            return dateOk && sumOk;
        }

        public override string ToString()
        {
            return $"{NameClass} {Date:yyyy-MM-dd} {Resource} {Sum}";
        }

        public static void InFile(string file, List<Finance> finances)
        {
            foreach (Finance finance in finances)
            {
                File.AppendAllText(file, finance.ToString() + "\n");
            }
        }

        public Finance()
        {
        }
    }
}