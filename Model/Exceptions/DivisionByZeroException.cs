using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Exceptions
{
    class DivisionByZeroException : ApplicationException
    {
        public DivisionByZeroException() : base("[Exception] Division by zero!") {  }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
