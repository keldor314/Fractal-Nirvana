using System.Threading.Tasks;

using Avalonia.Controls;
using Avalonia.Threading;


namespace Fractal_Nirvana
{
    class Preview : Image
    {
        private Renderer renderer;
        private PrecisionTimer timer;
        public Preview ()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            renderer = new Renderer();
            renderer.StartRender();
            timer = new PrecisionTimer(60);
            Update();
        }
        private void Update ()
        {
            Task.Run(() =>
            {
                timer.Await();
                Dispatcher.UIThread.InvokeAsync(() => Update());
            });
        }
    }
}
