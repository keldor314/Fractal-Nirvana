using System;
using System.Threading;

namespace Fractal_Nirvana
{
    class RenderCommand
    {
        static int currIndex = 0;
        public int priority;
        public int index;
        public Func<RenderStream,object> command;
        public object result;
        public RenderCommand(Func<RenderStream, object> command, int priority=0)
        {
            index = Interlocked.Increment(ref currIndex);
            this.priority = priority;
            this.command = command;
        }
    }
}
