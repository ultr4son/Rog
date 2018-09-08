using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public delegate void ItemAction(Item item, Character actor, Character actee, ProgramState state);
    public class Item : Character
    {
        public Item(bool basic, string name, ItemAction act)
        {
            this.name = name;
            this.basic = basic;
            this.act = act;
            characterType = CharacterType.SWORD;
            team = Team.NEUTRAL;           
        }
        public bool basic;
        public ItemAction act;
    }

    public static class Items
    {
        public static Item hand = new Item(true, "hand", (item, actor, actee, state) =>
        {
            actee.hp -= 1;
        });
    }
}
