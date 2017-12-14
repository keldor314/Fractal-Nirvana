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
        public void StartRender ()
        {
            foreach (RenderDevice device in devices)
            {
            }
        }
    }
}
