
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;
	
	private global::Gtk.Button runbutton;
	
	private global::Gtk.Button loadbutton;
	
	private global::Gtk.TextView fileinput;
	
	private global::Gtk.TextView textview4;
	
	private global::Gtk.Label label5;
	
	private global::Gtk.Label label4;
	
	private global::Gtk.Label label3;
	
	private global::Gtk.ScrolledWindow scrolledwindow1;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.TextView textview5;
	
	private global::Gtk.TextView textview6;
	
	private global::Gtk.Label label2;
	
	private global::Gtk.ScrolledWindow scrolledwindow3;
	
	private global::Gtk.HBox hbox3;
	
	private global::Gtk.TextView textview2;
	
	private global::Gtk.TextView textview1;
	
	private global::Gtk.Label label1;
	
	private global::Gtk.ScrolledWindow scrolledwindow2;
	
	private global::Gtk.HBox hbox2;
	
	private global::Gtk.TextView textview7;
	
	private global::Gtk.TextView textview8;
	
	private global::Gtk.TextView textview9;
	
	private global::Gtk.Label label6;
	
	private global::Gtk.FileChooserButton filechooserbutton1;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.WidthRequest = 1280;
		this.fixed1.HeightRequest = 720;
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.runbutton = new global::Gtk.Button ();
		this.runbutton.CanFocus = true;
		this.runbutton.Name = "runbutton";
		this.runbutton.UseUnderline = true;
		this.runbutton.Label = global::Mono.Unix.Catalog.GetString ("Run");
		this.fixed1.Add (this.runbutton);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.runbutton]));
		w1.X = 20;
		w1.Y = 17;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.loadbutton = new global::Gtk.Button ();
		this.loadbutton.CanFocus = true;
		this.loadbutton.Name = "loadbutton";
		this.loadbutton.UseUnderline = true;
		this.loadbutton.Label = global::Mono.Unix.Catalog.GetString ("Load");
		this.fixed1.Add (this.loadbutton);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.loadbutton]));
		w2.X = 62;
		w2.Y = 19;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.fileinput = new global::Gtk.TextView ();
		this.fileinput.WidthRequest = 100;
		this.fileinput.CanFocus = true;
		this.fileinput.Name = "fileinput";
		this.fixed1.Add (this.fileinput);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.fileinput]));
		w3.X = 122;
		w3.Y = 24;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.textview4 = new global::Gtk.TextView ();
		this.textview4.WidthRequest = 1200;
		this.textview4.HeightRequest = 300;
		this.textview4.CanFocus = true;
		this.textview4.Name = "textview4";
		this.fixed1.Add (this.textview4);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.textview4]));
		w4.X = 17;
		w4.Y = 394;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label5 = new global::Gtk.Label ();
		this.label5.Name = "label5";
		this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Value");
		this.fixed1.Add (this.label5);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label5]));
		w5.X = 1155;
		w5.Y = 105;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label4 = new global::Gtk.Label ();
		this.label4.Name = "label4";
		this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Datatype");
		this.fixed1.Add (this.label4);
		global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label4]));
		w6.X = 1011;
		w6.Y = 102;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Identifier");
		this.fixed1.Add (this.label3);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label3]));
		w7.X = 889;
		w7.Y = 102;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow1.WidthRequest = 400;
		this.scrolledwindow1.HeightRequest = 200;
		this.scrolledwindow1.CanFocus = true;
		this.scrolledwindow1.Name = "scrolledwindow1";
		this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow1.Gtk.Container+ContainerChild
		global::Gtk.Viewport w8 = new global::Gtk.Viewport ();
		w8.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child GtkViewport.Gtk.Container+ContainerChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.textview5 = new global::Gtk.TextView ();
		this.textview5.CanFocus = true;
		this.textview5.Name = "textview5";
		this.textview5.Editable = false;
		this.textview5.CursorVisible = false;
		this.hbox1.Add (this.textview5);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.textview5]));
		w9.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.textview6 = new global::Gtk.TextView ();
		this.textview6.CanFocus = true;
		this.textview6.Name = "textview6";
		this.textview6.Editable = false;
		this.textview6.CursorVisible = false;
		this.hbox1.Add (this.textview6);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.textview6]));
		w10.Position = 1;
		w8.Add (this.hbox1);
		this.scrolledwindow1.Add (w8);
		this.fixed1.Add (this.scrolledwindow1);
		global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.scrolledwindow1]));
		w13.X = 458;
		w13.Y = 135;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Lexemes");
		this.fixed1.Add (this.label2);
		global::Gtk.Fixed.FixedChild w14 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label2]));
		w14.X = 466;
		w14.Y = 107;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.scrolledwindow3 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow3.WidthRequest = 450;
		this.scrolledwindow3.HeightRequest = 200;
		this.scrolledwindow3.CanFocus = true;
		this.scrolledwindow3.Name = "scrolledwindow3";
		this.scrolledwindow3.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow3.Gtk.Container+ContainerChild
		global::Gtk.Viewport w15 = new global::Gtk.Viewport ();
		w15.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child GtkViewport2.Gtk.Container+ContainerChild
		this.hbox3 = new global::Gtk.HBox ();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.textview2 = new global::Gtk.TextView ();
		this.textview2.WidthRequest = 10;
		this.textview2.CanFocus = true;
		this.textview2.Name = "textview2";
		this.hbox3.Add (this.textview2);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.textview2]));
		w16.Position = 0;
		// Container child hbox3.Gtk.Box+BoxChild
		this.textview1 = new global::Gtk.TextView ();
		this.textview1.WidthRequest = 350;
		this.textview1.CanFocus = true;
		this.textview1.Name = "textview1";
		this.hbox3.Add (this.textview1);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.textview1]));
		w17.Position = 1;
		w15.Add (this.hbox3);
		this.scrolledwindow3.Add (w15);
		this.fixed1.Add (this.scrolledwindow3);
		global::Gtk.Fixed.FixedChild w20 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.scrolledwindow3]));
		w20.X = 4;
		w20.Y = 136;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Source Code");
		this.label1.UseMarkup = true;
		this.fixed1.Add (this.label1);
		global::Gtk.Fixed.FixedChild w21 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label1]));
		w21.X = 27;
		w21.Y = 106;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.scrolledwindow2 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow2.WidthRequest = 400;
		this.scrolledwindow2.HeightRequest = 200;
		this.scrolledwindow2.CanFocus = true;
		this.scrolledwindow2.Name = "scrolledwindow2";
		this.scrolledwindow2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow2.Gtk.Container+ContainerChild
		global::Gtk.Viewport w22 = new global::Gtk.Viewport ();
		w22.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child GtkViewport1.Gtk.Container+ContainerChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.textview7 = new global::Gtk.TextView ();
		this.textview7.CanFocus = true;
		this.textview7.Name = "textview7";
		this.textview7.Editable = false;
		this.textview7.CursorVisible = false;
		this.hbox2.Add (this.textview7);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.textview7]));
		w23.Position = 0;
		// Container child hbox2.Gtk.Box+BoxChild
		this.textview8 = new global::Gtk.TextView ();
		this.textview8.CanFocus = true;
		this.textview8.Name = "textview8";
		this.textview8.Editable = false;
		this.textview8.CursorVisible = false;
		this.hbox2.Add (this.textview8);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.textview8]));
		w24.Position = 1;
		// Container child hbox2.Gtk.Box+BoxChild
		this.textview9 = new global::Gtk.TextView ();
		this.textview9.CanFocus = true;
		this.textview9.Name = "textview9";
		this.textview9.Editable = false;
		this.textview9.CursorVisible = false;
		this.hbox2.Add (this.textview9);
		global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.textview9]));
		w25.Position = 2;
		w22.Add (this.hbox2);
		this.scrolledwindow2.Add (w22);
		this.fixed1.Add (this.scrolledwindow2);
		global::Gtk.Fixed.FixedChild w28 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.scrolledwindow2]));
		w28.X = 868;
		w28.Y = 133;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label6 = new global::Gtk.Label ();
		this.label6.Name = "label6";
		this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Output");
		this.fixed1.Add (this.label6);
		global::Gtk.Fixed.FixedChild w29 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label6]));
		w29.X = 33;
		w29.Y = 369;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.filechooserbutton1 = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("Select a File"), ((global::Gtk.FileChooserAction)(0)));
		this.filechooserbutton1.WidthRequest = 100;
		this.filechooserbutton1.Name = "filechooserbutton1";
		this.fixed1.Add (this.filechooserbutton1);
		global::Gtk.Fixed.FixedChild w30 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.filechooserbutton1]));
		w30.X = 236;
		w30.Y = 20;
		this.Add (this.fixed1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1280;
		this.DefaultHeight = 720;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.runbutton.Clicked += new global::System.EventHandler (this.OnRunbuttonClicked);
		this.loadbutton.Clicked += new global::System.EventHandler (this.OnLoadbuttonClicked);
	}
}