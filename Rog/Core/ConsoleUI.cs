using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    class ConsoleUI : IUserInterface
    {
        public void showMessage(string message)
        {
            Console.WriteLine(message);
        }
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
        private void drawFloor(Floor floor)
        {
            StringBuilder b = new StringBuilder();
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

        
        public void renderMap(Floor state)
        {
            drawFloor(state);
        }
    }
}
