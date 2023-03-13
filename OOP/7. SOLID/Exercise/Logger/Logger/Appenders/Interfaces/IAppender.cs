using CustomLogger.Enums;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Appenders.Interfaces
{
    public interface IAppender
    {
        public ILayout Layout { get;  }
        ReportLevel ReportLevel { get; }
        void Append(IMessage message);
    }
}
