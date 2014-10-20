using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoreLib.Logging
{
    public class LogContext : ILogContext
    {
        private const string Currentlogcontextmapkey = "LogContext.Current";

        [ThreadStatic]
        private static ILogContext _outerUnitOfWorkThreadstatic;
        private ILogContext _previous;

        public string Name { get; set; }

        public static ILogContext Current
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Items[Currentlogcontextmapkey] as ILogContext;
                }
                return _outerUnitOfWorkThreadstatic;
            }
            private set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items[Currentlogcontextmapkey] = value;
                }
                else
                {
                    _outerUnitOfWorkThreadstatic = value;
                }

            }
        }

        public LogContext(string name)
        {
            Name = name;
            _previous = Current;
            Current = this;
        }

        ~LogContext()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Current == this)
            {
                Current = _previous;
                _previous = null;
            }
        }
    }
}
