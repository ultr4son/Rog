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
        public static BoundStateMachineState<Command, ProgramState, ((int width, int height) size, ProgramState state, IInput input)> Init = (args) => (command) =>
        {
            ProgramState state = args.state;

            state.game.Floor = MapGenerator.basicFloor(args.size);
            state.UIState = UIState.START_SCREEN;

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
            return (StartScreen((state, args.input)), state);
        };
        public static BoundStateMachineState<Command, ProgramState, (ProgramState state, IInput input)> StartScreen = (args) => (command) =>
        {
            ProgramState state = args.state;
            state.UIState = UIState.START_SCREEN;
            if(state.StartScreenModel.State == StartScreenModelState.INPUT_NAME)
            {
                string name = args.input.GetRaw();
                state.game.Player = Make.Player(10, name, (5, 5));
                return (Map(state), state);
            } 
            return (StartScreen(args), state);

        };
        
        //TODO: Put in state transitions when doing inventory, etc.
        public static BoundStateMachineState<Command, ProgramState, ProgramState> Map = (state) => (command) =>
        {
            return (Map(state), state.game.Turns.Select(f => f(command)).Aggregate(state, (s, f) => f(s)));
        };
    }
}
