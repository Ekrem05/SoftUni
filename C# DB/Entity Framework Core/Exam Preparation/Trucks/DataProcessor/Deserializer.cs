
namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var despatchers = XmlSerializationExtension.DeserializeFromXml<ImportDespatcherDto[]>(xmlString, "Despatchers");
            StringBuilder sb=new StringBuilder();
            List<Despatcher> despatchersList = new();
            foreach (var despatcherDto in despatchers)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Despatcher despatcher = new Despatcher() {
                    Name=despatcherDto.Name,
                    Position=despatcherDto.Position
                };
                foreach (var truck in despatcherDto.Trucks)
                {
                    if (!IsValid(truck ))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    despatcher.Trucks.Add(new Truck()
                    {
                        RegistrationNumber = truck.RegistrationNumber,
                        VinNumber = truck.VinNumber,
                        TankCapacity = truck.TankCapacity,
                        CargoCapacity = truck.CargoCapacity,
                        CategoryType = (CategoryType)truck.CategoryType,
                        MakeType = (MakeType)truck.MakeType,
                        DespatcherId=despatcher.Id,
                    });
                }
                despatchersList.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher,despatcher.Name,despatcher.Trucks.Count()));
            }
            context.Despatchers.AddRange(despatchersList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
           var clients = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Client> clientList = new();
            List<int>ids=context.Trucks.Select(x=>x.Id).ToList();
            foreach (var client in clients)
            {
                if (!IsValid(client)||client.Type=="usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Client clientToAdd = new Client()
                {
                    Name = client.Name,
                    Nationality = client.Nationality,
                    Type = client.Type
                };
                foreach (var id in client.Trucks.Distinct())
                {
                    if (!ids.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    clientToAdd.ClientsTrucks.Add(new ClientTruck()
                    {
                        TruckId = id,
                    });
                    
                }
                clientList.Add(clientToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, clientToAdd.Name, clientToAdd.ClientsTrucks.Count()));
            }
            context.Clients.AddRange(clientList);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}