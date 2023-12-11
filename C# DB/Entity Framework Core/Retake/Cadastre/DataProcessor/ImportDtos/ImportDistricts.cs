using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistricts
    {
        [XmlAttribute("Region")]
        public string Region { get; set; }

        [Required]
        [MaxLength(80)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [StringLength(8)]
        [RegularExpression("^[A-Z]{2}-\\d{5}$")]
        public string PostalCode { get; set; }

        [XmlArray("Properties")]
        public ImportProperty[] Properties { get; set; }
    }
}
