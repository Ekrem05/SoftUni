namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Extensions;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var districtsDto = XmlSerializationExtension
                .Deserialize<ImportDistricts[]>(xmlDocument, "Districts");
            List<District> districts = new List<District>();
            StringBuilder sb = new();


            foreach (var district in districtsDto)
            {
                if (!IsValid(district))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!Enum.IsDefined(typeof(Region), district.Region))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (dbContext.Districts.Any(d=>d.Name==district.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District newDistrict = new District()
                {
                    Region = (Region)Enum.Parse(typeof(Region), district.Region),
                    Name = district.Name,
                    PostalCode = district.PostalCode,

                };
                foreach (var property in district.Properties)
                {
                    if (!IsValid(property))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (string.IsNullOrEmpty(property.DateOfAcquisition))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (newDistrict.Properties
                        .Any(p=>p.PropertyIdentifier==property.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (dbContext.Properties
                      .Any(p => p.PropertyIdentifier == property.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (newDistrict.Properties
                       .Any(p => p.Address == property.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (dbContext.Properties
                      .Any(p => p.Address == property.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    newDistrict.Properties.Add(new Property()
                    {
                        PropertyIdentifier = property.PropertyIdentifier,
                        Area = property.Area,
                        Details = property.Details,
                        Address = property.Address,
                        DateOfAcquisition = DateTime.ParseExact(property.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    });

                }

                districts.Add(newDistrict);
                sb.AppendLine(string
                    .Format(SuccessfullyImportedDistrict,
                    newDistrict.Name,
                    newDistrict.Properties.Count()));

            }
            dbContext.AddRange(districts);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
           var citizensDto = JsonConvert.DeserializeObject<ImportCitizen[]>(jsonDocument);
            List<Citizen> citizens = new List<Citizen>();
            StringBuilder sb = new();

            foreach (var citizen in citizensDto)
            {
                if (!IsValid(citizen))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!Enum.IsDefined(typeof(MaritalStatus), citizen.MaritalStatus))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Citizen validCitizen = new Citizen()
                {
                    FirstName = citizen.FirstName,
                    LastName = citizen.LastName,
                    BirthDate = DateTime.ParseExact(citizen.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus),citizen.MaritalStatus),

                };
                foreach (var id in citizen.Properties)
                {
                    if (dbContext.Properties.Any(p=>p.Id==id))
                    {
                        validCitizen.PropertiesCitizens.Add(new PropertyCitizen()
                        {
                            PropertyId = id,
                        });
                    }
                   

                }
                citizens.Add(validCitizen);
                sb.AppendLine(string
                    .Format(SuccessfullyImportedCitizen,
                    validCitizen.FirstName,validCitizen.LastName,
                    validCitizen.PropertiesCitizens.Count()));

            }
            dbContext.Citizens.AddRange(citizens);
            dbContext.SaveChanges();


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
