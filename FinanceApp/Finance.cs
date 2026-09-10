using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    internal class Finance
    {
        public DateTime Date { get; set; }
        public string Resource { get; set; }
        public int Sum { get; set; }
        public void FromString(string input) 
        { 
            string[] s = input.Trim().Split(' '); 
            Date = DateTime.Parse(s[0]); 
            Resource = s[1]; 
            Sum = Convert.ToInt32(s[2]); 
        }
        public void MinDate(Finance[] finance)
        {
            Finance min = finance[0];
            foreach (Finance item in finance)
            {
                if (item.Date < min.Date)
                {
                    min = item;
                }
            }

        }
        public void PlusDay()
        {
            this.Date = this.Date.AddDays(1);
        }
        public Finance BetweenDays(Finance[] finance)
        {
            Finance min = finance[0];
            Finance max = finance[0];

            foreach (Finance item in finance)
            {
                if (item.Date < min.Date)
                {
                    min = item;
                }

                if (item.Date > max.Date)
                {
                    max = item;
                }
            }

            DateTime middle = min.Date.AddDays((max.Date - min.Date).Days / 2);

            Finance close = finance[0];

            foreach (Finance item in finance)
            {
                if (Math.Abs((item.Date - middle).Days) <
                    Math.Abs((close.Date - middle).Days))
                {
                    close = item;
                }
            }

            return close;
        }

        public Finance() { }
    }
}
