using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
 
    public class MapGenerator
    {
       
        public static Floor basicFloor((int,int) size)
        {
            Floor floor = new Floor(size);
            List<Character> walls = new List<Character>();
            for(int x = 0; x < size.Item1; x++)
            {
                for(int y = 0; y < size.Item2; y++)
                {
                    if(x == 0 || y == 0 || x == size.Item1 - 1 || y == size.Item2 - 1)
                    {
                        walls.Add(Make.Wall(10, (x, y)));
                    }
                }
            }
            floor.Walls = walls;
            return floor;
        }
    }
}
