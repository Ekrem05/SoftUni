namespace EnergyDrinks
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int>miligrams=new Stack<int>();
            Queue<int> drinks=new Queue<int>();
            int[] mg = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] dr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < mg.Length; i++)
            {
                miligrams.Push(mg[i]);
            }
            for (int i = 0; i < dr.Length; i++)
            {
                drinks.Enqueue(dr[i]);
            }
            int caffeineIntake = 0;
            while (drinks.Count>0&&miligrams.Count>0)
            {
                 
                int currentDose = miligrams.Peek() * drinks.Peek();
                if (currentDose+caffeineIntake<=300)
                {
                    caffeineIntake += currentDose;
                    miligrams.Pop();
                    drinks.Dequeue();
                }
                else
                {
                    miligrams.Pop();
                    int replacedDrink = drinks.Dequeue();
                    drinks.Enqueue(replacedDrink);
                    if (caffeineIntake-30>0)
                    {
                        caffeineIntake -= 30;

                    }
                    else
                    {
                        caffeineIntake = 0;
                    }
                    
                }

            }
            if (drinks.Count > 0)
            {
               
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {caffeineIntake} mg caffeine.");
            
        }
    }
}