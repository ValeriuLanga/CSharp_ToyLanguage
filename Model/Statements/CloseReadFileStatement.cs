using CSharp_ToyLanguage.Exceptions;
using CSharp_ToyLanguage.Statements;
using CSharp_ToyLanguage.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Model.Statements
{
    class CloseReadFileStatement : Statement
    {
        string fileId;

        public CloseReadFileStatement(string fId)
        {
            fileId = fId;
        }

        public ProgramState Execute(ProgramState state)
        {
            try
            {
                int descr = state.SymbolTable[fileId];
                StreamReader sr = state.FileTable[descr].Reader;
                sr.Close();
                state.FileTable.remove(descr);
            }
            catch (Exception ex)
            {
                throw new GenericException("Close error!", ex);
            }
            return state;
        }

        public override string ToString()
        {
            return "close( " + fileId + " );";
        }
    }
}
