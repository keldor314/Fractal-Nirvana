using System.Collections.Concurrent;
using System.Threading;

using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    //This class must be thread safe and reentrant
    class RenderDevice
    {
        private Accelerator accelerator;
        private RenderStream renderStream;
        public RenderDevice (Accelerator accelerator)
        {
            this.accelerator = accelerator;
            renderStream = new RenderStream();
        }
        public object IssueCommand(RenderCommand command)
        {
            EventWaitHandle waitHandle = new EventWaitHandle(false,EventResetMode.AutoReset);
            renderStream.IssueCommand(command, waitHandle);
            waitHandle.WaitOne();
            return command.result;
        }
    }
}
