using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Core
{
    class InMemoryLogger : ILogger
    {
        private List<string> logs = new List<string>();
        public IEnumerable<string> getLog()
        {
            return logs;
        }

        public void log(string message)
        {
            logs.Add(message);
        }
    }
}
