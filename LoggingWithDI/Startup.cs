using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace LoggingWithDI
{
    public class Startup
    {
        // Регистрируем наши сервисы, наша программа начнется отсюда и создаст классы объектов при вызове
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IXunitLogger, XunitLogger>();
            services.AddTransient<ICalculator, Calculator>();
        }

        // Метод для конфигурирования уровня логгирования, если изменить модификатор доступа 'public', xunit будет игнорировать желаемый уровень логгирования
        public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
        {
            loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor, (s, level) => level >=
                LogLevel.Debug && level < LogLevel.None));
        }
    }
}