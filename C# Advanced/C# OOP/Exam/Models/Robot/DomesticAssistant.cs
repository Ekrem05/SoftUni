using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models.Robot
{
    public class DomesticAssistant : Robot
    {
        public DomesticAssistant(string model) : base(model, 20000, 2000)
        {
        }
    }
}
