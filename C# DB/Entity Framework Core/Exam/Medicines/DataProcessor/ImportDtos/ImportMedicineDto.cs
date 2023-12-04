using Medicines.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicineDto
    {
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Range(0.01,1000.00)]
        public decimal Price { get; set; }

        [Required]
        [XmlAttribute("category")]
        public int Category { get; set; }

        [Required]
        [RegularExpression("^\\d{4}-\\d{2}-\\d{2}$")]
        public string ProductionDate { get; set; }

        [Required]
        [RegularExpression("^\\d{4}-\\d{2}-\\d{2}$")]
        public string ExpiryDate { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Producer { get; set; }
    }
}