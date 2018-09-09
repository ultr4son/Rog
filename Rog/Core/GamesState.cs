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
            player = null;
            floor = new Floor((0, 0));
            turns = new List<CommandStateMutation>();
        }
        public Character player
        {
            get; set;
        }

        public Floor floor
        {
            get; set;
        }

        public IEnumerable<CommandStateMutation> turns { get; set; }

    }    
}
