using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Model.OutputList
{
    class OutputList<T> : OutputListInterface<T>
    {
        private Stack<T> output;

        public OutputList()
        {
            output = new Stack<T>();
        }

        public void add(T elem)
        {
            output.Push(elem);
        }

        public IEnumerable<T> Content
        {
            get { return output; }
        }

        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.Append("\tOutputList\n\t\n");
            foreach (T t in output)
            {
                buff.Append("\t\t" + t + "\n");
            }
            buff.Append("\t\n");
            return buff.ToString();
        }
    }
}
