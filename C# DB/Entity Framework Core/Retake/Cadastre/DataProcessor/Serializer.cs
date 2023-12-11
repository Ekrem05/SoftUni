using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Extensions;
using Newtonsoft.Json;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            DateTime dateTime = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var properties = dbContext.Properties
                 .Where(p => p.DateOfAcquisition >= dateTime)
                  .OrderByDescending(p => p.DateOfAcquisition)
                 .ThenBy(p => p.PropertyIdentifier)
                 .Select(p => new ExportProperty()
                 {
                     PropertyIdentifier = p.PropertyIdentifier,
                     Area = p.Area,
                     Address = p.Address,
                     DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens.Select(pc => new ExportOwners()
                     {
                         LastName = pc.Citizen.LastName,
                         MaritalStatus = pc.Citizen.MaritalStatus.ToString(),
                     })
                     .OrderBy(c => c.LastName)
                     .ToArray()
                 })
                
                 .ToArray();

            return JsonConvert.SerializeObject(properties,Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                 .Where(p => p.Area >= 100)
                 .OrderByDescending(p => p.Area)
                 .ThenBy(p => p.DateOfAcquisition)
                 .Select(p => new ExportXMLProperty()
                 {
                     PostalCode = p.District.PostalCode,
                     PropertyIdentifier = p.PropertyIdentifier,
                     Area = p.Area.ToString(),
                     DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy")
                 })
                 .ToArray();

            return XmlSerializationExtension.SerializeToXml(properties, "Properties");
        }
    }
}
