using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Utils
{
    static class IdGenerator
    {
        static int id = 2;
        public static int Id
        {
            get { return ++id; }
        }

    }
}
