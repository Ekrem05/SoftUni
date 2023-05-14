using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models.Robot
{
    public class IndustrialAssistant : Robot
    {
        public IndustrialAssistant(string model) : base(model, 40000, 5000)
        {
        }
    }
}
