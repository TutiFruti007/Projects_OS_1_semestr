using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FinanceApp;

namespace FinanceTest
{
    public class TestFiles: IDisposable
    {
        private string file = "Test_FromFile.txt";
        private string inFile = "Test_InFile.txt";
        public void Dispose() {
            if(File.Exists(file)) File.Delete(file);
            if (File.Exists(inFile)) File.Delete(inFile);
        }

        [Fact]
        public void FromFile_ThreeValidLines_ReturnObj() {
            File.WriteAllLines(file, new string[] {
                "Финансы 2000-09-09 USD 1000",
                "Зарплата 2024-01-18 EUR 500 Programmer 100",
                "Добавка 2024-01-18 EUR 500 Bonus Good"
            });
                List<Finance> result = new Finance().FromFile(file);
                Assert.Equal(3, result.Count);
                Assert.IsType<Finance>(result[0]);
                Assert.IsType<Salary>(result[1]);
                Assert.IsType<Prize>(result[2]);

        }
        [Fact]
        public void FromFile_NotAllValidLines_ReturnValidLines() {
            File.WriteAllLines(file, new string[] {
                "Финансы 2000-09-09 USD 1000",
                "2024-01-18 EUR 500 Bonus Good",
                "Зарплата 2024-01-18 EUR 500 Programmer 100"
            });

                List<Finance> result = new Finance().FromFile(file);
                Assert.Equal(2, result.Count);
                Assert.IsType<Finance>(result[0]);
                Assert.IsType<Salary>(result[1]);

        }
        [Fact]
        public void FromFile_EmptyFile_ReturnEmptuList() {
            File.WriteAllLines(file, new string[] { "" });
                List<Finance> result = new Finance().FromFile(file);
                Assert.Empty(result);
        }
        [Fact]
        public void FromFile_NoneFile_ReturnEmptuList()
        {
            List<Finance> result = new Finance().FromFile(file);
            Assert.Empty(result);
        }


        [Theory]
        [InlineData("Финансы 2000-09-09 USD 1000")]
        [InlineData("Финансы 2000-09-09 USD 1000|Добавка 2024-01-18 EUR 500 Bonus Good")]
        [InlineData("Финансы 2000-09-09 USD 1000|Зарплата 2024-01-18 EUR 500 Programmer 100|Добавка 2024-01-18 EUR 500 Bonus Good")]
        public void InFile_ThreeObj_PlusThreeInFile(string data) {
            string[] source = data.Split('|');
            List<Finance> list = new List<Finance>();
            foreach (string line in source)
            {
                list.Add(Finance.Create(line));
            }
            Finance.InFile(inFile, list);

            string[] lines = File.ReadAllLines(inFile);
            Assert.Equal(list.Count, lines.Length);
            for (int i = 0; i < list.Count; i++)
            {
                Assert.Equal(list[i].ToString(), lines[i]);
            }
        }
        [Fact]
        public void InFile_ExistingFile_AppendsToEnd()
        {
            File.WriteAllLines(inFile, new string[] { "старая строка" });

            List<Finance> list = new List<Finance>();
            list.Add(Finance.Create("Финансы 2000-09-09 USD 1000"));

            Finance.InFile(inFile, list);

            string[] lines = File.ReadAllLines(inFile);
            Assert.Equal(2, lines.Length);
            Assert.Equal("старая строка", lines[0]);
            Assert.Equal("Финансы 2000-09-09 USD 1000", lines[1]);
        }
    }
}
