﻿using CSharp_ToyLanguage.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_ToyLanguage.Utils;
using CSharp_ToyLanguage.Expressions;

namespace CSharp_ToyLanguage.Model.Statements
{
    class AssignStatement : Statement
    {
        private string variableName;
        private Expression expression;

        public AssignStatement(string varName, Expression expr)
        {
            variableName = varName;
            expression = expr;
        }

        public ProgramState Execute(ProgramState programState)
        {
            int resultValue = expression.Evaluate(programState.SymbolTable);
            programState.SymbolTable[variableName] = resultValue;

            return programState;
        }
        public override string ToString()
        {
            return variableName + " := " + expression + ";";
        }
    }
}
