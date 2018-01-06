using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Model.FileTable
{
    interface FileTableInterface<K,V>
    {
        void add(K key, V value);

        void remove(K key);

        bool contains(V value);

        V this[K key] { get; set; }

        int Size { get; }

        IEnumerable<KeyValuePair<K, V>> Content { get; }
    }
}
