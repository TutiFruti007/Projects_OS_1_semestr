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
        public Finance() { }
    }
}
