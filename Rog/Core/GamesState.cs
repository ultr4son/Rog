using Rog.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public class GameState
    {
        public GameState()
        {
            Player = null;
            Floor = new Floor((0, 0));
            Turns = new List<CommandStateMutation>();
        }
        public Character Player
        {
            get; set;
        }

        public Floor Floor
        {
            get; set;
        }

        public IEnumerable<CommandStateMutation> Turns { get; set; }

    }    
}
