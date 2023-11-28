using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data
{
    public static class Validations
    {
        public const int ProductNameMaxLength = 30;
        public const int ProductNameMinLength = 9;

        public const decimal PriceMax = 1000.00m;
        public const decimal PriceMin = 5.00m;

        public const int StreetNameMax = 20;
        public const int StreetNameMin = 10;

        public const int CityNameMax = 15;
        public const int CityNameMin = 5;

        public const int CountryNameMax = 15;
        public const int CountryNameMin = 5;

        public const int InvoiceNumberMax = 1500000000;
        public const int InvoiceNumberMin = 1000000000;

        public const int ClientNameMax = 25;
        public const int ClientNameMin = 10;

        public const int ClientNumberVatMax = 15;
        public const int ClientNumberVatMin = 10;

    }
}
