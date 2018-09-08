using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public static class Behavior
    {

        

        public static StateMutation<ProgramState> withItemPickup(Character character, StateMutation<ProgramState> f)
        {
            return (state) =>
            {
                Item item = state.game.floor.items.FirstOrDefault(i => i.position.Item1 == character.position.Item1 && i.position.Item2 == character.position.Item2);
                if (item != null)
                {
                    state.logger.log($"{character.name} picked up {item.name}");
                    GameUtil.doPickup(character, item, state.game.floor.items);
                }
                return f(state);
            };
        }
        public static StateMutation<ProgramState> withMoveAndAttack(Character character, Command movement, StateMutation<ProgramState> f)
        {
            return (state) =>
            {
                Tuple<Tuple<int, int>, bool> newPos = GameUtil.move(state.game.floor.obstacles(), character.position, movement, state.game.floor.size);
                if (newPos.Item2)
                {
                    character.position = newPos.Item1;
                }
                else
                {
                    Character hit = state.game.floor.obstacles().First(c => c.position.Item1 == newPos.Item1.Item1 && c.position.Item2 == newPos.Item1.Item2);
                    if (hit.team != Team.NEUTRAL && hit.team != character.team)
                    {
                        int damageDone = GameUtil.doAttack(character, hit, state.game.floor);
                        state.logger.log($"{character.name} hit {hit.name} for {damageDone}");

                    }
                }
                return f(state);
            };
        }
    }
}
