using System.Collections.Concurrent;
using System.Threading;
using System.Linq;
using System;

using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    public class RenderStream
    {
        private Thread streamThread;
        private AcceleratorStream deviceStream;
        private ConcurrentQueue<(RenderCommand,EventWaitHandle)> streamCommands = new ConcurrentQueue<(RenderCommand,EventWaitHandle)>();
        private bool continueStreamThread = true;

        public RenderStream ( AcceleratorStream stream)
        {
            deviceStream = stream;
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
                            command.result = command.command(deviceStream);
                            waitHandle.Set();
                        }
                    }
                    Thread.Sleep(1);
                }
            });
            streamThread.Start();
        }

        public object IssueCommand(RenderCommand command)
        {
            EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            streamCommands.Enqueue((command, waitHandle));
            waitHandle.WaitOne();
            return command.result;
        }

        ~RenderStream ()
        {
            continueStreamThread = false;
        }
    }
}
