using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           
            List<Person> list = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
               list.Add(person);
            }
            List<Person> olderThanThiry = new();
            foreach (var item in list)
            {
                if (item.Age>30)
                {
                    olderThanThiry.Add(item);
                }
            }
            foreach (var item in olderThanThiry.OrderBy(p=>p.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
           ;
        }
    }
}
