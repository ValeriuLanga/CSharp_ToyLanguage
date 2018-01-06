using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Utils
{
    interface ExecutionStackInterface<T>
    {
        void push(T value);
        T pop();
        T top();
        bool isEmpty();
        IEnumerable<T> Content{ get; }
    }
}
