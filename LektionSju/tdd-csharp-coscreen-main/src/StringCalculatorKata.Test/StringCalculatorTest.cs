using NUnit.Framework;
using StringCalculatorKata;
namespace StringCalculatorKata.Test
{
    public class StringCalculatorTest
    {
        [Test]
        [TestCase("", ExpectedResult = 0)]
        [TestCase("1+1,3", ExpectedResult = 5)]//hur lägga jag till ett meddelande titta på det
        [TestCase("1//;/1,3", ExpectedResult = 5)]
        [TestCase("2,3", ExpectedResult = 5 )]
        public int Add_EmptyStringAsParam_ReturnsZero(string input)
        {
            StringCalculator calculator = new StringCalculator();
            return calculator.Add(input);
        }
        [Test]
        [TestCase("4", ExpectedResult = 2)]

        public double Roots(string input) 
        {
            StringCalculator stringsNum = new StringCalculator();
            return stringsNum.Roots(input);
        }
    }
}
