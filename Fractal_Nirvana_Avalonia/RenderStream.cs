using System.Collections.Generic;
using System.Threading;
using System;

using ILGPU.Runtime;
using Avalonia.Controls.Platform;
using Avalonia.Threading;

namespace Fractal_Nirvana
{
    class RenderStream
    {
        private Thread streamThread;
        private delegate void StreamCommand ();
        private StreamCommand streamCommand;
        private bool continueStreamThread = true;

        public RenderStream ( )
        {
            streamThread = new Thread(() =>
            {
                while (continueStreamThread)
                {
                    while (streamCommand != null)
                    {
                        var command = streamCommand;
                        streamCommand = null;
                        command.Invoke();
                    }
                    Thread.Sleep(1);
                }
            });
            streamThread.Start();
        }

        public void StartRender ()
        {
            streamCommand = () => InternalStartRender();
        }
        private void InternalStartRender()
        {
            Console.WriteLine("Hello from stream thread!");
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
