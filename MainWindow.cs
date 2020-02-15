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

            //RefreshButton.Clicked += OnRefreshButtonClick;
   
            DrawingArea da = new DrawingArea ();
            da.SetSizeRequest (500,300);
            PictureFrame.Add (da);

            //da.Drawn += new DrawnHandler (FrameDrawn);
            //da.ConfigureEvent += new ConfigureEventHandler (FrameConfigure);

   			//da.MotionNotifyEvent += new MotionNotifyEventHandler (FrameMotionNotify);
			//da.ButtonPressEvent += new ButtonPressEventHandler (FramePictureOnClick);

            //da.Events |= Gdk.EventMask.LeaveNotifyMask | Gdk.EventMask.ButtonPressMask | Gdk.EventMask.PointerMotionMask | Gdk.EventMask.PointerMotionHintMask;


            fractal=new Mandlebrot();


        }

        private void OnRefreshButtonClick(object sender, EventArgs args)
        {
            /*Widget widget = sender as Widget;
			
			if (surface != null)
				surface.Dispose ();

            using (Cairo.Context cr = Gdk.CairoHelper.Create (PictureFrame.Window)) 
            {
                var allocation = widget.Allocation;
                surface = PictureFrame.Window.CreateSimilarSurface (Cairo.Content.Color, allocation.Width, allocation.Height);
                cr.SetSourceSurface (surface, 0, 0);
                screen = new Screen( drawingArea, cr, fractal, PictureFrame);
                screen.Paint();
            }*/
            //this.QueueDraw();

            refreshClicked=true;
          
            //DrawnArgs drawnArgs=new DrawnArgs();
            //drawnArgs.Cr=cr;
            //FrameDrawn(PictureFrame,new DrawnArgs().Cr=cr);
            
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

                /*if (surface != null)
                    surface.Dispose ();

                using (Cairo.Context cr = Gdk.CairoHelper.Create (PictureFrame.Window)) 
                {
                    var allocation = widget.Allocation;
                    surface = PictureFrame.Window.CreateSimilarSurface (Cairo.Content.Color, allocation.Width, allocation.Height);
                    cr.SetSourceSurface (surface, 0, 0);
                    screen = new Screen( drawingArea, cr, fractal, PictureFrame);
                    screen.Paint();
                }*/
                screen = new Screen( drawingArea, cr, fractal, PictureFrame);
                screen.Paint();
                refreshClicked=false;
            }
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

        /*private void DrawFractal(object o, DrawnArgs args)
        {
            screen = new Screen( drawingArea, cr, fractal, PictureFrame);
            screen.Paint();
        }*/
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
        /*private void OnClick(object sender,ButtonPressEventArgs args)
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
        }*/
        private void FramePictureOnClick(object sender,ButtonPressEventArgs args)
        {
            /*MessageDialog md = new MessageDialog (null, DialogFlags.Modal, MessageType.Other, ButtonsType.Ok, "entra"+System.Convert.ToString(a.Event.Button)); 
			md.Run (); 
			md.Dispose(); */
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

        private void FrameConfigure (object o, ConfigureEventArgs args)
		{
			Widget widget = o as Widget;
			
			if (surface != null)
				surface.Dispose ();

			var allocation = widget.Allocation;

			surface = widget.Window.CreateSimilarSurface (Cairo.Content.Color, allocation.Width, allocation.Height);
			var cr = new Cairo.Context (surface);
			
			cr.SetSourceRGB (1, 1, 1);
			cr.Paint ();
			((IDisposable)cr).Dispose ();

			// We've handled the configure event, no need for further processing.
			args.RetVal = true;
		}

        private void FrameMotionNotify (object o, MotionNotifyEventArgs args)
		{

			// paranoia check, in case we haven't gotten a configure event
			if (surface == null)
				return;

			// This call is very important; it requests the next motion event.
			// If you don't call Window.GetPointer() you'll only get a single
			// motion event. The reason is that we specified PointerMotionHintMask
			// in widget.Events. If we hadn't specified that, we could just use
			// args.Event.X, args.Event.Y as the pointer location. But we'd also
			// get deluged in events. By requesting the next event as we handle
			// the current one, we avoid getting a huge number of events faster
			// than we can cope.

			int x, y;
			Gdk.ModifierType state;
			args.Event.Window.GetPointer (out x, out y, out state);

			/*if ((state & Gdk.ModifierType.Button1Mask) != 0)
			    DrawBrush (o as Widget, x, y);*/

			// We've handled it, stop processing
			args.RetVal = true;
		}

    }
}
