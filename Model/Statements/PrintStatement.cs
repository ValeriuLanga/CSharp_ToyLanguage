using CSharp_ToyLanguage.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;
using CSharp_ToyLanguage.Expressions;

namespace CSharp_ToyLanguage.Model.Statements
{
    class PrintStatement : Statement
    {
        private Expression expression;

        public PrintStatement(Expression expression)
        {
            this.expression = expression;
        }

        public ProgramState Execute(ProgramState programState)
        {
            int resultValue = expression.Evaluate(programState.SymbolTable);
            programState.OutputList.add(resultValue);

            return programState;
        }

        public override string ToString()
        {
            return "print( " + expression + " );";
        }
    }
}
