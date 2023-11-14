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
            //Console.WriteLine(ImportUsers(new ProductShopContext(),userJson));

            string productsJson = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportProducts(new ProductShopContext(), productsJson));


            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(new ProductShopContext(), categoriesJson));
            Console.WriteLine(GetProductsInRange(new ProductShopContext()));

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
    }
}