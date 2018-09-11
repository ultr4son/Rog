using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    interface IInput
    {
        event EventHandler<Command> OnInput;
        void Start();
        void Stop();
    }
}
