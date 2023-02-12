using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;
       
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int 	StorageCapacity  { get; set; }
        public List<Shoe>Shoes { get { return shoes; } set { shoes = value; } }
        public int Count { get { return shoes.Count; } }
        public string AddShoe(Shoe shoe)
        {
            bool space = shoes.Count == StorageCapacity;
            if (!space)
            {
                shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            else
            {
                return "No more space in the storage room.";
            }

        }
        public int RemoveShoes(string material) {
            int count = 0;
            for (int i = 0; i < shoes.Count; i++)
            {
                if (shoes[i].Material == material)
                {
                    shoes.Remove(shoes[i]);
                    i--;
                    count++;
                }
            }
            return count;
        }
        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> result = new();
            foreach (var item in shoes)
            {
                if (item.Type==type.ToLower())
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public Shoe GetShoeBySize(double size)
        {
           Shoe result= new Shoe("s","s",2,"s");
            foreach (var item in shoes)
            {
                if (item.Size==size)
                {
                    result = item;
                        break;
                }
            }
            return result;
        }
        public string StockList(double size, string type)
        {
            List<Shoe> result = new();
            StringBuilder sb = new(); 
            foreach (var item in shoes)
            {
                if (item.Size==size&&item.Type==type)
                {
                    result.Add(item);
                }
            }
            if (result.Any())
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var item in result)
                {
                    sb.AppendLine(item.ToString());
                }
                return sb.ToString().TrimEnd();

            }
            else
            {
                return "No matches found!";
            }

        }
    }
}
