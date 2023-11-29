using Invoices.Data.Models.Enums;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class ExportInvoiceDto
    {
        public int InvoiceNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string DueDate { get; set; }
        public CurrencyType Currency { get; set; }


    }
}