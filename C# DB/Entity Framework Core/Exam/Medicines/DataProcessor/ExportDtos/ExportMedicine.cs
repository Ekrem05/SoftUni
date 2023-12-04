using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.DataProcessor.ExportDtos
{
    public class ExportMedicine
    {
        public string Name { get; set; }
        public string Price{ get; set; }

        public ExportPharmacy Pharmacy { get; set; }
    }
}
