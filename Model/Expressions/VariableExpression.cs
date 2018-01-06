using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;

namespace CSharp_ToyLanguage.Expressions
{
    class VariableExpression : Expression
    {
        private string variableName;

        public VariableExpression(string varName)
        {
            variableName = varName;
        }

        public int Evaluate(SymbolTableInterface<string, int> symbolTable)
        {
            return symbolTable[variableName];
        }

        public override string ToString()
        {
            return variableName;
        }
    }
}
