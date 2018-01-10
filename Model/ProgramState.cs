using CSharp_ToyLanguage.Model.FileTable;
using CSharp_ToyLanguage.Model.OutputList;
using CSharp_ToyLanguage.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Utils
{
    class ProgramState
    {
        private ExecutionStackInterface<Statement> executionStack;
        private SymbolTableInterface<string, int> symbolTable;
        private FileTableInterface<int, FileDescriptor> fileTable;
        private OutputListInterface<int> outputList;
        private Statement statement;                   // as opposed to the java version, i have added an initial state here
                                                       // so there is no need for a manual push of the statement to the stack

        public ProgramState(
            ExecutionStackInterface<Statement> execStack,
            SymbolTableInterface<string, int> symTable,
            OutputListInterface<int> outList,
            FileTableInterface<int, FileDescriptor> fTable,
            Statement initialStatement
            )
        {
            executionStack = execStack;
            symbolTable = symTable;
            outputList = outList;
            fileTable = fTable;
            statement = initialStatement;
            execStack.push(initialStatement);   // push the initial statement onto the stack
        }

        public ExecutionStackInterface<Statement> ExecutionStack
        {
            get { return executionStack; }
            set { executionStack = value; }
        }

        public SymbolTableInterface<string, int> SymbolTable
        {
            get { return symbolTable; }
            set { symbolTable = value; }
        }

        public FileTableInterface<int, FileDescriptor> FileTable
        {
            get { return fileTable; }
            set { fileTable = value; }
        }

        public OutputListInterface<int> OutputList
        {
            get { return outputList; }
            set { outputList = value; }
        }

        public Statement Program
        {
            get { return statement; }
            set { statement = value; }
        }

        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.Append("Program State\n\n");
            buff.Append(SymbolTable.ToString());
            buff.Append(ExecutionStack.ToString());
            buff.Append(OutputList.ToString());
            buff.Append(FileTable.ToString());
            buff.Append("\n");
            return buff.ToString();
        }

    }
}
