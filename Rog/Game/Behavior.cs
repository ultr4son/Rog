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

        

        public static StateMutation<ProgramState> WithItemPickup(Character character, StateMutation<ProgramState> f)
        {
            return (state) =>
            {
                Item item = state.game.Floor.Items.FirstOrDefault(i => i.Position.x == character.Position.x && i.Position.y == character.Position.y);
                if (item != null)
                {
                    state.log.Add($"{character.Name} picked up {item.Name}");
                    GameUtil.DoPickup(character, item, state.game.Floor.Items);
                }
                return f(state);
            };
        }
        public static StateMutation<ProgramState> WithMoveAndAttack(Character character, Command movement, StateMutation<ProgramState> f)
        {
            return (state) =>
            {
                ((int x, int y) newPos, bool moved) result = GameUtil.Move(state.game.Floor.Obstacles(), character.Position, movement, state.game.Floor.Size);
                if (result.moved)
                {
                    character.Position = result.newPos;
                }
                else
                {
                    Character hit = state.game.Floor.Obstacles().First(c => c.Position.x == result.newPos.x && c.Position.y == result.newPos.y);
                    if (hit.Team != Team.NEUTRAL && hit.Team != character.Team)
                    {
                        int damageDone = GameUtil.DoAttack(character, hit, state.game.Floor);
                        state.log.Add($"{character.Name} hit {hit.Name} for {damageDone}");

                    }
                }
                return f(state);
            };
        }
    }
}
