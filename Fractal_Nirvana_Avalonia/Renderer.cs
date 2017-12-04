using System.Collections.Generic;

using ILGPU;
using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    class Renderer
    {
        List<Accelerator> accelerators = new List<Accelerator>();
        Context context;
        public Renderer()
        {
            context = new Context();
            foreach (var accId in Accelerator.Accelerators)
            {
                var acc = Accelerator.Create(context, accId);
                accelerators.Add(acc);
            }
        }
    }
}
