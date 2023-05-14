using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Layouts.Interfaces
{
    public interface ILayout
    {
        string Format { get; }
    }
}
