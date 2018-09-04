using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{

    public interface IUserInterface
    {
        void showMessage(string message);
        void renderMap(Floor state);
    }
}
