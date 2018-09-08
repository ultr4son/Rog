using Rog.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{

    public delegate Tuple<StateEngineState<TSignal, TMut>, IEnumerable<TMut>> StateEngineState<TSignal, TMut>(TSignal command, ProgramState state);
    
    public static class States
    {
        public static StateEngineState<Command, StateMutation<ProgramState>> Init = (Command command, ProgramState state) =>
        {
            state.game.floor = MapGenerator.basicFloor(Tuple.Create(10, 10));
            state.game.player = Make.character(10, "Bep", CharacterType.PLAYER, Team.PLAYER_FRIENDLY,Tuple.Create(5, 5));

            Character dummy = Make.dummy(10, Tuple.Create(4,4));
            Character bat = Make.bat(10, Tuple.Create(2, 4));

            state.game.turns = new List<CommandStateMutation>()
            {
                Turn.player(state.game.player),
                Turn.bat(bat)
            };
            state.game.floor.characters.Add(state.game.player);
            state.game.floor.characters.Add(dummy);
            state.game.floor.characters.Add(bat);
            return Tuple.Create(Playing, new List<StateMutation<ProgramState>>().AsEnumerable());
        };

        //TODO: Put in state transitions when doing inventory, etc.
        public static StateEngineState<Command, StateMutation<ProgramState>> Playing = (Command command, ProgramState state) =>
        {
            return Tuple.Create(Playing, state.game.turns.Select(f => f(command)));
        };
    }
}
