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
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            Layout=layout;
        }
        public ReportLevel ReportLevel => throw new NotImplementedException();
        public ILayout Layout { get; set; }
        public void Append(IMessage message)
        {
            string formattedString=string.Format(Layout.Format,message.TimeCreated,message.ReportLevel,message.Text.ToString());
            File.AppendAllText("appendedText.txt",formattedString);
        }
    }
}
