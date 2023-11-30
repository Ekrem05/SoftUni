using Boardgames.Extensions;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var creators = XmlSerializationExtension
                .DeserializeFromXml<ImportCreatorDto[]>(xmlString, "Creators");
            StringBuilder result = new();
            List<Creator> validCreators = new();
            foreach (ImportCreatorDto creator in creators)
            {
                if (!IsValid(creator))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                Creator creatorToAdd = new Creator() { 
                    FirstName = creator.FirstName,
                    LastName = creator.LastName
                };
                foreach (var boardgame in creator.BoardGames)
                {
                    if (!IsValid(boardgame))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    creatorToAdd.Boardgames.Add(new Boardgame()
                    {
                        Name = boardgame.Name,
                        Rating = boardgame.Rating,
                        YearPublished = boardgame.YearPublished,
                        CategoryType = (CategoryType)boardgame.CategoryType,
                        Mechanics=boardgame.Mechanics
                    });
                }
                validCreators.Add(creatorToAdd);
                context.Creators.AddRange(validCreators);
                result.AppendLine(string
                    .Format(SuccessfullyImportedCreator,creatorToAdd.FirstName,creatorToAdd.LastName, creatorToAdd.Boardgames.Count));
            }
            context.SaveChanges();
            return result.ToString().TrimEnd();

        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sellers = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);
            StringBuilder result = new();
            List<Seller> validSellers = new();
            var boardgameIds=context.Boardgames.Select(b=>b.Id).ToList();
            foreach (var seller in sellers)
            {
                if (!IsValid(seller))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                var sellerToAdd = new Seller()
                {
                    Name = seller.Name,
                    Address = seller.Address,
                    Country = seller.Country,
                    Website=seller.Website,
                };
                foreach (var boardgameId in seller.BoardGames.Distinct()) 
                {
                    if (!boardgameIds.Contains(boardgameId))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    sellerToAdd.BoardgamesSellers.Add(new BoardgameSeller()
                    {
                        BoardgameId = boardgameId
                    });
                }
                result.AppendLine(string
                    .Format(SuccessfullyImportedSeller, sellerToAdd.Name, sellerToAdd.BoardgamesSellers.Count));
                validSellers.Add (sellerToAdd);
            }
            context.Sellers.AddRange(validSellers);
            context.SaveChanges();
            return result.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
