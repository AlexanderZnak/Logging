using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace LoggingWithDI
{
    // Описываем наш кастомный класс, который потом добавляем в свои сервисы(делаем инъекцию) в Startup.cs
    //  ITestOutputHelper инъекция делается для регистрации сервиса, который находится под капотом у Xunit в Startup классе
    public class XunitLogger : IXunitLogger
    {
        private readonly ITestOutputHelperAccessor _testOutputHelperAccessor;

        public XunitLogger(ITestOutputHelperAccessor testOutputHelperAccessor)
        {
            _testOutputHelperAccessor = testOutputHelperAccessor;
        }

        public ITestOutputHelper OutputHelper => _testOutputHelperAccessor.Output;
    }
}