using System.Threading.Tasks;

using Avalonia.Controls;
using Avalonia.Threading;


namespace Fractal_Nirvana
{
    class Preview : Image
    {
        private Renderer renderer;
        private PrecisionTimer timer;
        private bool updateInProgress = false;
        public Preview ()
        {
            this.InitializeComponent();
        }
        private void InitializeComponent()
        {
            renderer = new Renderer();
            timer = new PrecisionTimer(60);
            Update();
        }
        private void Update()
        {
            Task.Run(() =>
            {
                timer.Await();
                Dispatcher.UIThread.InvokeAsync(() => Update());
            });
        }
    }
}
