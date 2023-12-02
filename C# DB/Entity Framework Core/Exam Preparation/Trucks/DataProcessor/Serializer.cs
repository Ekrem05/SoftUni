namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Text.Json.Serialization;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var Despatchers=context.Despatchers
                .Where(d=>d.Trucks.Any())
                .Select(d=>new ExportDespatcherDto()
                {
                    TrucksCount=d.Trucks.Count(),
                    DespatcherName=d.Name,
                    Trucks=d.Trucks.Select(d=>new ExportXmlTruckDto()
                    {
                        RegistrationNumber=d.RegistrationNumber,
                        Make=d.MakeType.ToString()
                    })
                    .OrderBy(t=>t.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(d=>d.TrucksCount).ThenBy(d=>d.DespatcherName)
                .ToArray();




            return Extensions.XmlSerializationExtension.SerializeToXml<ExportDespatcherDto[]>(Despatchers, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                 .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                 .ToArray()
                 .Select(c => new ExportClientDto()
                 {
                     Name = c.Name,
                     Trucks = c.ClientsTrucks
                    .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .OrderBy(ct => ct.Truck.MakeType.ToString())
                        .ThenByDescending(ct => ct.Truck.CargoCapacity)
                     .Select(c => new ExportTruckDto()
                     {
                         TruckRegistrationNumber = c.Truck.RegistrationNumber,
                         VinNumber = c.Truck.VinNumber,
                         TankCapacity = c.Truck.TankCapacity,
                         CargoCapacity = c.Truck.CargoCapacity,
                         CategoryType = c.Truck.CategoryType.ToString(),
                         MakeType = c.Truck.MakeType.ToString()
                     })
                     .ToArray()
                 })
                 .OrderByDescending(c => c.Trucks.Length)
                 .ThenBy(c => c.Name)
                 .Take(10)
                 .ToArray();
            //var clients = context
            //    .Clients
            //    .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
            //    .ToArray()
            //    .Select(c => new ExportClientDto()
            //    {
            //        Name=c.Name,
            //        Trucks = c.ClientsTrucks
            //            .Where(ct => ct.Truck.TankCapacity >= capacity)
            //            .ToArray()
            //            .OrderBy(ct => ct.Truck.MakeType.ToString())
            //            .ThenByDescending(ct => ct.Truck.CargoCapacity)
            //            .Select(ct => new ExportTruckDto()
            //            {
            //                TruckRegistrationNumber = ct.Truck.RegistrationNumber,
            //                VinNumber = ct.Truck.VinNumber,
            //                TankCapacity = ct.Truck.TankCapacity,
            //                CargoCapacity = ct.Truck.CargoCapacity,
            //                CategoryType = ct.Truck.CategoryType.ToString(),
            //                MakeType = ct.Truck.MakeType.ToString()
            //            })
            //            .ToArray()
            //    })
            //    .OrderByDescending(c => c.Trucks.Length)
            //    .ThenBy(c => c.Name)
            //    .Take(10)
            //    .ToArray();


            return JsonConvert.SerializeObject(clients,Formatting.Indented);



        }
    }
}
