using System.Collections.Generic;

using ILGPU;
using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    class Renderer
    {
        List<RenderDevice> devices = new List<RenderDevice>();
        Context context;
        public Renderer ()
        {
            context = new Context();
            foreach (var accId in Accelerator.Accelerators)
            {
                var acc = Accelerator.Create(context, accId);
                devices.Add(new RenderDevice(acc));
            }
        }
        public void StartRender ()
        {
            devices[0].StartRender();
        }
    }
}
