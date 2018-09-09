using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    static class GameUtil
    {
        public static readonly Random random = new Random();
        public static bool occupied((int x, int y) pos, IEnumerable<Character> entities)
        {
            return entities.ToList().Exists(e => e.position.x == pos.x && e.position.y == pos.y);
        }
        public static bool outOfBounds((int x, int y) pos, int xSize, int ySize)
        {
            return 
            pos.x > 0 && pos.x < xSize && 
            pos.y < 0 && pos.y > ySize;
        }
        public static T pickOne<T>(params T[] items)
        {
            int i = random.Next(0, items.Count());
            return items[i];
        }
        public static Character characterAt(Tuple<int,int> pos, Floor floor)
        {
            return floor.all().First(c => c.position.Item1 == pos.Item1 && c.position.Item2 == pos.Item2);
        }
         
        public static void doPickup(Character character, Item item, List<Item> items)
        {
            character.inventory.Add(item);
            items.Remove(item);
        }
        public static int doAttack(Character attacker, Character attackee, Floor floor)
        {
            if (attackee.hp > 0)
            {
                attackee.hp -= 1;
                if (attackee.hp <= 0)
                {
                    floor.characters.Remove(attackee);
                    floor.dead.Add(attackee);
                }
            }
            return 1;
        }

        public static ((int x, int y) newPos, bool moved) move(IEnumerable<Character> wallsAndCharacters, (int x, int y) pos, Command dir, (int width, int height) bounds)
        {
            (int x, int y) newPos;
            switch (dir)
            {
                case Command.MOVE_UP:
                    newPos = (pos.x, pos.y + 1);
                    break;
                case Command.MOVE_DOWN:
                    newPos = (pos.x, pos.y - 1);
                    break;
                case Command.MOVE_LEFT:
                    newPos = (pos.x - 1, pos.y);
                    break;
                case Command.MOVE_RIGHT:
                    newPos = (pos.x + 1, pos.y);
                    break;
                case Command.MOVE_UPRIGHT:
                    newPos = (pos.x + 1, pos.y + 1);
                    break;
                case Command.MOVE_UPLEFT:
                    newPos = (pos.x - 1, pos.y + 1);
                    break;
                case Command.MOVE_DOWNRIGHT:
                    newPos = (pos.x + 1, pos.y + 1);
                    break;
                case Command.MOVE_DOWNLEFT:
                    newPos = (pos.x - 1, pos.y - 1);
                    break;
                default:
                    newPos = pos;
                    break;
            }
            if(!occupied(newPos, wallsAndCharacters) && !outOfBounds(newPos, bounds.Item1, bounds.Item2))
            {
                return (newPos, true);
            }
            return (newPos, false);

        }
    }
}
