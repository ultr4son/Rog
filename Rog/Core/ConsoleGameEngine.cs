using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public class ConsoleGameEngine : IGameEngine
    {
        public ConsoleGameEngine(RogGame game, ProgramState state)
        {
            this.game = game;
            this.state = state;
           
        }
        private ProgramState state;
        private RogGame game;
        public void start()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Command command;
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.NumPad8:
                        command = Command.MOVE_UP;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.NumPad2:
                        command = Command.MOVE_DOWN;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.NumPad6:
                        command = Command.MOVE_RIGHT;
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.NumPad7:
                        command = Command.MOVE_LEFT;
                        break;
                    default:
                        continue;
                }
                game.sendCommand(command, state);
                
                
            }
        }

        public void stop()
        {
            throw new NotImplementedException();
        }
    }
}
