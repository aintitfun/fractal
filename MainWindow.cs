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
        [UI] private Alignment PictureAlligment=null;
        private Screen screen;
        private Cairo.Context cr;
        private Cairo.Surface surface = null;
        private IFractal fractal;

        //private bool refreshClicked =false;
        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;   
            fractal=new Mandlebrot();
        }

        private void OnRefreshButtonClick(object sender, EventArgs args)
        {
            //refreshClicked=true;
        }
        private void FrameDrawn (object o, DrawnArgs args)
        {
            /*if (refreshClicked)
            {*/
                Widget widget = o as Widget;
                Cairo.Context Cr = args.Cr;
                cr=Cr;	      	
                Gdk.Rectangle alloc = widget.Allocation;
                screen = new Screen(cr, fractal, PictureFrame);
                screen.Paint();
                //refreshClicked=false;
                cr.Dispose();
            /*}*/
        }
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void OnClick(object sender,ButtonPressEventArgs args){


            
            int pictureFrameXPosition=PictureAlligment.Allocation.X;
            int pictureFrameYPosition=PictureAlligment.Allocation.Y;
            if (args.Event.X>pictureFrameXPosition && args.Event.Y>pictureFrameYPosition && args.Event.Button!=2)
            {   
                Point center=new Point(args.Event.X-pictureFrameXPosition, args.Event.Y-pictureFrameYPosition);
                fractal.Center=screen.GetClickFractalPosition(center);
                if (args.Event.Button==1)
                    fractal.ScaleFactor=fractal.ScaleFactor*0.8f;
                if (args.Event.Button==3)
                    fractal.ScaleFactor=fractal.ScaleFactor*1.2f;
                int width;
                int height;
                this.GetSize(out width,out height);
                //this.Resize(width-1,height-1);
                //refreshClicked=true;
                PictureFrame.QueueDraw();
            }
            if (args.Event.Button==2)
            {
                Console.WriteLine("click position: "+args.Event.X+" pictureframe position: " + pictureFrameXPosition);
                Console.WriteLine("click position: "+args.Event.Y+" pictureframe position: " + pictureFrameYPosition);
            }

        }
    }
}
