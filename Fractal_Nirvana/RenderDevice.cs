using System.Collections.Concurrent;
using System.Threading;
using System.Collections.Generic;

using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    //This class must be thread safe and reentrant
    public class RenderDevice
    {
        private Accelerator accelerator;
        public RenderStream executionStream;
        public RenderStream memoryStream;
        public RenderDevice(Accelerator accelerator)
        {
            this.accelerator = accelerator;
            executionStream = new RenderStream(accelerator.CreateStream());
            memoryStream = new RenderStream(accelerator.CreateStream());
        }
    }
}
