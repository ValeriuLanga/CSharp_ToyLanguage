using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;

namespace CSharp_ToyLanguage.Expressions
{
    class ConstantExpression : Expression
    {
        private int value;

        public ConstantExpression(int value)
        {
            this.value = value;
        }

        public int Evaluate(SymbolTableInterface<string, int> symbolTable)
        {
            return value;
        }

        public override string ToString()
        {
            return "" + value;
        }
    }
}
