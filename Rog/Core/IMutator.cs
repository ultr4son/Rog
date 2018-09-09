using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    interface IMutator<TIn,TOut>
    {
        event EventHandler<TOut> OnState;
        void notify(TIn input);
    }
}
