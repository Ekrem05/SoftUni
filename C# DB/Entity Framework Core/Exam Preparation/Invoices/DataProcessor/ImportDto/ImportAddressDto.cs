using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Invoices.Data.Validations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressDto
    {

        [Required]
        [MaxLength(StreetNameMax)]
        [MinLength(StreetNameMin)]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(CityNameMax)]
        [MinLength(CityNameMin)]
        public string City { get; set; }

        [Required]
        [MaxLength(CountryNameMax)]
        [MinLength(CountryNameMin)]
        public string Country { get; set; }
    }
}