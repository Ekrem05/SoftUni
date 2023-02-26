namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < times; i++)
            {
                list.Add(Console.ReadLine());
            }
            string element= Console.ReadLine();
            Console.WriteLine( ReturnCountOfTheGreaterOnes(list, element)); 

        }
        public static int ReturnCountOfTheGreaterOnes<T>( List<T>list, T element)
        {
            int count=0;
            foreach (var item in list)
            {
                if (item.ToString().CompareTo(element)>0)
                {
                    count++;
                }

            }

            return count;
        }
    }
}