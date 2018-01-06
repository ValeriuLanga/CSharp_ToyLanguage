using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Exceptions
{
    class UnknownOperationException : ApplicationException
    {
        public UnknownOperationException(char oper) : base("[Exception] The specified operator is invalid! (" + oper + ")") { }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
