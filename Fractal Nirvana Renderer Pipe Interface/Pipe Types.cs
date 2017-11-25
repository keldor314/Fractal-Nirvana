using System;
using System.IO;

namespace Fractal_Nirvana.Renderer
{
    [Serializable]
    struct Dimensions
    {
        int Width;
        int Height;
    }
    [Serializable]
    struct ImageStream
    {
        Dimensions Dimensions;
        MemoryStream Image;
    }
}
