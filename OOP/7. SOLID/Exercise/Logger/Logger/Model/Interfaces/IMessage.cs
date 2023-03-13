using CustomLogger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Model.Interfaces
{
    public interface IMessage
    {
        ReportLevel ReportLevel { get;  }
        string TimeCreated { get;  }
        string Text { get; }
    }
}
