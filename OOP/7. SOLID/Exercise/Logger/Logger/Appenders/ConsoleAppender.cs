using CustomLogger.Appenders.Interfaces;
using CustomLogger.Enums;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout= layout;
        }
        public ReportLevel ReportLevel { get; set; }
        public ILayout Layout { get; private set; }
        public void Append(IMessage message)
        {
            
            Console.WriteLine(string.Format(Layout.Format,message.TimeCreated,message.ReportLevel,message.Text));
        }
    }
}
