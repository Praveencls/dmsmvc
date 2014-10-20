using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Logging
{
    public interface ILogContext : IDisposable
    {
        string Name { get; set; }
    }
}
