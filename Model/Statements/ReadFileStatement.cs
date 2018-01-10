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
    class ReadFileStatement : Statement 
    {
        private string fileId;
        private string variableName;

        public ReadFileStatement(string _fileId, string _varName)
        {
            fileId = _fileId;
            variableName = _varName;
        }

        public ProgramState Execute(ProgramState programState)
        {
            try
            {
                int fdId = programState.SymbolTable[fileId];
                StreamReader sr = programState.FileTable[fdId].Reader;

                string str = sr.ReadLine();
                int var = (str == null) ? 0 : int.Parse(str);
                programState.SymbolTable[variableName] = var;
            }
            catch (Exception ex)
            {
                throw new GenericException("Read failed!", ex);
            }
            return programState;
        }

        public override string ToString()
        {
            return "read(" + fileId + "," + variableName + ");";
        }
    }
}
