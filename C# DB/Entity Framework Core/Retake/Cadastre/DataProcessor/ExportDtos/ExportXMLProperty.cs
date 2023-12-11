using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    [XmlType("Property")]
    public class ExportXMLProperty
    {
        [XmlAttribute("postal-code")]
        public string PostalCode { get; set; }

        public string PropertyIdentifier { get; set; }
        public string Area { get; set; }
        public string DateOfAcquisition { get; set; }

    }
}
