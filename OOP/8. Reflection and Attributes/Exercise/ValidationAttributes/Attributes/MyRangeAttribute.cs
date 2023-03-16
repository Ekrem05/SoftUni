using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public  class MyRangeAttribute:MyValidationAttribute
    {
        private int min;
        private int max;
        public MyRangeAttribute(int minValue, int MaxValue) 
        {
            min = minValue;
            max = MaxValue;
        }
        public override bool IsValid(object obj)
        {
            if ((int)obj>=min&&(int)obj<max)
            {
                return true;
            }
            return false;
        }
    }
}
