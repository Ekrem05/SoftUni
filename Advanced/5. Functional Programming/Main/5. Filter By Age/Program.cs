using _5._Filter_By_Age;
int n=int.Parse(Console.ReadLine());
List<Person>list=new List<Person>();
for (int i = 0; i <n; i++)
{
    string[] input = Console.ReadLine().Split(", ");
    Person person = new(input[0], int.Parse(input[1]));
    list.Add(person);
}
string filterType = Console.ReadLine();
int value = int.Parse(Console.ReadLine());
Func<Person, int, bool> filter = Filter(filterType);
list = list.Where(p => filter(p, value)).ToList();
Action<Person> formatter = Formatter(Console.ReadLine());
foreach (var item in list)
{
    formatter(item);
}
Func<Person, int, bool> Filter(string filterType)
{
    if (filterType=="younger")
    {
        return (p, x) => p.Age<x; 
    }
    else 
    {
        return (p, x) => p.Age >= x;
    }

}
Action<Person>Formatter(string foramtType)
{
    if (foramtType == "name age")
    {
        return p => Console.WriteLine($"{p.Name} - {p.Age}");
    }
    else if (foramtType == "name")
    {
        return p => Console.WriteLine($"{p.Name}");
    }
    else if (foramtType == "age")
    {
        return p => Console.WriteLine($"{p.Age}");
    }
    return  null;

}
namespace _5._Filter_By_Age
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string n, int a)
        {
            this.Name = n;
            this.Age = a;
        }
    }
}
