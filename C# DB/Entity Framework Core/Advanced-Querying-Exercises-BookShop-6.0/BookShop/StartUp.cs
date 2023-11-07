namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;
    using System.Globalization;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            Console.WriteLine(CountCopiesByAuthor(db));
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            using (context)
            {
                Enum.TryParse<AgeRestriction>(command, true, out AgeRestriction ageRestriction);

                var books = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .Select(x => new
                    {
                        BookTitle = x.Title
                    })
                    .OrderBy(t=>t.BookTitle);
                StringBuilder sb=new();
                foreach (var item in books)
                {
                    sb.AppendLine(item.BookTitle.ToString());
                }

                return sb.ToString();
            }
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold&&b.Copies<5000)
                .OrderBy(b=>b.BookId)
                .Select(x => new
                {
                    x.Title
                });
            StringBuilder sb = new();
            foreach (var item in books)
            {
                sb.AppendLine(item.Title.ToString());
            }

            return sb.ToString();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(b => b.Price);
            StringBuilder sb = new();
            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} - ${item.Price:f2}");
            }

            return sb.ToString();

        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                });


            StringBuilder sb = new();
            foreach (var item in books)
            {
                sb.AppendLine(item.Title);
            }

            return sb.ToString();

        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categoriesToSearch = input.Split(' ').ToList();
            categoriesToSearch.ForEach(c => c.ToLower());
            var categoriesId = context.Categories
                .Where(c => categoriesToSearch.Contains(c.Name.ToLower()))
                .Select(x=>x.CategoryId)
                .ToList();
            var books = context.Books
                .Where(b => b.BookCategories.Any(c => categoriesId.Contains(c.CategoryId)))
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    b.Title,
                });
            StringBuilder sb = new();
            foreach (var item in books)
            {
                sb.AppendLine(item.Title);
            }

            return sb.ToString();


        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context.Books
             .Where(b => b.ReleaseDate<DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
             .OrderByDescending(b => b.ReleaseDate)
             .Select(b => new
             {
                 b.Title,
                 b.EditionType,
                 b.Price,
                 b.ReleaseDate

             });


            StringBuilder sb = new();
            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} - {item.EditionType} - ${item.Price:f2} {item.ReleaseDate}");
            }

            return sb.ToString();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName);
            StringBuilder sb = new();
            foreach (var item in authors)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }

            return sb.ToString();
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new
                {
                    x.Title
                })
                .OrderBy(x=>x.Title);

            StringBuilder sb = new();
            foreach (var item in books)
            {
                sb.AppendLine(item.Title);
            }

            return sb.ToString();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(x => new
                {
                    x.Title, x.Author
                });
            StringBuilder sb = new();
            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} ({item.Author.FirstName} {item.Author.LastName})");
            }

            return sb.ToString();

        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {

            var result = context.Authors
                .Select(x => new
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    Copies = x.Books.Sum(book => book.Copies)
                })
                .OrderByDescending(x=>x.Copies);

            StringBuilder sb = new();
            foreach (var item in result)
            {
                sb.AppendLine($"{item.Name} - {item.Copies}");
            }

            return sb.ToString();
        }
    }
}


