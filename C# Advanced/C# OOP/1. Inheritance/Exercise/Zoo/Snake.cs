using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Snake: Reptile
    {
        public Snake(string name) : base(name)
        {
            Name = name;
        }
        public override string Name { get { return base.Name; } set { base.Name = value; } }
    }
}
