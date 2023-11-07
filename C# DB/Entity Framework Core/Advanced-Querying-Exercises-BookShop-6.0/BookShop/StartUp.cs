namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
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
    }
}


