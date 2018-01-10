using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.View
{
    abstract class Command
    {
        protected string option;
        protected string description;

        public Command(string op, string descr)
        {
            option = op;
            description = descr;
        }

        public abstract void Execute();     // commands will implement this

        public string Option
        {
            get { return option; }
        }

        public string Description { get { return description; } }

        public override string ToString()
        {
            return string.Format("{0:2} : {1:6} : {2}", option, description);
        }
    }
}
