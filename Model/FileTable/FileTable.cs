using CSharp_ToyLanguage.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Model.FileTable
{
    class FileTable<K, V> : FileTableInterface<K, V>
    {
        private Dictionary<K, V> map;

        public FileTable()
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

        public bool contains(V value)
        {
            return map.ContainsValue(value);
        }

        public void add(K key, V value)
        {
            if (map.ContainsKey(key))
                throw new GenericException("File !" + key + " already exists!");
            map.Add(key, value);
        }

        public void remove(K key)
        {
            if (!map.ContainsKey(key))
                throw new GenericException("Invalid Key!");
            map.Remove(key);
        }

        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.Append("\tFile Table\n\t\n");
            foreach (K key in map.Keys)
            {
                buff.Append("\t\t" + key + " -> " + map[key] + "\n");
            }
            buff.Append("\t\n");
            return buff.ToString();
        }
    }
}
