using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public static class Make
    {
        public static Character Character(int hp, string name, CharacterType characterType, Team team, (int,int) position)
        {
            return new Character()
            {
                Hp = hp,
                Name = name,
                Position = position,
                CharacterType = characterType,
                Team = team
            };
        }
        public static Character Player(int hp, string name, (int,int) position)
        {
            return new Character()
            {
                Hp = hp,
                Name = name,
                Position = position,
                CharacterType = CharacterType.PLAYER,
                Primary = Items.hand,
                Team = Team.PLAYER_FRIENDLY
            };
        }
        public static Character Bat(int hp, (int,int) position)
        {
            return new Character()
            {
                Hp = hp,
                Name = "bat",
                CharacterType = CharacterType.BAT,
                Position = position,
                Team = Team.MONSTER,
                Inventory = new List<Item>(),
                Primary = Items.hand

            };
        }
        public static Character Dummy(int hp, (int,int) position)
        {
            return new Character()
            {
                Hp = hp,
                Name = "dummy",
                CharacterType = CharacterType.DUMMY,
                Position = position,
                Team = Team.MONSTER,
                Inventory = new List<Item>(),
                Primary = Items.hand

            };
        }

        public static Character Wall(int hp, (int,int) position)
        {
            return new Character()
            {
                Hp = hp,
                Name = "wall",
                Position = position,
                Team = Team.NEUTRAL,
                CharacterType = CharacterType.WALL
            };
        }
    }
}
