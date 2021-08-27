using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace LoggingWithDI
{
    public class Calculator : ICalculator
    {
        private readonly ILogger _logger;
        private readonly IXunitLogger _xunitLogger;
        private readonly ITestOutputHelper _outputHelper;

        // Делаем инъекцию нашего кастомного класса, откуда мы достаем ITestOutputHelper
        // Чтобы логи отображались, мы должны вызвать метод ToLogger, для этого надо скачать официально-поддерживаемую библиотеку Xunit - MartinCostello.Logging.XUnit
        public Calculator(IXunitLogger xunitLogger)
        {
            _xunitLogger = xunitLogger;
            _logger = xunitLogger.OutputHelper.ToLogger<Calculator>();
        }

        public int Sum(int x, int y)
        {
            _logger.LogInformation($"First number: {x}, second number: {y}");
            _logger.LogInformation("Going to sum two numbers");
            var sum = x + y;
            _logger.LogInformation($"Sum is: {sum}");

            return sum;
        }
    }
}