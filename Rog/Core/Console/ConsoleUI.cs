using Rog.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public class ConsoleUI : IOutput
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
            System.Console.Clear();
            StringBuilder b = new StringBuilder();
            Floor floor = state.game.floor;
            List<Character> all = floor.obstacles().ToList();
            System.Console.WriteLine(state.log.FirstOrDefault());
            for (int y = floor.size.height; y >= 0; y--)
            {
                for(int x = 0; x < floor.size.width; x++)
                {
                    if(all.Exists(c => c.position.x == x && c.position.y == y))
                    {
                        Character character = all.Find(c => c.position.x == x && c.position.y == y);
                        b.Append(toChar(character.characterType));
                    }
                    else
                    {
                        b.Append(" ");
                    }
                }
                b.Append("\n");
           }
           System.Console.Write(b.ToString());
        }

    }
}
