using System.Collections.Concurrent;
using System.Threading;
using System.Linq;
using System;

namespace Fractal_Nirvana
{
    class RenderStream
    {
        private Thread streamThread;
        private ConcurrentQueue<(RenderCommand,EventWaitHandle)> streamCommands = new ConcurrentQueue<(RenderCommand,EventWaitHandle)>();
        private bool renderRunning = false;
        private bool continueStreamThread = true;

        public RenderStream ( )
        {
            streamThread = new Thread(() =>
            {
                while (continueStreamThread)
                {
                    while (streamCommands.Count > 0)
                    {
                        streamCommands.OrderByDescending(cmd => cmd.Item1.index - 5 * cmd.Item1.priority);
                        ValueTuple<RenderCommand,EventWaitHandle> commandAndWaitHandle;
                        if (streamCommands.TryDequeue(out commandAndWaitHandle))
                        {
                            var command = commandAndWaitHandle.Item1;
                            var waitHandle = commandAndWaitHandle.Item2;
                            command.result = command.command();
                            waitHandle.Set();
                        }
                    }
                    Thread.Sleep(1);
                }
            });
            streamThread.Start();
        }

        //must be thread-safe reentrant
        public void IssueCommand(RenderCommand command, EventWaitHandle waitHandle)
        {
            streamCommands.Enqueue((command, waitHandle));
        }

        public void StartRender ()
        {
        }

        void StopRender () { }
        void ClearRenderTarget () { }
        void CaptureRenderTarget () { }
        ~RenderStream ()
        {
            continueStreamThread = false;
        }
    }
}
