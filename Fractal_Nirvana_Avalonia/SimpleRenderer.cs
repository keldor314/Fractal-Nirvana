using System;
using System.Collections.Generic;
using System.Text;
using Fractal_Nirvana;

namespace Fractal_Nirvana_API
{
    class SimpleRenderer<T>: IRenderer where T : ISimpleRendererCommands, new()
    {
        List<T> localEngines;
        public SimpleRenderer()
        {
            localEngines = new List<T>();
            foreach (var device in Renderer.devices)
            {
                var dev = new T();
                dev.Initialize(device);
                localEngines.Add(dev);
            }
        }

        public float [] CaptureRenderTarget()
        {
            throw new NotImplementedException();
        }

        public void ClearRenderTarget()
        {
            throw new NotImplementedException();
        }

        public void StartRender(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void StopRender()
        {
            throw new NotImplementedException();
        }
    }
}
