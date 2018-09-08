using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public static class Turn
    {
        public static StateMutation<ProgramState> pass = (state) => state;

        public static CharacterCommandMutation dummy = (character) => (intent) => pass;

        public static CharacterCommandMutation bat = (character) => (intent) =>
        {
            Command move = GameUtil.pickOne(Command.MOVE_DOWN, Command.MOVE_DOWNLEFT, Command.MOVE_DOWNRIGHT, Command.MOVE_LEFT, Command.MOVE_RIGHT, Command.MOVE_UP, Command.MOVE_UPLEFT, Command.MOVE_UPRIGHT);
            return Behavior.withMoveAndAttack(character, move, pass);
        };
        public static CharacterCommandMutation player = (player) => (command) =>
            Behavior.withMoveAndAttack(player, command,
                Behavior.withItemPickup(player, pass));

    }
}
