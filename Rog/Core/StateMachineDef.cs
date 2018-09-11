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

            state.game.Floor = MapGenerator.basicFloor((10,10));
            state.game.Player = Make.Character(10, "Bep", CharacterType.PLAYER, Team.PLAYER_FRIENDLY,(5,5));

            Character dummy = Make.Dummy(10, (4,4));
            Character bat = Make.Bat(10, (2,4));

            state.game.Turns = new List<CommandStateMutation>()
            {
                Turn.player(state.game.Player),
                Turn.Bat(bat)
            };
            state.game.Floor.Characters.Add(state.game.Player);
            state.game.Floor.Characters.Add(dummy);
            state.game.Floor.Characters.Add(bat);
            return (Playing(state), state);
        };

        //TODO: Put in state transitions when doing inventory, etc.
        public static BoundStateMachineState<Command, ProgramState, ProgramState> Playing = (state) => (command) =>
        {
            return (Playing(state), state.game.Turns.Select(f => f(command)).Aggregate(state, (s, f) => f(s)));
        };
    }
}
