using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public interface IUI : IOutput
    {
        (int width, int height) GetSize();
        void Print(string message);
    }
}
