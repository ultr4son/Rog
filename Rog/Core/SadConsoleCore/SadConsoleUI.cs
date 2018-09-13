using System;
using SadConsole;
using Microsoft.Xna.Framework;
using SadConsole.Input;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework.Graphics;
using SadConsole.StringParser;
using SadConsole.Surfaces;

namespace Rog.Core.SadConsoleRog
{
    class SadConsoleUI : IOutput
    {
        public SadConsoleUI()
        {
            SadConsole.Game.Create("Fonts/IBM.font", 80, 25);
            SadConsole.Game.OnInitialize = Init;
        }

        public void Notify(ProgramState state)
        {
        }

        public static void Init()
        {
            MapConsole map = new MapConsole();

        }
    }
}
