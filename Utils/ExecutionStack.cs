using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Utils
{
    class ExecutionStack<T> : ExecutionStackInterface<T>
    {
        private Stack<T> stack;
        public ExecutionStack()
        {
            stack = new Stack<T>();
        }

        public IEnumerable<T> Content
        {
            get { return stack; }
        }

        public bool isEmpty()
        {
            return stack.Count == 0;
        }

        public T pop()
        {
            return stack.Pop();
        }

        public void push(T value)
        {
            stack.Push(value);
        }

        public T top()
        {
            return stack.Peek();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("\tExecution Stack: \n");
            foreach (T t in stack)
                stringBuilder.Append("\t\t" + t + "\n");

            return stringBuilder.ToString();
        }
    }
}
