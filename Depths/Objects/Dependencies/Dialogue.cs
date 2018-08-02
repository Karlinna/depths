using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    public class Dialogue<K, V>
    {
        protected List<K> ListOfKey = new List<K>();
        protected List<V> ListOfValues = new List<V>();

        public void Add(K key, V value)
        {
            ListOfKey.Add(key);
            ListOfValues.Add(value);
        }
        public K GetKey(int i)
        {    
           
           return ListOfKey[i];
          
        }
        public V GetValue(int i)
        {
            return ListOfValues[i];
        }
        public void SetValue(int i, V value)
        {
            ListOfValues[i] = value;
        }
        public int Count => ListOfKey.Count;
       }
}
