using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rog.Game;

namespace Rog.Core
{

    public interface IOutput
    {
        void Notify(ProgramState state);
    }
}
