using Rog.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public class ConsoleUI : IUserInterface
    {
        
        private string toChar(CharacterType type)
        {
            switch (type)
            {
                case CharacterType.BAT:
                    return "b";
                case CharacterType.PLAYER:
                    return "@";
                case CharacterType.WALL:
                    return "#";
                case CharacterType.DUMMY:
                    return "d";
                default:
                    return "c";
            }   
        }
        public void notify(ProgramState state)
        {
            StringBuilder b = new StringBuilder();
            Floor floor = state.game.floor;
            List<Character> all = floor.obstacles().ToList();
            for(int y = floor.size.Item2; y >= 0; y--)
            {
                for(int x = 0; x < floor.size.Item1; x++)
                {
                    if(all.Exists(c => c.position.Item1 == x && c.position.Item2 == y))
                    {
                        Character character = all.Find(c => c.position.Item1 == x && c.position.Item2 == y);
                        b.Append(toChar(character.characterType));
                    }
                    else
                    {
                        b.Append(" ");
                    }
                }
                b.Append("\n");
           }
           Console.Write(b.ToString());
        }

    }
}
