using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Medicine")]
    public class ExportMedicineXML
    {
        public string Name{ get; set; }
        public string Price { get; set; }
        public string Producer { get; set; }
        public string BestBefore { get; set; }
        [XmlAttribute("Category")]
        public string Category { get; set; }



    }
}
