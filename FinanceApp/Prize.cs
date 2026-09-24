using System;

namespace FinanceApp
{
    internal class Prize : Finance
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} " +
                   $"{Resource} " +
                   $"{Sum} " +
                   $"{Name} " +
                   $"{Description}";
        }

        public override void FromString(string input)
        {
            string[] s = input.Trim().Split(' ');

            Date = DateTime.Parse(s[0]);
            Resource = s[1];
            Sum = Convert.ToDouble(s[2]);
            Name = s[3];
            Description = s[4];
        }
    }
}