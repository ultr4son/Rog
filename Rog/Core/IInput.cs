using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public interface IInput
    {
        event EventHandler<Command> OnInput;
        string GetRaw();
        void Start();
        void Stop();
    }
}
