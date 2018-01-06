using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Model.OutputList
{
    interface OutputListInterface<T>
    {
        void add(T elem);

        IEnumerable<T> Content { get; }
    }
}
