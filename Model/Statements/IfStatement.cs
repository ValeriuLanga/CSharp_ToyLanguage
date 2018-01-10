using CSharp_ToyLanguage.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;
using CSharp_ToyLanguage.Statements;

namespace CSharp_ToyLanguage.Model.Statements
{
    class IfStatement : Statement
    {
        private Expression condition;
        private Statement thenStatement;
        private Statement elseStatement;

        public  IfStatement(Expression cond, Statement thenSt, Statement elseSt)
        {
            condition = cond;
            thenStatement = thenSt;
            elseStatement = elseSt;
        }

        public ProgramState Execute(ProgramState programState)
        {
            int resultValue = condition.Evaluate(programState.SymbolTable);
            // see if the condition is true, i.e. resultValue != 0
            if (0 != resultValue)
                programState.ExecutionStack.push(thenStatement);
            else
                programState.ExecutionStack.push(elseStatement);

            return programState;
        }
        public override string ToString()
        {
            return "if(" + condition + ") then{ " + thenStatement + " } else{ " + elseStatement + " }";
        }
    }
}
