using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public delegate CommandStateMutation CharacterCommandMutation(Character actor);
    public delegate StateMutation<ProgramState> CommandStateMutation(Command command);
    public class Character
    {
        public Item Primary;
        public List<Item> Inventory = new List<Item>();

        public string Name;
        public int Hp;

        public (int x, int y) Position;

        public CharacterType CharacterType;
        public Team Team;
    }

    
    

}
