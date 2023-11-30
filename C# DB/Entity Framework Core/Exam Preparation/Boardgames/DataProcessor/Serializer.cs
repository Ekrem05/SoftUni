namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Extensions;
    using Microsoft.EntityFrameworkCore.ValueGeneration;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            ExportCreatorsDto[] creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorsDto()
                {
                    CreatorName = c.FirstName + " " + c.LastName,
                    BoardgamesCount = c.Boardgames.Count(),
                    Boardgames = c.Boardgames
                    .Select(b => new ExportXmlBoardGameDto()
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished
                    })
                    .OrderBy(b => b.BoardgameName)
                    .ToArray()

                })
                .OrderByDescending(comparer => comparer.Boardgames.Count())
                .ThenBy(c => c.CreatorName)
               .ToArray();
            //var creators = context.Creators
            //.Where(c => c.Boardgames.Any())
            //    .Select(c => new ExportCreatorsDto()
            //    {
            //        CreatorName = c.FirstName + " " + c.LastName,
            //        BoardgamesCount = c.Boardgames.Count(),
            //        Boardgames = c.Boardgames
            //            .Select(bg => new ExportXmlBoardGameDto()
            //            {
            //                BoardgameName = bg.Name,
            //                BoardgameYearPublished = bg.YearPublished
            //            })
            //            .OrderBy(bg => bg.BoardgameName)
            //            .ToArray()
            //    })
            //    .OrderByDescending(c => c.BoardgamesCount)
            //    .ThenBy(c => c.CreatorName)
            //    .ToArray();

            return XmlSerializationExtension.SerializeToXml<ExportCreatorsDto[]>(creators,"Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            ExportSellerDto[] sellers = context.Sellers
               .Where(s => s.BoardgamesSellers
               .Any(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating))
               .Select(s => new ExportSellerDto()
               {
                   Name = s.Name,
                   Website = s.Website,
                   Boardgames = s.BoardgamesSellers
                   .Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
                   .Select(b => new ExportBoardgameDto()
                   {
                       Name = b.Boardgame.Name,
                       Rating = b.Boardgame.Rating,
                       Mechanics = b.Boardgame.Mechanics,
                       Category = b.Boardgame.CategoryType.ToString()
                   })
                   .OrderByDescending(b => b.Rating)
                   .ThenBy(b => b.Name)
                   .ToArray()
               })
               .OrderByDescending(s => s.Boardgames.Count())
               .ThenBy(s => s.Name)
               .Take(5)
               .ToArray();

            return JsonConvert.SerializeObject(sellers,Formatting.Indented);
        }
    }
}