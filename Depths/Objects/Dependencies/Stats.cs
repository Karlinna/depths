using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Dependencies
{
    public class Stats<K, V> where V : struct
    {
        protected List<K> ListOfKey = new List<K>();
        protected List<V> ListOfValues = new List<V>();

        public void Add(K key, V value)
        {
            ListOfKey.Add(key);
            ListOfValues.Add(value);
        }
        public V GetValueByKey(K key)
        {
            int a = ListOfKey.FindIndex(y => y.Equals(key));
            if (a != -1) return ListOfValues[a];
            else return default(V);
        }
    }
}
