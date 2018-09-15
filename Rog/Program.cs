using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ProgramState state = new ProgramState(new GameState());
            IUI ui = new ConsoleUI();
            IInput input = new ConsoleInput();
            IMutator<CommandValue, ProgramState> game = new StateMachine<CommandValue, ProgramState>(States.Init(state, (10,10)));

            
            input.OnInput += (object _, CommandValue command) =>
            {
                game.Notify(command);
            };

            game.OnState += (object _, ProgramState newState) =>
            {
                ui.Notify(newState);
            };

            game.Notify(new CommandValue() { Command = Command.INIT, Raw = "" });
            input.Start();

        }
    }
}

