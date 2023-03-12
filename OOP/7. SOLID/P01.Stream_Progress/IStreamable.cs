using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Stream_Progress
{
    public interface IStreamable
    {
        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
