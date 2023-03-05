namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ICalllable phone;
            IBrowsable stationary;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length==10)
                {
                    phone = new Smartphone();
                    try
                    {
                        phone.Call(input[i]);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    phone=new StationaryPhone();
                    try
                    {
                        phone.Call(input[i]);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    
                }
            }
            for (int i = 0; i < urls.Length; i++)
            {
                
                    stationary = new Smartphone();
                    try
                    {
                        stationary.Browse(urls[i]);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                
              
            }
        }
    }
}