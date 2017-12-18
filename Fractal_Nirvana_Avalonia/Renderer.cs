using System.Collections.Generic;

using ILGPU;
using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    class Renderer
    {
        static bool isInitialized = false;
        static List<RenderDevice> devices = new List<RenderDevice>();
        Context context;
        public Renderer ()
        {
            if (!isInitialized)
            {
                context = new Context();
                foreach (var accId in Accelerator.Accelerators)
                {
                    var acc = Accelerator.Create(context, accId);
                    devices.Add(new RenderDevice(acc));
                }
                isInitialized = true;
            }
        }
        public void StartRender (int width, int height)
        {
            foreach (RenderDevice device in devices)
            {
                var command = new RenderCommand((RenderStream stream) => RenderStream.StartRender(stream, width, height));
                device.IssueCommand(command);
            }
        }
        public void StopRender ()
        {
            foreach (RenderDevice device in devices)
            {
                var command = new RenderCommand((RenderStream stream) => RenderStream.StopRender(stream));
                device.IssueCommand(command);
            }
        }
    }
}
