using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto
{
    public class ExportTruckDto
    {
        public string TruckRegistrationNumber { get; set; }
        public string VinNumber { get; set; }

        public int TankCapacity { get; set; }

        public int CargoCapacity { get; set; }

        public string CategoryType { get; set; }
        public string MakeType { get; set; }



    }
}