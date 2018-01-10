using CSharp_ToyLanguage.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;

namespace CSharp_ToyLanguage.Model.Statements
{
    class CompoundStatement : Statement
    {
        private Statement firstStatement;
        private Statement secondStatement;

        public CompoundStatement(Statement first, Statement second)
        {
            firstStatement = first;
            secondStatement = second;
        }

        public ProgramState Execute(ProgramState programState)
        {
            programState.ExecutionStack.push(firstStatement);
            programState.ExecutionStack.push(secondStatement);
             
            return programState;
        }
    }
}
