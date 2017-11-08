using System;
using Gtk;
using System.Text.RegularExpressions;

namespace sample124
{
	class MainClass
	{

		private static void showMatch(string text) {
			//MatchCollection keycheck;
			//MatchCollection keycheck1;
			MatchCollection mc = Regex.Matches(text, @"BTW\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
				return;
			}

			mc = Regex.Matches(text, @"SUM\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"PRODUKT\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"QUOSHUNT\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"DIFF\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"BIGGR\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"SMALLR\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"BOTH\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"EITHER\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"WON\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"ANY\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"ALL\b\sOF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"BOTH\b\sSAEM\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}
			//Console.WriteLine (text);
			mc = Regex.Matches(text, @"""?[A-Za-z](_*\d*[A-Za-z]*)*""?");

			int i = 0;
			string word;
			bool keyword = false;
			string word2;
			foreach (Match m in mc){
				word = "";
				word2 = "";
				//Console.WriteLine(m);


				word = word + mc[i];
				string line; 
				System.IO.StreamReader file =   
					new System.IO.StreamReader(@"keywords.txt");  
				while ((line = file.ReadLine ()) != null) { 
					if(line.Equals(word, StringComparison.Ordinal)){
						keyword = true;
						break;
					}
					//Console.WriteLine ("word is " +  word + " line is " + line + " value is " + line.Equals(word, StringComparison.Ordinal));
				}
				file.DiscardBufferedData();
				file.BaseStream.Seek(0, System.IO.SeekOrigin.Begin); 

				if (i <= mc.Count -2) {
					word = word + mc [i + 1];
				}

				while ((line = file.ReadLine ()) != null) { 
					if(line.Equals(word, StringComparison.Ordinal)){
						keyword = true;
						break;
					}
				}

				file.DiscardBufferedData();
				file.BaseStream.Seek(0, System.IO.SeekOrigin.Begin); 

				if (i <= mc.Count -3) {
					word = word + mc [i + 2];
				}

				while ((line = file.ReadLine ()) != null) { 
					if(line.Equals(word, StringComparison.Ordinal)){
						keyword = true;
						break;
					}
				}

				word2 = word2 + mc[i];
				if (!keyword) {
					if (word2.StartsWith("\"") && word2.EndsWith("\"")) {
						Console.WriteLine (m + "  STRING");
					} 
					else {
						Console.WriteLine (m + "  IDENTIFIER");
					}
				}
				i++;
				//Console.WriteLine ("word is " +  word);

				keyword = false;

			}

			mc = Regex.Matches(text, @"GIMMEH\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"DIFFRINT\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"SMOOSH\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"MAEK\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"A\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"VISIBLE\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"O\b\sRLY?\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"YA\b\sRLY\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"MEBBE\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"NO\b\sWAI\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"OIC\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"WTF?\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"OMG\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"OMG\b\sWTF\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"IM\b\sIN\b\sYR\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"I\b\sHAS\b\sA\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"IS\b\sNOW\b\sA\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"UPPIN\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"NERFIN\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"YR\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"TIL\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"WILE\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"IM\b\sOUTTA\b\sYR\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"AN\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}

			mc = Regex.Matches(text, @"\b[^\.\d+]-?\d+$\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  INTEGER");
			}

			mc = Regex.Matches(text, @"-?\d*\.\d+");
			foreach (Match m in mc){
				Console.WriteLine(m + "  FLOAT");
			}

			mc = Regex.Matches(text, @"\b(WIN|FAIL)\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  BOOLEAN");
			}

			mc = Regex.Matches(text, @"\b(TROOF|NUMBAR|YARN|BUKKIT|NOOB)\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  DATA TYPE");
			}
				

			mc = Regex.Matches(text, @"ITZ\b");
			foreach (Match m in mc){
				Console.WriteLine(m + "  KEYWORD");
			}
				
		}





		public static void Main (string[] args)
		{
			//Application.Init ();
			//MainWindow win = new MainWindow ();
			//win.Show ();
			//Application.Run ();
			//Console.WriteLine ("helloworld");

			//string str = "SUM OF X an Y";

			//showMatch(str);
			string line; 
			System.IO.StreamReader file =   
			new System.IO.StreamReader(@"lolfile.lol");  
			int inside = 0;
			while((line = file.ReadLine()) != null)  
			{  
				//System.Console.WriteLine (line); 
				if(line.Equals("HAI", StringComparison.Ordinal)){
					inside = 1;
					
				}
				else if(line.Equals("KTHXBYE", StringComparison.Ordinal)){
					inside = 0;
				}


				if (!(line.Equals ("", StringComparison.Ordinal)) && inside == 1) {
					showMatch (line);
				}
			}  

			Console.WriteLine("KEYWORD");
			string name = Console.ReadLine();
			Console.WriteLine("Your name is: " + name);

			Console.ReadKey();
		}
	}
}
