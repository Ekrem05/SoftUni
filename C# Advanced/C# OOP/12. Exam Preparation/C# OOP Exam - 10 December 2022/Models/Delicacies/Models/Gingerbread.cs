using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies.Models
{
    public class Gingerbread : Delicacy
    {
        private const double gignerbreadPrice = 4.00;
        public Gingerbread(string name) : base(name, gignerbreadPrice)
        {
        }
    }
}
