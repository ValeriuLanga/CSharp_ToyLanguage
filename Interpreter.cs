using CSharp_ToyLanguage.controller;
using CSharp_ToyLanguage.Expressions;
using CSharp_ToyLanguage.Model.FileTable;
using CSharp_ToyLanguage.Model.OutputList;
using CSharp_ToyLanguage.Model.Statements;
using CSharp_ToyLanguage.Model.SymbolTable;
using CSharp_ToyLanguage.Repo;
using CSharp_ToyLanguage.Statements;
using CSharp_ToyLanguage.Utils;
using CSharp_ToyLanguage.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage
{
    class Interpreter
    {
        static void Main(string[] args)
        {
            TextMenu textMenu = new TextMenu();
            textMenu.AddCommand(new ExitCommand());

            Statement st1 =new CompoundStatement(
                            new CompoundStatement(
                                    new AssignStatement("a", new ArithmeticExpression('/', new ConstantExpression(2), new ConstantExpression(0))),
                                    new AssignStatement("a", new ConstantExpression(5))),
                            new PrintStatement(new VariableExpression("a")));

            ProgramState state1 = new ProgramState(new ExecutionStack<Statement>(), new SymbolTable<string, int>(),
                    new OutputList<int>(), new FileTable<int, FileDescriptor>(), st1);

            RepositoryInterface repo1 = new Repository("..\\..\\LogFile1.log");
            repo1.Add(state1);

            Controller ctrl1 = new Controller(repo1);
            textMenu.AddCommand(new RunAllSteps(ctrl1, "1", st1.ToString()));

            Statement st2 = new CompoundStatement(
                            new AssignStatement("a", new ConstantExpression(2)),
                            new AssignStatement("a", new ConstantExpression(7)));
            ProgramState state2 = new ProgramState(new ExecutionStack<Statement>(), new SymbolTable<string, int>(),
                    new OutputList<int>(), new FileTable<int, FileDescriptor>(), st2);

            RepositoryInterface repo2 = new Repository("..\\..\\LogFile2.log");

            repo2.Add(state2);
            Controller ctrl2 = new Controller(repo2);
            textMenu.AddCommand(new RunAllSteps(ctrl2, "2", st2.ToString()));

            Statement st3 = new CompoundStatement(
                            new CompoundStatement(
                                    new CompoundStatement(
                                            new CompoundStatement(
                                                    new OpenReadFileStatement("example.ex", "f"),
                                                    new ReadFileStatement("f", "c")),
                                            new PrintStatement(new VariableExpression("c"))),
                                    new IfStatement(new VariableExpression("c"),
                                            new CompoundStatement(
                                                    new ReadFileStatement("f", "c"),
                                                    new PrintStatement(new VariableExpression("c"))),
                                            new PrintStatement(new ConstantExpression(0)))),
                            new CloseReadFileStatement("f"));

            ProgramState state3 = new ProgramState(new ExecutionStack<Statement>(), new SymbolTable<string, int>(),
                    new OutputList<int>(), new FileTable<int, FileDescriptor>(), st3);

            RepositoryInterface repo3 = new Repository("..\\..\\LogFile3.log");

            repo3.Add(state3);
            Controller ctrl3 = new Controller(repo3);
            textMenu.AddCommand(new RunAllSteps(ctrl3, "3", st3.ToString()));

            textMenu.show();
        }
    }
}
