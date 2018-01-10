using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.View
{
    class ExitCommand : Command
    {
        public ExitCommand() : base("0", "Exits the program!")
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);    // exit with a success code, i.e. 0
        }
    }
}
