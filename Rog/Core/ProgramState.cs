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
        public ProgramState(ILogger logger, GameState game)
        {
            this.logger = logger;
            this.game = game;
        } 
        public ILogger logger { get; private set; }
        public GameState game { get; private set; } 
    }
}
