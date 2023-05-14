using CustomLogger.Appenders;
using CustomLogger.Appenders.Interfaces;
using CustomLogger.Layouts;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Loggers;
using CustomLogger.Loggers.Interfaces;

namespace CustomLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILayout layout = new SimpleLayout();
            IAppender appender = new ConsoleAppender(layout);
            ILogger logger = new Logger(appender,new FileAppender(layout));
            logger.Info("12.12.2002", "hello");
        }
    }
}