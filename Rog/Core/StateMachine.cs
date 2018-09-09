using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{

    public class StateMachine<TSignal, TOut> : IMutator<TSignal, TOut>
    {
        public StateMachine(StateMachineState<TSignal, TOut> initialState)
        {
            state = initialState;
        }
        private StateMachineState<TSignal, TOut> state;

        public event EventHandler<TOut> OnState;

        public void notify(TSignal input)
        {
            var result = state(input);
            state = result.next;
            OnState(this, result.output);
        }
    }
}
