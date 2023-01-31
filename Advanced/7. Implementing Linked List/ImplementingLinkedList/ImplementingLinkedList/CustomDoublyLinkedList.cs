using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomDoublyLinkedLists
{
    public class CustomDoublyLinkedList
    {
        public Node Head { get; set; }
        public Node Tale { get; set; }
        public int Count { get; set; }
        public void AddFirst(int value)
        {
            Count++;
            Node node = new(value);
            if (Head==null)
            {
                Head = node;
                Tale = node;
                return;
            }
            node.Next = Head;
            Head.Previous = node;
            Head= node;
        }
        public void AddLast(int value)
        {
            Node node = new(value);
            if (Head == null)
            { //0 1 2
                Head = node;
                Tale = node;
                return;
            }
            node.Previous = Tale;
            Tale.Next = node;
           Tale = node;
        }
        public int RemoveFirst()
        {
            Count--;
            int temp = Head.Value;           
            Head= Head.Next;
            return temp;
        }
        public int RemoveLast()
        {
            Count--;
            int temp = Tale.Value;
            Tale = Tale.Previous;
            return temp;
        }


    }
}
