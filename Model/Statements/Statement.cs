using CSharp_ToyLanguage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Statements
{
    interface Statement
    {
        ProgramState Execute(ProgramState programState);
    }
}
