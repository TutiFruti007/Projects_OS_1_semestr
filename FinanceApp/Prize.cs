using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinanceApp
{
    internal class Prize: Finance
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public override void FromString(string input)
        {
            string[] s = input.Trim().Split(' ');
            Date = DateTime.Parse(s[0]);
            Resource = s[1];
            Sum = Convert.ToDouble(s[2]);
            Name = s[3];
            Description = s[4];
        }
        public override void InFile(string file, Finance[] finances)
        {
            string content = "";
            foreach (Finance finance in finances)
            {
                if (finance is Prize prize)
                {
                    content += string.Format(
                            "{0:yyyy-MM-dd} {1} {2} {3} {4}\n",
                            prize.Date,
                            prize.Resource,
                            prize.Sum,
                            prize.Name,
                            prize.Description
                            );
                }
            }
            File.AppendAllText(file, content);
        }

    }
}
