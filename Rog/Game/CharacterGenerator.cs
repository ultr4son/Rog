using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog
{
    public static class CharacterGenerator
    {
        public static Character makeCharacter(int hp, string name, CharacterType characterType, Team team,Tuple<int, int> position)
        {
            return new Character()
            {
                hp = hp,
                name = name,
                position = position,
                characterType = characterType,
                team = team
            };
        }

        public static Character makeBat(int hp, Tuple<int, int> position)
        {
            return new Character()
            {
                hp = hp,
                name = "bat",
                characterType = CharacterType.BAT,
                position = position,
                team = Team.MONSTER
            };
        }
        public static Character makeDummy(int hp, Tuple<int, int> position)
        {
            return new Character()
            {
                hp = hp,
                name = "dummy",
                characterType = CharacterType.DUMMY,
                position = position,
                team = Team.MONSTER
            };
        }
        
        public static Character makeWall(int hp, Tuple<int,int> position)
        {
            return new Character()
            {
                hp = hp,
                name = "wall",
                position = position,
                team = Team.NEUTRAL,
                characterType = CharacterType.WALL
            };
        }

        public static StateMutation<ProgramState> pass = (state) => state;

        public static CharacterCommandMutation bindDummy = (character) => (intent) => pass;

        public static CharacterCommandMutation bindBat = (character) => (intent) => 
        {
            Command move = GameUtil.pickOne(Command.MOVE_DOWN, Command.MOVE_DOWNLEFT, Command.MOVE_DOWNRIGHT, Command.MOVE_LEFT, Command.MOVE_RIGHT, Command.MOVE_UP, Command.MOVE_UPLEFT, Command.MOVE_UPRIGHT);
            return GameUtil.withMoveAndInteract(character, move, 
                GameUtil.withReporting(character, pass));
        };
        public static CharacterCommandMutation bindPlayer = (player) => (command) => 
        GameUtil.withRender(
            GameUtil.withMoveAndInteract(player, command, 
                GameUtil.withReporting(player, pass)));


    }
}
