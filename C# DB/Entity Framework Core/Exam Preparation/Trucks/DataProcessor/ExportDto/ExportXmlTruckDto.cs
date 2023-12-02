using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportXmlTruckDto
    {
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
    }
}