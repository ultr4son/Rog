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
            StateEngineState<Command, StateMutation<ProgramState>> initialState = States.Init;
            ProgramState state = new ProgramState(ui, new GameState());
            IGameEngine gameEngine = new ConsoleGameEngine(
                new RogGame(
                    new StateMachine<Command>(initialState)
                ),
                state
            );
            gameEngine.start();

        }
    }
}

