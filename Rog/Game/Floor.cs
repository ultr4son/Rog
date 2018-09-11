using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public class Floor
    {
        public Floor((int, int) size)
        {
            Characters = new List<Character>();
            Walls = new List<Character>();
            Dead = new List<Character>();
            Items = new List<Item>();
            this.Size = size;
        }
        public IEnumerable<Character> Obstacles()
        {
            return Characters.Concat(Walls);
        }
        public IEnumerable<Character> All()
        {
            return Characters.Concat(Walls).Concat(Dead);
        }

        public List<Character> Characters;
        public List<Character> Walls;
        public List<Character> Dead;
        public List<Item> Items;
        public (int width, int height) Size;
    }
}
