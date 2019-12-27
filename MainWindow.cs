using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace fractal
{
    public class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;

        private int _counter;
        private Screen screen;
        private DrawingArea drawingArea;
        private Cairo.Context cr;
        private Cairo.Surface surface = null;
        private IFractal fractal;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);





            DeleteEvent += Window_DeleteEvent;   
            
            drawingArea = new DrawingArea ();         
            drawingArea.Drawn += new DrawnHandler(OnDraw);


            fractal=new Mandlebrot();

        }

        private void OnDraw (object o, DrawnArgs args)
        {

            Widget widget = o as Widget;
			
			if (surface != null)
				surface.Dispose ();

            cr = args.Cr;
            var allocation = widget.Allocation;
            surface = widget.Window.CreateSimilarSurface (Cairo.Content.Color, allocation.Width, allocation.Height);
            cr.SetSourceSurface (surface, 0, 0);
            screen = new Screen( ref drawingArea, ref cr, ref fractal);
            screen.Paint();
            
            //Cairo.Context cr =  args.Cr;
            //IFractal i=new Mandlebrot();
            //Screen screen=new Screen();
            //i.Paint(ref screen);
            //cr.LineTo(100,100);
            //cr.LineTo(200,200);
            //Console.WriteLine("se ejecuta");
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            _counter++;
            _label1.Text = "Hello World! This button has been clicked " + _counter + " time(s).";
        }
    }
}
