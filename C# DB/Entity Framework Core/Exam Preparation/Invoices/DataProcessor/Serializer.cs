namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Text;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            return "";
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