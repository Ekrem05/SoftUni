using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel= 1;
        }

        public double Cost
        {
            get;private set;
        }

        public int EnduranceLevel
        {
            get; private set;
        }

        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel == 20)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
            this.EnduranceLevel++;
        }
    }
}
