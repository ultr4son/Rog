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
            IUserInterface ui = new ConsoleUI();
            ILogger logger = new InMemoryLogger();

            StateEngineState<Command, StateMutation<ProgramState>> initialState = States.Init;
            ProgramState state = new ProgramState(logger, new GameState());

            RogGame game = new RogGame(initialState);

            StateHandler handler = new StateHandler(game, ui, state);

            IInputEngine input = new ConsoleInputEngine();

            input.OnInput += (object _, Command command) =>
            {
                handler.notify(command);
            };

            input.start();

        }
    }
}

