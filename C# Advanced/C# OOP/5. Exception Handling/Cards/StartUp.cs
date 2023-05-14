namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(", ");
            List<Card> list = new();
            for (int i = 0; i < array.Length; i++)
            {
                string[] card = array[i].Split(" ");
                string face = card[0];
                string suit = card[1];
                
                try
                {   Card card1=new(face,suit);
                   list.Add(card1);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(string.Join(" ",list));

        }
    }
    public class Card
    {
        private List<string> faces = new List<string>() {
            "2","3","4","5","6","7","8","9","10","J","Q","K","A"
        };
        private Dictionary<string, string> suits = new Dictionary<string, string>()
        {
            { "S","\u2660"},
            { "H","\u2665"},
            { "D","\u2666"},
            { "C","\u2663"}
        };

        public Card(string face, string suit)
        {
            if (Validation(face, suit))
            {
                Face = face;
                Suit = suit;

            }

        }

        public string Face { get; set; }
        public string Suit { get; set; }

        public override string ToString()
        {
            if (Validation(Face, Suit))
            {
                return $"[{Face}{suits[Suit]}]";
            }
            return null;

        }
        public bool Validation(string face, string suit)
        {
            if (faces.Contains(face) && suits.ContainsKey(suit))
            {
                return true;
            }

            throw new ArgumentException("Invalid card!");
        }
    }
}