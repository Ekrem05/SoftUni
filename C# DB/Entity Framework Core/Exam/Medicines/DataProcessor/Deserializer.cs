namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Extensions;
    using Microsoft.Data.SqlClient.Server;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {

            var patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            List<Patient> patients = new();
            StringBuilder sb = new StringBuilder();

            foreach (var patient in patientDtos)
            {
                if (!IsValid(patient)||
                    !Enum.IsDefined(typeof(Gender),patient.Gender)||
                    !Enum.IsDefined(typeof(AgeGroup), patient.AgeGroup)
                    )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Patient patientNew = new Patient()
                {
                    FullName = patient.FullName,
                    AgeGroup = (AgeGroup)patient.AgeGroup,
                    Gender = (Gender)patient.Gender,
                };
                foreach (var id in patient.Medicines)
                {
                    int[]ids=patientNew.PatientsMedicines.Select(m=>m.MedicineId).ToArray();
                    if (ids.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    patientNew.PatientsMedicines.Add(new PatientMedicine()
                    {
                        MedicineId = id,
                    });
                    
                }
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patientNew.PatientsMedicines.Count));
                patients.Add(patientNew);
            }
            context.Patients.AddRange(patients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var pharmacies = XmlSerializationExtension.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");
            List<Pharmacy> pharmaciesValid = new();
            StringBuilder sb= new StringBuilder();
            foreach (var pharmacy in pharmacies)
            {
                if (!IsValid(pharmacy))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (pharmacy.IsNonStop!="true"&&pharmacy.IsNonStop!="false")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
               
                Pharmacy ph = new Pharmacy()
                {
                    Name = pharmacy.Name,
                    PhoneNumber = pharmacy.PhoneNumber,
                    IsNonStop = bool.Parse(pharmacy.IsNonStop)
                };
                foreach (var medicine in pharmacy.Medicines)
                {
                    if (!IsValid(medicine))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (string.IsNullOrEmpty(medicine.ProductionDate)||
                        string.IsNullOrEmpty(medicine.ExpiryDate)||
                        !Enum.IsDefined(typeof(Category), medicine.Category))
                    {

                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime productionDate = 
                        DateTime.ParseExact(medicine.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime expiryDate =
                      DateTime.ParseExact(medicine.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    if (productionDate>=expiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (ph.Medicines.Any(m => m.Name == medicine.Name && m.Producer == medicine.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    ph.Medicines.Add(new Medicine()
                    {
                        Name = medicine.Name,
                        Price=medicine.Price,
                        Category = (Category)medicine.Category,
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = medicine.Producer,
                    });
                }
                pharmaciesValid.Add(ph);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, ph.Name, ph.Medicines.Count));

            }
            context.Pharmacies.AddRange(pharmaciesValid);
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
