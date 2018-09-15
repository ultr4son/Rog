using Rog.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{

    public delegate (StateMachineState<TSignal,TOut> next, TOut output) StateMachineState<TSignal, TOut>(TSignal command);
    //public delegate StateMachineState<TSignal, TOut> BoundStateMachineState<TSignal, TOut, TBind>(TBind bind);
    public static class States
    {
        private static (StateMachineState<TSignal, TOut> next, TOut output) Now<TSignal, TOut>(StateMachineState<TSignal, TOut> stateMachineState, TSignal signal)
        {
            return stateMachineState(signal);
        }
        public static StateMachineState<CommandValue, ProgramState> Init(ProgramState state, (int width, int height) size) => (command) =>
        {
            state.Game.Floor = MapGenerator.basicFloor(size);
            state.Game.Player = Make.Player(0, "", (5, 5)); 
            Character dummy = Make.Dummy(10, (4,4));
            Character bat = Make.Bat(10, (2,4));

            state.Game.Turns = new List<CommandStateMutation>()
            {
                Turn.player(state.Game.Player),
                Turn.Bat(bat)
            };
            state.Game.Floor.Characters.Add(state.Game.Player);
            state.Game.Floor.Characters.Add(dummy);
            state.Game.Floor.Characters.Add(bat);

            state.StartScreen.Push(new PromptValue()
            {
                Prompt = "What is your name?",
                Getter = (s) => s.Game.Player.Name,
                Setter = (s, i) => 
                {
                    s.Game.Player.Name = i;
                    return s;
                }
            });

            return Now(StartScreen(state), command);
        };

        public static StateMachineState<CommandValue, ProgramState> Read(Func<ProgramState, string, ProgramState> assign, Func<StateMachineState<CommandValue, ProgramState>> done, string acc, ProgramState state) => (command) =>
        {
            if (command.Command == Command.ENTER)
            {
                return (done(), state);
            }
            else if (command.Command == Command.BACKSPACE)
            {
                acc = acc.Substring(0, acc.Count() - 1);
            }
            acc += command.Raw;
            return (Read(assign, done, acc, state), assign(state, acc));

        };
        
        public static StateMachineState<CommandValue, ProgramState> StartScreen(ProgramState state) => (command) =>
        {
            
            state.UIState = UIState.START_SCREEN;            
            PromptValue promptValue = state.StartScreen.Peek();
            return (Read(promptValue.Setter, () =>
            {
                state.StartScreen.Pop();
                if(state.StartScreen.Count() > 0)
                {
                    return StartScreen(state);
                }
                return Now(Map(state), command).next;
            }, "", state), state);
            
        };
        //TODO: Put in state transitions when doing inventory, etc.
        public static StateMachineState<CommandValue, ProgramState> Map(ProgramState state) => (command) =>
        {
            state.UIState = UIState.MAP;
            return (Map(state), state.Game.Turns.Select(f => f(command.Command)).Aggregate(state, (s, f) => f(s)));
        };
    }
}
