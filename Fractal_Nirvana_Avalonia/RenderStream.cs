using System.Collections.Generic;

using ILGPU;
using ILGPU.Runtime;

namespace Fractal_Nirvana
{
    class RenderStream
    {
        Accelerator Device;
        AcceleratorStream Stream;
        Kernel ActiveKernel;
        Dictionary<string, object> ActiveParameters;
        MemoryBuffer Accumulator;


        RenderStream() { }
        void StartRender() { }
        void StopRender() { }
        void ClearRenderTarget() { }
        void CaptureRenderTarget() { }
        ~RenderStream() { }
    }
}
