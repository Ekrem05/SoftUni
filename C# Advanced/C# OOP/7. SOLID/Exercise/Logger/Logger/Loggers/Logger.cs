using CustomLogger.Appenders.Interfaces;
using CustomLogger.Enums;
using CustomLogger.Loggers.Interfaces;
using CustomLogger.Model;
using CustomLogger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender>appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders= appenders;
        }
        public void Critical(string dateTime, string message)
        {
            Appender(dateTime, message,ReportLevel.critical );
        }

        public void Error(string dateTime, string message)
        {
            Appender(dateTime, message, ReportLevel.error);
        }

        public void Fatal(string dateTime, string message)
        {
            Appender(dateTime, message, ReportLevel.fatal);
        }

        public void Info(string dateTime, string message)
        {
            Appender(dateTime, message, ReportLevel.info);
        }

        public void Warning(string dateTime, string message)
        {
            Appender(dateTime, message, ReportLevel.warning);
        }
            private void Appender(string dateTime, string message,ReportLevel rep)
        {
            IMessage messageObject = new Message(dateTime, message, rep);
            foreach (var appender in appenders)
            {
                appender.Append(messageObject);
            }
        }
    }
}
