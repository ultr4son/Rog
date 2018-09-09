using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public static class Make
    {
        public static Character character(int hp, string name, CharacterType characterType, Team team, (int,int) position)
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
        public static Character player(int hp, string name, (int,int) position)
        {
            return new Character()
            {
                hp = hp,
                name = name,
                position = position,
                characterType = CharacterType.PLAYER,
                primaryArm = Items.hand,
                team = Team.PLAYER_FRIENDLY
            };
        }
        public static Character bat(int hp, (int,int) position)
        {
            return new Character()
            {
                hp = hp,
                name = "bat",
                characterType = CharacterType.BAT,
                position = position,
                team = Team.MONSTER,
                inventory = new List<Item>(),
                primaryArm = Items.hand

            };
        }
        public static Character dummy(int hp, (int,int) position)
        {
            return new Character()
            {
                hp = hp,
                name = "dummy",
                characterType = CharacterType.DUMMY,
                position = position,
                team = Team.MONSTER,
                inventory = new List<Item>(),
                primaryArm = Items.hand

            };
        }

        public static Character wall(int hp, (int,int) position)
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
    }
}
