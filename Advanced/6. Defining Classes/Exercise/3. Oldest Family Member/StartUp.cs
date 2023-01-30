using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();
           
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                
                Person person = new Person(name,age);
                family.AddMember(person);
            }
           Person oldestPersonInFamily=family
                .GetOldestMember();
            Console.WriteLine($"{oldestPersonInFamily.Name} {oldestPersonInFamily.Age}");
          
        }
    }
}
