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
        public static StateMutation<ProgramState> Pass = (state) => state;

        public static CharacterCommandMutation Dummy = (character) => (intent) => Pass;

        public static CharacterCommandMutation Bat = (character) => (intent) =>
        {
            Command move = GameUtil.PickOne(Command.MOVE_DOWN, Command.MOVE_DOWNLEFT, Command.MOVE_DOWNRIGHT, Command.MOVE_LEFT, Command.MOVE_RIGHT, Command.MOVE_UP, Command.MOVE_UPLEFT, Command.MOVE_UPRIGHT);
            return Behavior.WithMoveAndAttack(character, move, Pass);
        };
        public static CharacterCommandMutation player = (player) => (command) =>
            Behavior.WithMoveAndAttack(player, command,
                Behavior.WithItemPickup(player, Pass));

    }
}
