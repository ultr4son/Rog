using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public class ConsoleInputEngine : IInput
    {
        public ConsoleInputEngine()
        {
        }
        public event EventHandler<Command> OnInput;
        public void start()
        {
            while (true)
            {
                ConsoleKeyInfo key = System.Console.ReadKey();
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
                OnInput(this, command);
                
            }
        }

        public void stop()
        {
            throw new NotImplementedException();
        }

    }
}
