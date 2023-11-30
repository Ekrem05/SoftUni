using Boardgames.Data.Models.Enums;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    
    public class ExportBoardgameDto
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Mechanics { get; set; }
        public string Category { get; set; }
    }
}