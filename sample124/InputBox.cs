using System;
using Gtk;

namespace sample124
{
	public class InputBox
	{
		void ShowMessage (Window parent, string title, string message)
		{
			Dialog dialog = null;
			try {
				dialog = new Dialog (title, parent,
					DialogFlags.DestroyWithParent | DialogFlags.Modal,
					ResponseType.Ok);
				dialog.VBox.Add (new Label (message));
				dialog.ShowAll ();

				dialog.Run ();
			} finally {
				if (dialog != null)
					dialog.Destroy ();
			}	
		}
	}
}


