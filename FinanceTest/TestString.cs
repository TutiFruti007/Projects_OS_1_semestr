using FinanceApp;

namespace FinanceTest
{
    public class TestString
    {
        [Theory]
        [InlineData("Финансы 2000-09-09 USD 1000", typeof(Finance))]
        [InlineData("Зарплата 2024-01-18 EUR 500 Programmer 100", typeof(Salary))]
        [InlineData("Добавка 2024-01-18 EUR 500 Bonus Good", typeof(Prize))]
        public void FromString_ValidInput_ReturnsTrue(string input, Type type)
        {
            Finance finance;
            if (type == typeof(Finance))
            {
                finance = new Finance();
            }
            else if (type == typeof(Salary))
            {
                finance = new Salary();
            }
            else
            {
                finance= new Prize();
            }
            bool result = finance.FromString(input);
            Assert.True(result);
        }

        [Theory]
        //[InlineData("2000-09-09 USD 1000")]
        [InlineData("2024-01-018 EUR 500.5")]
        public void FromString_NotValidInput_ReturnsFalse(string input)
        {
            Finance finance = new Finance();
            bool result = finance.FromString(input);
            Assert.False(result);
        }

            [Theory]
            [InlineData("Финансы 2000-09-09 USD 1000", "Финансы", "2000-09-09", "USD", 1000)]
            public void ToString_Finance_ReturnString(
         string input,
         string nameClass,
         string date,
         string res,
         double sum)
            {
                Finance finance = new Finance
                {
                    NameClass = nameClass,
                    Date = DateTime.Parse(date),
                    Resource = res,
                    Sum = sum
                };

                string result = finance.ToString();

                Assert.Equal(input, result);
            }

            [Theory]
            [InlineData("Зарплата 2024-01-18 EUR 500 Programmer 100 400", "Зарплата", "2024-01-18", "EUR", 500, "Programmer", 100, 400)]
            [InlineData("Зарплата 2000-09-09 USD 1000 Teacher 200 800", "Зарплата", "2000-09-09", "USD", 1000, "Teacher", 200, 800)]
            public void ToString_Salary_ReturnString(
                string input,
                string nameClass,
                string date,
                string res,
                double sum,
                string specialization,
                double tax,
                double sumWithTax)
            {
                Salary salary = new Salary
                {
                    NameClass = nameClass,
                    Date = DateTime.Parse(date),
                    Resource = res,
                    Sum = sum,
                    Specialization = specialization,
                    Tax = tax,
                    SumWithTax = sumWithTax
                };

                string result = salary.ToString();

                Assert.Equal(input, result);
            }

            [Theory]
            [InlineData("Добавка 2024-01-18 EUR 500 Bonus Good", "Добавка", "2024-01-18", "EUR", 500, "Bonus", "Good")]
            [InlineData("Добавка 2000-09-09 USD 1000 Gift Birthday", "Добавка", "2000-09-09", "USD", 1000, "Gift", "Birthday")]
            public void ToString_Prize_ReturnString(
                string input,
                string nameClass,
                string date,
                string res,
                double sum,
                string name,
                string description)
            {
                Prize prize = new Prize
                {
                    NameClass = nameClass,
                    Date = DateTime.Parse(date),
                    Resource = res,
                    Sum = sum,
                    Name = name,
                    Description = description
                };

                string result = prize.ToString();

                Assert.Equal(input, result);
            }
        }
    }

