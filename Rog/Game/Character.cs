using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog
{
    public delegate CommandStateMutation CharacterCommandMutation(Character actor);
    public delegate StateMutation<ProgramState> CommandStateMutation(Command command);
    public class Character
    {
        public string name;
        public int hp;
        public Tuple<int, int> position;
        public CharacterType characterType;
        public Team team;
    }

    
    

}
