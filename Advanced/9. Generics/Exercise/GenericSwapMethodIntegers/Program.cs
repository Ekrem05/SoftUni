using System.Net;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < times; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            int[]indexes=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Swap(list, indexes[0], indexes[1]);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
        public static void Swap<T>(List<T> list,int index1,int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

    }
}