using Rog.Core.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core.Forms
{
    class FormsUI : IOutput
    {
        Inventory inventoryForm;
        Log logForm;
        MainWindow mainWindowForm;

        public void notify(ProgramState state)
        {
            logForm.logText.Text = state.log.Aggregate((s, l) => s += $"{l}\n");
        }
    }
}
