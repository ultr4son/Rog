using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using Console = SadConsole.Console;


namespace Rog.Core
{
    internal class MapConsole : Console
    {
        private ProgramState programState;
        public MapConsole() : base(Constants.CONSOLE_WIDTH, Constants.CONSOLE_HEIGHT)
        {

        }
        public void Notify(ProgramState state)
        {
            programState = state;
        }
        private int Glyph(CharacterType type)
        {
            switch(type)
            {
                case CharacterType.BAT:
                    return 99;
                case CharacterType.DUMMY:
                    return 9;
                default:
                    return 0;
            }
        }
        public override void Update(TimeSpan delta)
        {

            for(int x = 0; x < programState.Game.Floor.Size.width; x++)
            {
                for(int y = 0; y < programState.Game.Floor.Size.height; y++)
                {
                    

                }
            }
            base.Update(delta);
        }

    }
}
