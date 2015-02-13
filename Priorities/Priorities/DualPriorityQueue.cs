using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priorities
{
    public class DualPriorityQueue<TypeA,TypeB>
    {
        public int Count 
        { 
            get
            {
                return ListA.Count;
            }
        
        }

        public SortedList<TypeA, string> ListA { get; private set; }

        public SortedList<TypeB, string> ListB { get; private set; }

        public DualPriorityQueue()
        {
            ListA = new SortedList<TypeA, string>();
            ListB = new SortedList<TypeB, string>();
        }

        public void Enqueue(string itemName, TypeA valueA, TypeB valueB)
        {
            ListA.Add(valueA, itemName);
            ListB.Add(valueB, itemName);
        }

        public string DequeueA()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            string first = ListA.Values[0];
            ListA.RemoveAt(0);
            foreach(var keyVal in ListB)
            {
                if(keyVal.Value == first)
                {
                    ListB.Remove(keyVal.Key);
                    break;
                }
            }
            return first;
        }

        public string DequeueB()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            string first = ListB.Values[0];
            ListB.RemoveAt(0);
            foreach (var keyVal in ListA)
            {
                if (keyVal.Value == first)
                {
                    ListA.Remove(keyVal.Key);
                    break;
                }
            }
            return first;
        }

        public void Clear()
        {
            ListA.Clear();
            ListB.Clear();
        }
        public override string ToString()
        {
            string output = "";
            foreach (var keyValA in ListA)
                foreach (var keyValB in ListB)
                    if (keyValA.Value == keyValB.Value)
                        output += "Item: " + keyValB.Value + " " + keyValA.Key + " " + keyValB.Key + "\n";

            return output;
        }
    }
}
