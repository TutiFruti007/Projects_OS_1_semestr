using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinanceApp
{
    internal class Finance
    {
        public DateTime Date { get; set; }
        public string Resource { get; set; }
        public Double Sum { get; set; }
        public virtual void FromString(string input) 
        { 
            string[] s = input.Trim().Split(' '); 
            Date = DateTime.Parse(s[0]); 
            Resource = s[1]; 
            Sum = Convert.ToDouble(s[2]); 
        }
        public virtual void InFile(string file, Finance[] finances) {
            string content = "";
            foreach (Finance finance in finances)
            {
                content += string.Format( "{0:yyyy-MM-dd} {1} {2}\n",
                            finance.Date,
                            finance.Resource,
                            finance.Sum);
            }
            File.AppendAllText(file,content);
        }
        
        public Finance() { }
    }
}
