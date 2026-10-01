using FinanceApp;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace TestByMythodClass
{
    public class TestByMythodClass
    {
        [Theory]
        [InlineData("Финансы 2000-09-09 USD 1000", typeof(Finance))]
        [InlineData("Добавка 2024-01-18 EUR 500 Vova Prize", typeof(Prize))]
        [InlineData("Зарплата 2024-01-18 EUR 500 Prog 100", typeof(Salary))]
        public void Create_Valid_ReturnObjByFinance(string input, Type expectedType)
        {
            Finance result = Finance.Create(input);

            Assert.IsType(expectedType, result);
        }
        [Theory]
        [InlineData(null)]                            
        [InlineData("")]                              
        [InlineData("   ")]                            
        [InlineData("ш 2024-01-18 EUR 500 Prog 100")]  
        [InlineData("Финансы не_дата USD 1000")]       
        [InlineData("Зарплата 2024-01-18 EUR 500")]   
        public void Create_InvalidInput_ReturnsNull(string input)
        {
            Finance result = Finance.Create(input);

            Assert.Null(result);
        }
    }
}
