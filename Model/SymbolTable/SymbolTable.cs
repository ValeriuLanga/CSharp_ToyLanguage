using CSharp_ToyLanguage.Exceptions;
using CSharp_ToyLanguage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Model.SymbolTable
{
    class SymbolTable<K, V> : SymbolTableInterface<K, V>
    {
        private Dictionary<K, V> map;

        public SymbolTable()
        {
            map = new Dictionary<K, V>();
        }

        public V this[K key]
        {
            get
            {
                if (!map.ContainsKey(key))
                    throw new GenericException("Invalid Key!");
                return map[key];
            }

            set
            {
                map[key] = value;
            }
        }

        public IEnumerable<KeyValuePair<K, V>> Content
        {
            get
            {
                return map;
            }
        }

        public int Size
        {
            get
            {
                return map.Count;
            }
        }

        public bool Contains(K key)
        {
            return map.ContainsKey(key);
        }

        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.Append("\tSymbol Table\n\t\n");
            foreach (K key in map.Keys)
            {
                buff.Append("\t\t" + key + " -> " + map[key] + "\n");
            }
            buff.Append("\t\n");
            return buff.ToString();
        }

    }
}
