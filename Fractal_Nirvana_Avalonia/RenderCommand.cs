using System;
using System.Threading;

namespace Fractal_Nirvana
{
    class RenderCommand
    {
        static int currIndex = 0;
        public int priority;
        public int index;
        public Func<dynamic> command;
        public dynamic result;
        public RenderCommand(Func<dynamic> command, int priority)
        {
            index = Interlocked.Increment(ref currIndex);
            this.priority = priority;
            this.command = command;
        }
    }
}
