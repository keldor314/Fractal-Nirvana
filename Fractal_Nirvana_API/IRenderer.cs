using System;
using System.Collections.Generic;
using System.Text;

namespace Fractal_Nirvana_API
{
    public interface IRenderer
    {
        public object StartRender(RenderStream s, int width, int height);
        public object StopRender(RenderStream s);
        void ClearRenderTarget();
        void CaptureRenderTarget();
    }
}
