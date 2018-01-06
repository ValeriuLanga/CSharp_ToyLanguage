using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;
using CSharp_ToyLanguage.Exceptions;

namespace CSharp_ToyLanguage.Expressions
{
    class ArithmeticExpression : Expression
    {
        private char oper;
        private Expression leftExpression;
        private Expression rightExpression;
        
        public ArithmeticExpression(char oper, Expression leftExpr, Expression rightExpr)
        {
            this.oper = oper;
            this.leftExpression = leftExpr;
            this.rightExpression = rightExpr;
        }
        public int Evaluate(SymbolTableInterface<string, int> symbolTable)
        {
            int leftResult = leftExpression.Evaluate(symbolTable);
            int rightResult = rightExpression.Evaluate(symbolTable);

            switch(oper)
            {
                case '+': return leftResult + rightResult;
                case '-': return leftResult - rightResult;
                case '*': return leftResult * rightResult;
                case '/':
                    if (rightResult != 0)
                        return leftResult / rightResult;
                    else
                        throw new DivisionByZeroException();
                default:
                    throw new UnknownOperationException(oper);
            }
        }

        public override string ToString()
        {
            return leftExpression.ToString() + oper +  rightExpression.ToString();
        }
    }
}
