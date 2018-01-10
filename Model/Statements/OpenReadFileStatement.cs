using CSharp_ToyLanguage.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;
using CSharp_ToyLanguage.Exceptions;
using System.IO;
using CSharp_ToyLanguage.Model.FileTable;

namespace CSharp_ToyLanguage.Model.Statements
{
    class OpenReadFileStatement : Statement
    {
        private string fileName;
        private string fileId;

        public OpenReadFileStatement(string fName, string fId)
        {
            fileName = fName;
            fileId = fId;
        }

        public ProgramState Execute(ProgramState programState)
        {
            // see if we have an already opened file
            if (programState.FileTable.contains(new FileTable.FileDescriptor(fileName, null)))
                throw new GenericException("File already opened!");

            try
            {
                StreamReader streamReader = new StreamReader(File.Open("..\\..\\" + fileName, FileMode.Open));
                FileDescriptor fd = new FileDescriptor(fileName, streamReader);

                int id = IdGenerator.Id;
                
                // assign the file descriptor to it's own id in the file table
                programState.FileTable[id] = fd;

                // assign the above id to the given fileId
                programState.SymbolTable[fileId] = id; 
           
            }
            catch(IOException exception)
            {
                throw new GenericException("Cannot open file name= " + fileName + "!\n" + exception);
            }

            return programState;
        }

        public override string ToString()
        {
            return "open( " + fileId + "," + fileName + " );";
        }
    }
}
