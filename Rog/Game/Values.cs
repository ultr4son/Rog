using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog
{
    public enum Command
    {
        MOVE_UP,
        MOVE_DOWN,
        MOVE_LEFT,
        MOVE_RIGHT,
        MOVE_UPRIGHT,
        MOVE_UPLEFT,
        MOVE_DOWNRIGHT,
        MOVE_DOWNLEFT,
        NONE       
    }

    public enum CharacterType
    {
        PLAYER,
        BAT,
        WALL,
        DUMMY
    }

    public enum Team
    {
        MONSTER,
        NEUTRAL,
        PLAYER_FRIENDLY
    }

   
}
