using Rog.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public class ConsoleUI : IUI
    {
        
        private string ToChar(CharacterType type)
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
        private void Draw(ProgramState state)
        {
            switch(state.UIState)
            {
                case UIState.MAP:
                    DrawMap(state);
                    break;
                case UIState.START_SCREEN:
                    DrawStart(state);
                    break;
            }
        }
        private void DrawStart(ProgramState state)
        {
            PromptValue pv = state.StartScreen.Peek();
            Console.WriteLine(pv.Prompt);
            Console.WriteLine(pv.Getter(state));
        }
        private void DrawMap(ProgramState state) 
        {
            StringBuilder b = new StringBuilder();
            Floor floor = state.Game.Floor;
            List<Character> all = floor.Obstacles().ToList();
            System.Console.WriteLine(state.Log.LastOrDefault());
            for (int y = floor.Size.height; y >= 0; y--)
            {
                for (int x = 0; x < floor.Size.width; x++)
                {
                    if (all.Exists(c => c.Position.x == x && c.Position.y == y))
                    {
                        Character character = all.Find(c => c.Position.x == x && c.Position.y == y);
                        b.Append(ToChar(character.CharacterType));
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
        public void Notify(ProgramState state)
        {
            System.Console.Clear();
            Draw(state);
        }

        public (int width, int height) GetSize()
        {
            return (Console.WindowWidth, Console.WindowHeight);
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
