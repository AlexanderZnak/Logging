using Xunit.Abstractions;

namespace LoggingWithDI
{
    public interface IXunitLogger
    {
        ITestOutputHelper OutputHelper { get; }
    }
}