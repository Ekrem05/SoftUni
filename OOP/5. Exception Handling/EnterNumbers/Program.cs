namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                ReadNumber(1, 100);
            
        }
         static void  ReadNumber(int start,int end)
        {
            List<int> numbers = new();
            int currentNumber=1;
            for (int i = 0; i < 10; i++)
            {
                int number = 0;
                
                try
                {  number= int.Parse(Console.ReadLine());
                    if (number <= start || number >= end||number<currentNumber)
                    {
                        throw new ArgumentException($"Your number is not in range {currentNumber} - 100!");
                    
                    }
                    numbers.Add(number);
                }
                catch(FormatException ez)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
                
                currentNumber = number;

            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }

}