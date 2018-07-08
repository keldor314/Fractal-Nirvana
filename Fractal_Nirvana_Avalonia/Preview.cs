using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Media.Imaging;
using Avalonia.Threading;


namespace Fractal_Nirvana
{
    class Preview : Image
    {
        private Renderer renderer;
        private PrecisionTimer timer;
        private WritableBitmap target;
        private bool layoutInitialized = false;
        public Preview ()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            renderer = new Renderer();
            timer = new PrecisionTimer(60);
            LayoutUpdated += Preview_LayoutUpdated;
            Update();
        }
        private void Preview_LayoutUpdated(object sender, System.EventArgs e)
        {
            renderer.StopRender();
            var size = Bounds.Size;
            var width = (int)size.Width;
            var height =(int)size.Height;
            renderer.StartRender(width, height);
            layoutInitialized = true;
        }
        private void Update ()
        {
            if (layoutInitialized)
            {
                var size = Bounds.Size;
                var width = (int)size.Width;
                var height = (int)size.Height;
                target = new WritableBitmap(width, height, PixelFormat.Rgba8888);
                var buffer = target.Lock();
                var address = buffer.Address;
                var time = System.DateTime.Now.Ticks;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int c = (int)((((x + 1L) & (y + 1L)) *time)/50000000L);
                        int color = (int)(0xff000000 + (0x00ffffff & (c * 40 + c * 700 + c * 100000)));
                        Marshal.WriteInt32(address, (x + y * width) * sizeof(int), color);
                    }
                }
                Source = target;
            }
            Task.Run(() =>
            {
                timer.Await();
                Dispatcher.UIThread.InvokeAsync(() => Update());
            });
        }
    }
}
