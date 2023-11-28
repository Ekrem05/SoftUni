using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ExportDto
{
    public class ExportProductDto
    {
        public string Name { get; set; }
        public decimal Price{ get; set; }
        public string Category { get; set; }

        public ExportClientDto[] Clients { get; set; }

    }
}
