using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog
{
    static class GameUtil
    {
        public class MoveResult
        {
            public Tuple<int, int> newPos;
            public bool moved;
            public int? damageDone;
        }
        public static readonly Random random = new Random();
        public static bool occupied(Tuple<int,int> pos, IEnumerable<Character> entities)
        {
            return entities.ToList().Exists(e => e.position.Item1 == pos.Item1 && e.position.Item2 == pos.Item2);
        }
        public static bool outOfBounds(Tuple<int, int> pos, int xSize, int ySize)
        {
            return 
            pos.Item1 > 0 && pos.Item1 < xSize && 
            pos.Item2 < 0 && pos.Item2 > ySize;
        }
        public static StateMutation<ProgramState> withRender(StateMutation<ProgramState> f)
        {
            return (state) =>
            {
                var mut = f(state);
                state.ui.renderMap(mut.game.floor);
                return mut;
            };
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
         
        public delegate ProgramState MoveHandler(MoveResult move, ProgramState state);
        public static MoveHandler withReporting(Character reportee, StateMutation<ProgramState> f)
        {
            return (result, state) =>
            {
                if (!result.moved)
                {
                    Character hit = characterAt(result.newPos, state.game.floor);
                    if (result.damageDone != null)
                    {
                        state.ui.showMessage($"{reportee.name} hit {hit.name} for {result.damageDone}!");
                    }
                    else
                    {
                        state.ui.showMessage($"{reportee.name} ran into {hit.name}");
                    }
                }
                return f(state);
            };
        }
        public static StateMutation<ProgramState> withMoveAndInteract(Character character, Command movement, MoveHandler f)
        {
            return (state) => 
            {
                Tuple<Tuple<int, int>, bool> newPos = GameUtil.move(state.game.floor.obstacles(), character.position, movement, state.game.floor.size);
                int? damageDone = null;
                Character attackee = null;
                if (newPos.Item2)
                {
                    character.position = newPos.Item1;
                }
                else
                {
                    Character hit = state.game.floor.obstacles().First(c => c.position.Item1 == newPos.Item1.Item1 && c.position.Item2 == newPos.Item1.Item2);
                    if(hit.team != Team.NEUTRAL && hit.team != character.team)
                    {
                        damageDone = doAttack(character, hit, state.game.floor);
                        attackee = hit;
                    }
                }
                return f(new MoveResult()
                {
                    damageDone = damageDone,
                    moved = newPos.Item2,
                    newPos = newPos.Item1 
                }
                , state);
                
            };
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

        public static Tuple<Tuple<int, int>, bool> move(IEnumerable<Character> wallsAndCharacters, Tuple<int, int> pos, Command dir, Tuple<int,int> bounds)
        {
            Tuple<int, int> newPos;
            switch (dir)
            {
                case Command.MOVE_UP:
                    newPos = Tuple.Create(pos.Item1, pos.Item2 + 1);
                    break;
                case Command.MOVE_DOWN:
                    newPos = Tuple.Create(pos.Item1, pos.Item2 - 1);
                    break;
                case Command.MOVE_LEFT:
                    newPos = Tuple.Create(pos.Item1 - 1, pos.Item2);
                    break;
                case Command.MOVE_RIGHT:
                    newPos = Tuple.Create(pos.Item1 + 1, pos.Item2);
                    break;
                case Command.MOVE_UPRIGHT:
                    newPos = Tuple.Create(pos.Item1 + 1, pos.Item1 + 1);
                    break;
                case Command.MOVE_UPLEFT:
                    newPos = Tuple.Create(pos.Item1 - 1, pos.Item2 + 1);
                    break;
                case Command.MOVE_DOWNRIGHT:
                    newPos = Tuple.Create(pos.Item1 + 1, pos.Item2 + 1);
                    break;
                case Command.MOVE_DOWNLEFT:
                    newPos = Tuple.Create(pos.Item1 - 1, pos.Item2 - 1);
                    break;
                default:
                    newPos = pos;
                    break;
            }
            if(!occupied(newPos, wallsAndCharacters) && !outOfBounds(newPos, bounds.Item1, bounds.Item2))
            {
                return Tuple.Create(newPos, true);
            }
            return Tuple.Create(newPos, false);

        }
    }
}
