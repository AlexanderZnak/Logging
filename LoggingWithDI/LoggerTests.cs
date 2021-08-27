using Xunit;

namespace LoggingWithDI
{
    public class LoggerTests
    {
        // Делаем инъекцию через конструктор( под капотом создался экземпляр класса Calculator), теперь мы спокойно можем использовать все его свойства и методы
        private readonly ICalculator _calculator;

        public LoggerTests(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [Fact]
        public void SumTest()
        {
            Assert.Equal(3, _calculator.Sum(1, 2));
        }
    }
}