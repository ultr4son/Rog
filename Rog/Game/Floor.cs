using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public class Floor
    {
        public Floor(Tuple<int, int> size)
        {
            characters = new List<Character>();
            walls = new List<Character>();
            dead = new List<Character>();
            items = new List<Item>();
            this.size = size;
        }
        public IEnumerable<Character> obstacles()
        {
            return characters.Concat(walls);
        }
        public IEnumerable<Character> all()
        {
            return characters.Concat(walls).Concat(dead);
        }

        public List<Character> characters;
        public List<Character> walls;
        public List<Character> dead;
        public List<Item> items;
        public Tuple<int, int> size;
    }
}
