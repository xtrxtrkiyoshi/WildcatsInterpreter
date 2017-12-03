using System;
using Gtk;
using System.Text.RegularExpressions;

namespace sample124
{
	class MainClass
	{







		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();


			Console.ReadKey();
	
		}
	}
}
//else if(lexerword.StartsWith("\"")){
//	while (lexercurrentword < newline.Length) {
//		lexerword += newline [lexercurrentword];
//		if(newline[lexercurrentword].EndsWith("\"")){
//			break;
//		}
//	}