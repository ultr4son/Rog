using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rog.Core.Forms
{
    class FormsInput : IInput
    {
        public FormsInput(Form mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        Form mainWindow;
        public event EventHandler<Command> OnInput;

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Command command;
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.NumPad8:
                    command = Command.MOVE_UP;
                    break;
                case Keys.Down:
                case Keys.NumPad2:
                    command = Command.MOVE_DOWN;
                    break;
                case Keys.Right:
                case Keys.NumPad6:
                    command = Command.MOVE_RIGHT;
                    break;
                case Keys.Left:
                case Keys.NumPad7:
                    command = Command.MOVE_LEFT;
                    break;
                default:
                    return;
            }
            OnInput(this, command);
        }

        public void Start()
        {
            mainWindow.KeyDown += MainWindow_KeyDown;
        }

        public void Stop()
        {
            mainWindow.KeyDown -= MainWindow_KeyDown;
        }
    }
}
