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
            IOutput ui = new ConsoleUI();
            IInput input = new ConsoleInputEngine();
            IMutator<Command, ProgramState> game = new StateMachine<Command, ProgramState>(States.Init(state));

            
            input.OnInput += (object _, Command command) =>
            {
                game.Notify(command);
            };

            game.OnState += (object _, ProgramState newState) =>
            {
                ui.Notify(newState);
            };

            input.Start();

        }
    }
}

