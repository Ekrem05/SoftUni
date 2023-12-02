using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.DataProcessor.ExportDto
{
    public class ExportClientDto
    {
        public string Name { get; set; }

        public ExportTruckDto[] Trucks { get; set; }

    }
}
