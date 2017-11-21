using System;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Maps.GTK;
using Xamarin.Forms.Platform.GTK;
using Xamarin.Forms.Platform.GTK.Helpers;



namespace Fractal_Nirvana.GTK
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Gtk.Application.Init();
            Forms.Init();
            FormsMaps.Init(string.Empty);
            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("Fractal Nirvana");
            window.Show();
            Gtk.Application.Run();
        }
    }
}