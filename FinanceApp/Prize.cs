using System;

namespace FinanceApp
{
    public class Prize : Finance
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{NameClass} {Date:yyyy-MM-dd} {Resource} {Sum} {Name} {Description}";
        }

        public override bool FromString(string input)
        {
            string[] s = input.Trim().Split(' ', 6);
            if (s.Length < 6) { return false; }

            NameClass = s[0];

            bool dateOk = DateTime.TryParse(s[1], out DateTime date);
            Date = date;

            Resource = s[2];

            bool sumOk = double.TryParse(s[3], out double sum);
            Sum = sum;

            Name = s[4];
            Description = s[5];

            return dateOk && sumOk;
        }
    }
}