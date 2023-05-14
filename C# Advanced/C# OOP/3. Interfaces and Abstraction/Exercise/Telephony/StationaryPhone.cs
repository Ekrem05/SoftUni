using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone:ICalllable
    {

        public void Call(string number)
        {
            bool valid = true;
            char[] elements = number.ToCharArray();
            for (int i = 0; i < elements.Length; i++)
            {
                if (!Char.IsDigit(elements[i]))
                {
                    valid = false;
                    throw new ArgumentException("Invalid number!");
                }
            }
            if (valid)
            {
                Console.WriteLine($"Dialing... {number}");
            }
            
        }
    }
}
