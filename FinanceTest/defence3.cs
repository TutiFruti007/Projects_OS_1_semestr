using FinanceApp;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Text;
namespace FinanceTest
{
    public class defence3
    {
        [Fact]
        public void Test1() 
        {
            Dictionary<string, List<List<string>>> dictionary = new Dictionary<string, List<List<string>>> {
                ["B"] = new List<List<string>>
                {
                    new List<string> { "A", "C" },
                    new List<string>()
                    
                },
                ["A"] = new List<List<string>>
                {
                    new List<string>{"E"},
                    new List<string> {"F"}
                },
                ["C"] = new List<List<string>>
                {
                    new List<string>{"E","D"},
                    new List<string> {}
                }
            };
            string graf = "A --|> B \n C --|> B \n E --|> A \n  F --|> C \n  F --|> C \n A o-> E ";
            Dictionary<string, List<List<string>>> result = FinanceApp.Program.Def(graf);

            Assert.Equal(result , dictionary);

        }
        [Fact]
        public void Test2()
        {
            string graf = "A --| B \n C -- B \n E -- A \n  F --|> C \n  F C \n A  E ";
            Assert.Throws<Exception>(() => FinanceApp.Program.Def(graf));


        }

        
    }
}
