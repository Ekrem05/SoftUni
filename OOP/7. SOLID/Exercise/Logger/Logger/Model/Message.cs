using CustomLogger.Enums;
using CustomLogger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Model
{
    public class Message : IMessage
    {
        public Message(string timecreated,string message,ReportLevel rep)
        {
            ReportLevel= rep;
            TimeCreated= timecreated;
            Text = message;

        }
        public ReportLevel ReportLevel { get; private set; }

        public string TimeCreated { get; private set; }

        public string Text{ get; private set; }
    }
}
