using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;
using System.IO;
using CSharp_ToyLanguage.Exceptions;
using CSharp_ToyLanguage.Statements;
using CSharp_ToyLanguage.Model.OutputList;
using CSharp_ToyLanguage.Model.FileTable;

namespace CSharp_ToyLanguage.Repo
{
    class Repository : RepositoryInterface
    {
        private List<ProgramState> container;
        private string fileName;

        public Repository(string fName)
        {
            container = new List<ProgramState>();
            fileName = fName;

            // create a file with the given file name
            StreamWriter logStreamWriter = new StreamWriter(File.Open(fileName, FileMode.Create));
            logStreamWriter.Close();
        }

        public IEnumerable<ProgramState> Content
        {
            get
            {
                return container;
            }
        }

        public ProgramState Current
        {
            get
            {
                if (0 == container.Count)
                    throw new GenericException("Empty repository!");
                return container[0];
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public void Add(ProgramState programState)
        {
            container.Insert(0, programState);
        }

        public void LogProgramState()
        {
            using (StreamWriter logFile = new StreamWriter(File.Open(fileName, FileMode.Append)))
            {
                ProgramState programState = Current;
                ExecutionStackInterface<Statement> executionStack = programState.ExecutionStack;
                SymbolTableInterface<string, int> symbolTable = programState.SymbolTable;
                OutputListInterface<int> cout = programState.OutputList;
                FileTableInterface<int, FileDescriptor> fileTable = programState.FileTable;

                logFile.WriteLine("ExecStack:");
                foreach (Statement stm in executionStack.Content)
                    logFile.WriteLine(stm);

                logFile.WriteLine("SymTable:");
                foreach (KeyValuePair<string, int> entry in symbolTable.Content)
                    logFile.WriteLine(entry.Key + " -> " + entry.Value);

                logFile.WriteLine("Output:");
                foreach (int k in cout.Content)
                    logFile.WriteLine(k);

                logFile.WriteLine("FileTable:");
                foreach (KeyValuePair<int, FileDescriptor> entry in fileTable.Content)
                    logFile.WriteLine(entry.Key + " -> " + entry.Value);

                logFile.WriteLine();
            }
        }
    }
}
