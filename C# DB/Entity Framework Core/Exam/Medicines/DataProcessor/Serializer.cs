namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Extensions;
    using Microsoft.Data.SqlClient.Server;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {

            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(m => m.Medicine.ProductionDate > DateTime.Parse(date)))

                .Select(p => new ExportPatient()
                {
                    Gender = p.Gender.ToString().ToLower(),
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines.Where(m => m.Medicine.ProductionDate > DateTime.Parse(date))
                    .OrderByDescending(m => m.Medicine.ExpiryDate)
                    .ThenBy(m => m.Medicine.Price)
                    .Select(m => new ExportMedicineXML()
                    {
                        Category = m.Medicine.Category.ToString().ToLower(),
                        Name = m.Medicine.Name,
                        Price = m.Medicine.Price.ToString("F2"),
                        Producer = m.Medicine.Producer.ToString(),
                        BestBefore = m.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    })

                    .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Count())
                .ThenBy(p => p.Name)
                .ToArray();

            return XmlSerializationExtension.SerializeToXml(patients, "Patients");
        }

            public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m=>m.Category==(Category)medicineCategory&&m.Pharmacy.IsNonStop==true)
                 .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m=>new ExportMedicine()
                {
                    Name= m.Name,
                    Price=m.Price.ToString("F2"),
                    Pharmacy= new ExportPharmacy()
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }


                })
                .ToArray();
                

            return JsonConvert.SerializeObject(medicines,Formatting.Indented);

        }
    }
}
