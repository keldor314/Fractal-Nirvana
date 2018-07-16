using System;
using System.Collections.Generic;
using System.Text;

using Fractal_Nirvana;

namespace Fractal_Nirvana.API
{
    public interface IRenderer
    {
        void StartRender(int width, int height);
        void StopRender();
        void SetParameters(object parameters);
        void ClearRenderTarget();
        float [] CaptureRenderTarget();
    }
}
