using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    class StateHandler
    {
        public StateHandler(RogGame game, IUserInterface ui, ProgramState state)
        {
            this.game = game;
            this.ui = ui;
            this.state = state;
        }
        RogGame game;
        IUserInterface ui;
        ProgramState state;

        public void notify(Command command)
        {
            state = game.sendCommand(command, state);
            ui.notify(state);
        }
    }
}
