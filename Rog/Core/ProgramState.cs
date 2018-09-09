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
        public ProgramState(GameState game)
        {
            this.game = game;
            log = new List<string>();
        } 
        
        public List<string> log { get; private set; }
        public GameState game { get; private set; } 
    }
}
