using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{

    public class RandomList:List<string>
    {
        public List<string> list=new List<string>();
        public string RandomString()
        {
            Random randomString=new Random();
            int num=randomString.Next();
            string c=num.ToString();
            this.list.Remove(c);
            return c;
        }
    }
}
