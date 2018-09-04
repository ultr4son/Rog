using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public class RogGame
    {
        public RogGame(StateMachine<Command> gameMachine)
        {
            this.gameMachine = gameMachine;
        }
        StateMachine<Command> gameMachine;
        
        public ProgramState sendCommand(Command command, ProgramState state)
        {
            IEnumerable<StateMutation<ProgramState>> response = gameMachine.apply(command, state);
            return response.Aggregate(state, (s, f) => f(s));
        }
    }
}
