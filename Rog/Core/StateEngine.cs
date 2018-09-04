using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public class StateMachine<TSignal>
    {
        public StateMachine(StateEngineState<TSignal, StateMutation<ProgramState>> initialState)
        {
            state = initialState;
        }
        private StateEngineState<TSignal, StateMutation<ProgramState>> state;

        public IEnumerable<StateMutation<ProgramState>> apply(TSignal command, ProgramState gameState)
        {
            var result = state(command, gameState);
            state = result.Item1;
            return result.Item2;
        }
    }
}
