using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Utils
{
    interface SymbolTableInterface<K,V>
    {
        V this[K key] { get;  set; }

        bool Contains(K key);
     
        int Size { get; }

        IEnumerable<KeyValuePair<K,V>> Content { get; }
    }
}
