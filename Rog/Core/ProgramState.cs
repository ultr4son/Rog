using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public delegate T StateMutation<T>(T state);
   
    public class ProgramState
    {
        public ProgramState(IUserInterface ui, GameState game)
        {
            this.ui = ui;
            this.game = game;
        } 
        public IUserInterface ui { get; private set; }
        public GameState game { get; private set; } 
    }
}
