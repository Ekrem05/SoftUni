using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductTrackingSystem
{
    public class Stock : IEnumerable<IProduct>
    {
        private List<IProduct> stock;
        public Stock(IEnumerable<IProduct> stock)
        {
            this.stock = stock.ToList();
        }
        public int Count => stock.Count();
        IProduct this[int index] { get { return stock[index]; } set { stock[index] = value; } }
        public void Add(IProduct product)
        {
            stock.Add(product);
        }
        public bool Contains(IProduct product)
        {
            return stock.Contains(product);
        }
        public IProduct Find(int n)
        {
            if (stock.ElementAt(n)!=null)
            {
                return stock.ElementAt(n);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public IProduct FindByLable(string name)
        {
            IProduct product =stock.Where(x => x.Name == name).First();
            if (stock.Contains(product))
            {
                return product;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public ICollection<IProduct> FindAllInRange(decimal from,decimal to)
        {
            return stock.Where(x=>x.Price>=from&&x.Price<=to).OrderByDescending(x => x.Price).ToList();
        }
        public ICollection<IProduct> FindAllByPrice(int quantity)
        {
            return stock.Where(x => x.Quanity==quantity).ToList();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < stock.Count; i++)
            {
                yield return stock[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
