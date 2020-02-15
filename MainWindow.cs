using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;


namespace fractal
{
    public class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button RefreshButton = null;
        [UI] private Frame PictureFrame = null;
        private Screen screen;
        private DrawingArea drawingArea;
        private Cairo.Context cr;
        private Cairo.Surface surface = null;
        private IFractal fractal;

        private bool refreshClicked =false;
        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;   
            DrawingArea da = new DrawingArea ();
            da.SetSizeRequest (500,300);
            PictureFrame.Add (da);
            fractal=new Mandlebrot();
        }

        private void OnRefreshButtonClick(object sender, EventArgs args)
        {
            refreshClicked=true;
        }
        private void OnDraw (object o, DrawnArgs args)  
        {
        }

      private void FrameDrawn (object o, DrawnArgs args)
        {
            if (refreshClicked)
            {
                Widget widget = o as Widget;
                Cairo.Context Cr = args.Cr;
                cr=Cr;	      	
                Gdk.Rectangle alloc = widget.Allocation;
                screen = new Screen( drawingArea, cr, fractal, PictureFrame);
                screen.Paint();
                refreshClicked=false;
            }
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void OnClick(object sender,ButtonPressEventArgs args){
            Console.WriteLine(args.Event.X);
            Console.WriteLine(args.Event.Y);
            fractal.Center=screen.GetClickFractalPosition(new Point (args.Event.X, args.Event.Y));
            if (args.Event.Button==1)
            {
                fractal.ScaleFactor=fractal.ScaleFactor*0.8f;
            }
            if (args.Event.Button==3)
            {
                fractal.ScaleFactor=fractal.ScaleFactor*1.2f;
            }
            int width;
            int height;
            this.GetSize(out width,out height);
            //this.Resize(width-1,height-1);
            refreshClicked=true;
            PictureFrame.QueueDraw();
        }
        
        private void FramePictureOnClick(object sender,ButtonPressEventArgs args)
        {
            fractal.Center=screen.GetClickFractalPosition(new Point (args.Event.X, args.Event.Y));
            if (args.Event.Button==1)
            {
                fractal.ScaleFactor=fractal.ScaleFactor*0.8f;
            }
            if (args.Event.Button==3)
            {
                fractal.ScaleFactor=fractal.ScaleFactor*1.2f;

            }
            int width;
            int height;
            this.GetSize(out width,out height);
            //this.Resize(width-1,height-1);
            this.QueueDraw();
        }
    }
}
