using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models.Enums;
using Trucks.Data.Models;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [Required]
        [StringLength(8)]
        [RegularExpression("[A-Z]{2}\\d{4}[A-Z]{2}")]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(17)]
        public string VinNumber { get; set; }

        [Required]
        [Range(950,1420)]
        public int TankCapacity { get; set; }

        [Required]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        [Required]
        public int CategoryType { get; set; }

        [Required]
        public int MakeType { get; set; }


    }
}
