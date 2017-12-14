using System.Collections.Concurrent;
using System.Threading;

using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    //This class must be thread safe and reentrant
    class RenderDevice
    {
        private Accelerator accelerator;
        private RenderStream stream;
        public RenderDevice (Accelerator accelerator)
        {
            this.accelerator = accelerator;
            stream = new RenderStream();
        }
        public dynamic IssueCommand(RenderCommand command)
        {
            EventWaitHandle waitHandle = new EventWaitHandle(false,EventResetMode.AutoReset);
            stream.IssueCommand(command, waitHandle);
            waitHandle.WaitOne();
            return command.result;
        }
    }
}
