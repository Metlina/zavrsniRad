using System;
using System.Diagnostics;

namespace Redux.Sample
{
    public class DebugStopwatch : IDisposable
    {
        string action;
        Stopwatch sw;
        bool disposed;

        public DebugStopwatch(string action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            if (disposed)
                return;

            disposed = true;
        }
    }
}

