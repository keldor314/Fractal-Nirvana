using System.Collections.Generic;

using ILGPU;
using ILGPU.Runtime;

using Fractal_Nirvana_API;

namespace Fractal_Nirvana
{
    class Renderer
    {
        static bool isInitialized = false;
        public static List<RenderDevice> devices = new List<RenderDevice>();
        Context context;
        public IRenderer Engine;
        public Renderer (IRenderer engine)
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
            Engine = engine;
        }
    }
}
