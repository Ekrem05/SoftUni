using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTrackingSystem
{
    public interface IProduct
    {
        public string Name { get; set; }
        public int Quanity { get; set; }
        public decimal Price { get; set; }
    }
}
