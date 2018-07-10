using System;
using System.Threading;

using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    public class RenderCommand
    {
        static int currIndex = 0;
        public int priority;
        public int index;
        public Func<AcceleratorStream,object> command;
        public object result;
        public RenderCommand(Func<AcceleratorStream, object> command, int priority=0)
        {
            index = Interlocked.Increment(ref currIndex);
            this.priority = priority;
            this.command = command;
        }
    }
}
