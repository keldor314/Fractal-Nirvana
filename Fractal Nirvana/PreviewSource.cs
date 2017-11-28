using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fractal_Nirvana
{
    public partial class PreviewImage : Image
    {
        public PreviewImage()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
        }
        private MemoryStream SourceStream;
        protected override void OnSizeAllocated(double width, double height)
        {
            var buffer = new byte[(int)(3 * height * width)];
            for (int n = 0; n < buffer.Length; n += 3)
            {
                buffer[n] = (byte)n;
                buffer[n + 1] = (byte)(n >> 8);
                buffer[n + 2] = (byte)(n >> 16);
            }
            SourceStream = new MemoryStream(buffer);
            Source = ImageSource.FromStream(() => SourceStream);
            OnPropertyChanged("Source");
            base.OnSizeAllocated(width, height);
        }
    }
}