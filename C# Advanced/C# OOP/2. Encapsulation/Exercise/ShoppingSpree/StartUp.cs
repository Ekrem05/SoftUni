namespace ShoppingSpree
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            { string[] line = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();
            for (int i = 0; i < line.Length; i++)
            {
                string values = line[i];
                string[] split=values.Split('=');
                string name = split[0];
                double value = double.Parse(split[1]);
                Person person = new(name, value);
                persons.Add(person);
            }
            string[] line2 = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            for (int i = 0; i < line2.Length; i++)
            {
                string values = line2[i];
                string[] split = values.Split('=');
                string name = split[0];
                double value = double.Parse(split[1]);
                Product product = new(name, value);
                products.Add(product);
            }
            string message = string.Empty;
            while ((message=Console.ReadLine())!="END")
            {
                string[] input = message.Split(" ");
                string name = input[0];
                string productName = input[1];
                Person currentPerson = persons.Find(x => x.Name == name);
                Product currentProduct = products.Find(x => x.Name == productName);
                if (currentPerson.Money>= currentProduct.Cost)
                {
                    currentPerson.BagOfProducts.Add(currentProduct);
                        Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                        currentPerson.Money -= currentProduct.Cost;
                }
                    else
                    {
                        Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                    }
            }
                foreach (var item in persons)
                {
                    if (item.BagOfProducts.Count>0)
                    {
                        Console.WriteLine($"{item.Name} - "+string.Join(", ",item.BagOfProducts).ToString());
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} - Nothing bought");
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

           


        }
    }
}