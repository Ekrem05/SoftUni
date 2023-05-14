﻿using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models.Supplement
{
    public abstract class Supplement : ISupplement
    {
        protected Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }       
        public int InterfaceStandard
        {
            get;
            private set;
        }

        public int BatteryUsage
        {
            get;
            private set;
        }
    }
}
