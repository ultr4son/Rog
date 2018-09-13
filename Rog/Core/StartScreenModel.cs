using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public enum StartScreenModelState
    {
        INPUT_NAME
    }
    public class StartScreenModel
    {
        public StartScreenModelState State = StartScreenModelState.INPUT_NAME;
        public string Name = null;
    }
}
