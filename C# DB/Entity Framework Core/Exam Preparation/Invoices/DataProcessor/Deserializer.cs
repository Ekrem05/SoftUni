namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Invoices.Data;
    using Extensions;
    using Invoices.DataProcessor.ImportDto;
    using System.Text;
    using Invoices.Data.Models;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var clients = XmlSerializationExtension
                .DeserializeFromXml<List<ImportClientDto>>(xmlString, "Clients");
            StringBuilder sb=new StringBuilder();
            List<Client>validClients=new List<Client>();
            foreach (var client in clients)
            {
                if (!IsValid(client))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client clientToAdd = new Client()
                {
                    Name = client.Name,
                    NumberVat= client.NumberVat,
                };
                foreach (var address in client.Addresses)
                {
                    if (!IsValid(address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    clientToAdd.Addresses.Add(new Address()
                    {
                        StreetName = address.StreetName,
                        StreetNumber = address.StreetNumber,
                        PostCode = address.PostCode,
                        City = address.City,
                        Country = address.Country,
                    });

                }
                validClients.Add(clientToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedClients,clientToAdd.Name));
            }
            context.Clients.AddRange(validClients);
            context.SaveChanges();
           

            return sb.ToString().TrimEnd();
        }

        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var invoices=JsonConvert.DeserializeObject<List<ImportInvoiceDto>>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Invoice>validInvoices=new List<Invoice>();
            foreach (var invoice in invoices)
            {
                if (!IsValid(invoice) || invoice.DueDate < invoice.IssueDate)
                {
                    sb.AppendLine(ErrorMessage); continue;
                }
                validInvoices.Add(new Invoice()
                {
                    Number = invoice.Number,
                    IssueDate = invoice.IssueDate,
                    DueDate = invoice.DueDate,
                    Amount = invoice.Amount,
                    CurrencyType = invoice.CurrencyType,
                    ClientId = invoice.ClientId
                });
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }
            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var products=JsonConvert.DeserializeObject<List<ImportProductDto>>(jsonString);
            List<int>clientIds=context.Clients.Select(c=>c.Id).ToList();
            StringBuilder sb = new StringBuilder();
            List<Product> validProducts=new List<Product>();
            foreach (var product in products)
            {

                if (!IsValid(product))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Product productToAdd = new Product()
                {
                    Name = product.Name,
                    Price= product.Price,   
                    CategoryType= product.CategoryType,

                };
                foreach (var id in product.Clients.Distinct())
                {
                    if (clientIds.Contains(id))
                    {
                        productToAdd.ProductsClients.Add(new ProductClient()
                        {
                            ClientId = id
                        });
                        continue;
                    }
                    sb.AppendLine(ErrorMessage);
                    
                }
                validProducts.Add(productToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts,product.Name, productToAdd.ProductsClients.Count()));
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
