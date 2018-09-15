using Rog.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public enum StartScreenState
    {
        INPUT_NAME
    }
    public class PromptValue
    {
        public string Prompt;
        public Func<ProgramState, string> Getter;
        public Func<ProgramState, string, ProgramState> Setter;
    }
    public class StartScreenModel
    {

    }
}
