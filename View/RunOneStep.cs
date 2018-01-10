using CSharp_ToyLanguage.controller;
using CSharp_ToyLanguage.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.View
{
    class RunOneStep : Command
    {
        Controller controller;

        public RunOneStep(Controller ctrl, string op, string descr) : base(op, descr)
        {
            controller = ctrl;
        }

        public override void Execute()
        {
            try
            {
                controller.ExecuteOnce();
            }
            catch(GenericException genExc)
            {
                Console.WriteLine(genExc);
            }
            catch(DivisionByZeroException divZeroExc)
            {
                Console.WriteLine(divZeroExc);
            }
            catch(UnknownOperationException unkOpExc)
            {
                Console.WriteLine(unkOpExc);
            }
        }
    }
}
