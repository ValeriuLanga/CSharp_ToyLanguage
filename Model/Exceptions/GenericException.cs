using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Exceptions
{
    class GenericException : ApplicationException
    {
        public GenericException() : base("") { }
        public GenericException(string message) : base(message) { }
        public GenericException(string message, Exception exception) : 
            base(message + " " + exception.Message) { }

    }
}
