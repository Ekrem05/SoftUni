using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            //string userJson = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(new ProductShopContext(), userJson));

            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(new ProductShopContext(), productsJson));

            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(new ProductShopContext(), categoriesJson));

            //string categoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(new ProductShopContext(), categoryProducts));



            //Console.WriteLine(GetProductsInRange(new ProductShopContext()));
            //Console.WriteLine(GetSoldProducts(new ProductShopContext()));
            Console.WriteLine(GetCategoriesByProductsCount(new ProductShopContext()));

        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User>users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            foreach (var catregory in categories)
            {
                if (catregory.Name!=null) context.Categories.Add(catregory);
                
            }
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {

            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products=context.Products
                .Select(x => new
                {
                    name=x.Name,
                    price=x.Price,
                    seller=$"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                 .Where(p => p.price >= 500 && p.price <= 1000)
                 .OrderBy(p => p.price)
                .ToList();
            string json=JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        buyerFirstName = x.Buyer.FirstName,
                        buyerLastName = x.Buyer.LastName,

                    })
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName);

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
               .Select(c => new
               {
                   category = c.Name,
                   productsCount = c.CategoriesProducts.Count,
                   averagePrice = c.CategoriesProducts.Average(c => c.Product.Price).ToString("f2"),
                   totalRevenue = c.CategoriesProducts.Sum(c => c.Product.Price).ToString("f2"),
               })
               .OrderByDescending(c => c.productsCount);

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }
    }
}