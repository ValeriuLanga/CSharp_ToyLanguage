using CSharp_ToyLanguage.Repository;
using CSharp_ToyLanguage.Statements;
using CSharp_ToyLanguage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.controller
{

    class Controller
    {
        private RepositoryInterface repository;
        
        public Controller(RepositoryInterface repo)
        {
            repository = repo;
        }

        public void ExecuteOnce()
        {
            if (!repository.Current.ExecutionStack.isEmpty())
            {
                Statement stm = repository.Current.ExecutionStack.pop();
                stm.Execute(repository.Current);
                repository.LogProgramState();
                Console.WriteLine(repository.Current);
            }
        }

        public void ExecuteAll()
        {
            Console.WriteLine(repository.Current);
            while (!repository.Current.ExecutionStack.isEmpty())
            {
                ExecuteOnce();
            }
        }

        public void AddProgram(ProgramState state)
        {
            repository.Add(state);
        }

        public IEnumerable<ProgramState> Programs
        {
            get { return repository.Content; }
        }

        public string Executing
        {
            get { return repository.Current.Program.ToString(); }
        }

        public string FileName
        {
            get { return repository.FileName; }
            set { repository.FileName = value; }
        }
    }
}

