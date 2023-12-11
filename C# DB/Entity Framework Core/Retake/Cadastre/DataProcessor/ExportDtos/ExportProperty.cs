using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ExportDtos
{
    public class ExportProperty
    {
        public string PropertyIdentifier { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }

        public string DateOfAcquisition { get; set; }

        public ExportOwners[] Owners { get; set; }

    }
}
