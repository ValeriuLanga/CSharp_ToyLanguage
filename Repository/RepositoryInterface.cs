using CSharp_ToyLanguage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.Repository
{
    interface RepositoryInterface
    {
        void Add(ProgramState programState);

        void LogProgramState();

        ProgramState Current { get; }

        string FileName { get; set; }

        IEnumerable<ProgramState> Content { get; }
    }
}
