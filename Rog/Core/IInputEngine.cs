using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    interface IInputEngine
    {
        event EventHandler<Command> OnInput;
        void start();
        void stop();
    }
}
