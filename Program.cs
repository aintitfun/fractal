using System;
using Gtk;

namespace fractal
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.fractal.fractal", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            app.AddWindow(win);

            win.Title="hola";

            win.Show();
            Application.Run();



            
            
        }
    }
}
