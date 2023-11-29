namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Text;
    using Extensions;
    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientInvoicesDto()
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    InvoicesCount = c.Invoices.Count,
                    Invoices = c.Invoices
                    .OrderBy(i => i.IssueDate)
                    .ThenByDescending(i => i.DueDate)
                    .Select(i => new ExportInvoiceDto()
                    {
                        InvoiceNumber = i.Number,
                        InvoiceAmount = i.Amount,
                        DueDate = i.DueDate.ToString("MM/dd/yyyy"),
                        Currency = i.CurrencyType
                    }).ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.ClientName)
                .ToArray();

            return XmlSerializationExtension
                .SerializeToXml<ExportClientInvoicesDto[]>(clients,"Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            StringBuilder result = new();

            var products = context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new ExportProductDto()
                {
                    Name = p.Name,
                    Price = decimal.Parse(p.Price.ToString("0.##")),
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                     .Where(c => c.Client.Name.Length >= nameLength)
                    .Select(c => new ExportClientDto()
                    {
                        Name = c.Client.Name,
                        NumberVat = c.Client.NumberVat,
                    })
                     .OrderBy(c => c.Name)
                     .ToArray()

                }).OrderByDescending(ep => ep.Clients.Length)
                .ThenBy(ep => ep.Name).Take(5).ToArray();


            return JsonConvert.SerializeObject(products, Formatting.Indented
            //    ,new JsonSerializerSettings()
            //{
            //    Converters = new List<JsonConverter>()
            //    {
            //        new StringEnumConverter()
            //    }
            //}
                );

                

        }
    }
}