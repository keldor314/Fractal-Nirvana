using System;
using System.Collections.Generic;
using System.Text;

using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    class RenderDevice
    {
        private Accelerator accelerator;
        private RenderStream stream;
        public RenderDevice (Accelerator accelerator)
        {
            this.accelerator = accelerator;
            stream = new RenderStream();
        }
        public void StartRender()
        {
            stream.StartRender();
        }
    }
}
