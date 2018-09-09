using Rog.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{

    public delegate (StateMachineState<TSignal,TOut> next, TOut output) StateMachineState<TSignal, TOut>(TSignal command);
    public delegate StateMachineState<TSignal, TOut> BoundStateMachineState<TSignal, TOut, TBind>(TBind bind);
    public static class States
    {
        public static BoundStateMachineState<Command, ProgramState, ProgramState> Init = (state) => (command) =>
        {

            state.game.floor = MapGenerator.basicFloor((10,10));
            state.game.player = Make.character(10, "Bep", CharacterType.PLAYER, Team.PLAYER_FRIENDLY,(5,5));

            Character dummy = Make.dummy(10, (4,4));
            Character bat = Make.bat(10, (2,4));

            state.game.turns = new List<CommandStateMutation>()
            {
                Turn.player(state.game.player),
                Turn.bat(bat)
            };
            state.game.floor.characters.Add(state.game.player);
            state.game.floor.characters.Add(dummy);
            state.game.floor.characters.Add(bat);
            return (Playing(state), state);
        };

        //TODO: Put in state transitions when doing inventory, etc.
        public static BoundStateMachineState<Command, ProgramState, ProgramState> Playing = (state) => (command) =>
        {
            return (Playing(state), state.game.turns.Select(f => f(command)).Aggregate(state, (s, f) => f(s)));
        };
    }
}
