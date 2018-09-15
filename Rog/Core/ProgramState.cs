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
            Game = game;
            Log = new List<string>();
            UIState = UIState.NONE;
            StartScreen = new Stack<PromptValue>();
        }
        public Stack<PromptValue> StartScreen;
        public UIState UIState { get; set; }
        public List<string> Log { get; private set; }
        public GameState Game { get; private set; } 
    }
}
