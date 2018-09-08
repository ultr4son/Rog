using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    public interface ILogger
    {
        void log(string message);
        IEnumerable<string> getLog();
    }
}
