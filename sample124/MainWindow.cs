using System;
using Gtk;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using sample124;
//using Microsoft.VisualBasic;

public partial class MainWindow: Gtk.Window
{
	static ArrayList tokens;
	static ArrayList symboltable;
	//--- FROM THIS LINE
	static ArrayList pseudo = new ArrayList();
	static IT it = new IT(); //tempting gawing IT pennywise buuuut
	//--- TO THIS LINE
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		int count = 1;
		while(count != 1000){
			textview2.Buffer.Text += count + "\n" ;
			count++;
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	//protected void OnTextview1PasteClipboard (object sender, EventArgs e)
	//{

	//}
	protected void OnLoadbuttonClicked (object sender, EventArgs e) // load file in and save to the executable file which will use to popupalte the textview1
	{
		string input = fileinput.Buffer.Text;
		string line2;
		textview1.Buffer.Text = "";
		try{
			System.IO.StreamReader file2 =
				new System.IO.StreamReader(input);
			while ((line2 = file2.ReadLine ()) != null) {
				textview1.Buffer.Text += line2 + "\n" ;
			}
		}
		catch{
			Console.WriteLine ("File not Found!");
		}

		StreamWriter sw = new StreamWriter ("executable.lol");
		sw.Write (textview1.Buffer.Text);
		sw.Close ();
	}

	protected void OnRunbuttonClicked (object sender, EventArgs e)
	{

		StreamWriter aw = new StreamWriter ("executable.lol"); // save the current content of the textview1 to the executable.lol  file to prepare for execution
		aw.Write (textview1.Buffer.Text);
		aw.Close ();

		tokens = new ArrayList ();



		string line;
		textview7.Buffer.Text = "";
		textview8.Buffer.Text = "";
		textview9.Buffer.Text = "";
		textview5.Buffer.Text = "";
		textview4.Buffer.Text = "";
		textview6.Buffer.Text = "";

		System.IO.StreamReader file =  new System.IO.StreamReader(@"executable.lol");
		int inside = 0;
		string errorchecker;
		int linenum = 1;
		int comment = 0;
		int syntaxerror = 0;
		string[] newline;
		string lexerword = "";
		int lexercurrentword= 0;
		int lexererror = 0;
		int oicneeded = 0;
		int insideorly = 0;
		//--- FROM THIS LINE
		int insidewtf = 0;
		int mustyarly = 0;
		int stringerror = 0;
		symboltable = new ArrayList();
		int symboltablesize = 0;
		Boolean run = true;
		Boolean omgdone = false;
		Boolean omgfound = false;
		Boolean omgline = false;
		Boolean alreadyomgwtf = false;
		string omgerror = "";
		string condition = "";
		string nowai = "";
		//--- TO THIS LINE
		Regex rgx = new Regex(@"^(SUM|DIFF|PRODUKT|QUSHUNT|BIGGR|SMALLR|BOTH|EITHER|WON|ANY|ALL|O|YA|NO|MOD)$");
		Regex rgx2 = new Regex(@"^(I|IM|IS)$");
		Regex rgx3 = new Regex(@"^(BTW)$");



		while((line = file.ReadLine()) != null)
		{

			//IF ELSE statement
			if (insideorly > 0) {
				MatchCollection mc = Regex.Matches (line, @"YA RLY");
				foreach (Match m in mc) {
					if (it.getValue ()) { run = true; } //condition is true
					else { run = false; } //condition is false
				}

				mc = Regex.Matches (line, @"NO WAI");
				foreach (Match m in mc) {
					nowai = "NO WAI";
					if (it.getValue () ) { run = false; } //IT is true so else statment does not run
					else { run = true; } //IT is false so else statment runs
				}

				mc = Regex.Matches (line, @"OIC");
				foreach (Match m in mc) {
					run = true; //resets run
				}
			}

			//SWITCH CASE statement
			if(insidewtf > 0) {
				MatchCollection mc = Regex.Matches (line, @"OMG");
				foreach (Match m in mc) {
					omgmatch (line, ref omgfound); //checks if match
					if (alreadyomgwtf == false) {
						if (omgfound == true && omgdone == false) { 
							run = true;  //condition is true
						} else { run = false; } //condition is false
					} else { //found an OMG after an OMGWTF
						omgerror = "error";
					}
					omgline = true;
				}
				mc = Regex.Matches (line, @"OMGWTF");
				foreach (Match m in mc) {
					if (omgfound == false) {  
						run = true; 
					} //answer not found so run default
					alreadyomgwtf = true;
					omgline = true; //line has to go through syntax checker
				}
				mc = Regex.Matches (line, @"GTFO");
				foreach (Match m in mc) {
					if (omgfound == true) {
						omgdone = true; //breaks the switch block
					}
					run = false; //breaks the run
				}
				mc = Regex.Matches (line, @"OIC");
				foreach (Match m in mc) {
					alreadyomgwtf = false;
					omgdone = false;
					run = true; //end of switch
				}
			}


			if(run == true || mustyarly == 1 || nowai != "" || omgline == true) {
				nowai = "";
				omgline = false;
				string[] templine = line.Split (default(string[]), StringSplitOptions.RemoveEmptyEntries); //UPDATE include ALL IN THE BLOCK
				if(templine.Length > 0 && inside == 0){ // If hai keyword is detected set inside to 1 which means that the following is now part of the program
					if(templine[0].Equals("HAI", StringComparison.Ordinal)){
						if (templine.Length > 1) {
							if (!(templine [1].Equals ("BTW", StringComparison.Ordinal))) {
								textview4.Buffer.Text += ("Syntax Error Detected at Line " + linenum + "\n");
								break;
							} else {
								textview5.Buffer.Text += "HAI\n";
								textview6.Buffer.Text += "CODE START\n";
								tokens.Add (new Token("HAI", "CODE START"));
								textview5.Buffer.Text += "BTW\n";
								textview6.Buffer.Text += "SINGLLE LINE COMMENT KEYWORD\n";
								tokens.Add (new Token ("BTW", "SINGLE LINE COMMENT KEYWORD"));
							}
						} 
						else {
							textview5.Buffer.Text += "HAI\n";
							textview6.Buffer.Text += "CODE START\n";
							tokens.Add (new Token("HAI", "CODE START"));
						}
						inside = 1;
						linenum++;
						continue;
					}


				}
				else if(templine.Length > 0 && inside == 1){ // if kthxbye is detected then sets inside to 0 which means that the analysis of the code should stop except fot BTW
					if(templine[0].Equals("KTHXBYE", StringComparison.Ordinal)){ //UPATE ALL IN THE BLOCK
						if (templine.Length > 1) {
							if (!(templine [1].Equals ("BTW", StringComparison.Ordinal))) {
								textview4.Buffer.Text += ("Syntax Error Detected at Line " + linenum + "\n");
								break;
							} else {
								textview5.Buffer.Text += "KTHXBYE\n";
								textview6.Buffer.Text += "CODE END\n";
								tokens.Add (new Token("KTHXBYE", "CODE END"));
								textview5.Buffer.Text += "BTW\n";
								textview6.Buffer.Text += "SINGLLE LINE COMMENT KEYWORD\n";
								tokens.Add (new Token ("BTW", "SINGLE LINE COMMENT KEYWORD"));
							}
						} 
						else {
							textview5.Buffer.Text += "KTHXBYE\n";
							textview6.Buffer.Text += "CODE END\n";
							tokens.Add (new Token("KTHXBYE", "CODE END"));
						}
						inside = 0;
						continue;
					}

				}


				MatchCollection mc = Regex.Matches(line, @"BTW\b");
				foreach (Match m in mc){
					if (inside == 0) {
						comment = 1;
					}

				}
				if(comment == 1){
					textview5.Buffer.Text += "BTW\n";
					textview6.Buffer.Text += "SINGLLE LINE COMMENT KEYWORD\n";
					tokens.Add (new Token("BTW", "SINGLE LINE COMMENT KEYWORD"));
				}
				else if(line.Length > 0 && inside == 0){
					textview4.Buffer.Text += "Exception Detected Expecting HAI\n";
					syntaxerror = 1;
					break;
				}

				if (!(line.Equals ("", StringComparison.Ordinal)) && inside == 1 && comment == 0) { // lexer and the parser is inside this block of code
					newline = line.Split (default(string[]), StringSplitOptions.RemoveEmptyEntries);//slices the line from the file
					lexercurrentword = 0;



					while(lexercurrentword < newline.Length){ //  this while loop prepares each lexerword to be pass to the lexical analyzer
						lexerword = "";
						lexerword += newline [lexercurrentword];

						if (rgx.IsMatch (lexerword)) {
							lexercurrentword++;
							try {
								lexerword += " " + newline [lexercurrentword]; // prepare the two words keyword
							} catch {
								Console.WriteLine ("End of newline");
							}
						} else if (rgx2.IsMatch (lexerword) && lexerword.Length <= 2) { // prepare the three words keyword
							lexercurrentword++;
							try {
								lexerword += " " + newline [lexercurrentword];
								lexercurrentword++;
								lexerword += " " + newline [lexercurrentword];
							} catch {
							}
						}
						else if(lexerword.StartsWith ("\"") && lexerword.EndsWith ("\"")){
							mc = Regex.Matches(lexerword, @"""");
							int checkquote = 0;
							foreach (Match m in mc){
								checkquote++;

							}
							if(checkquote > 2){
								stringerror = 1;
							}
						}

						else if (lexerword.StartsWith ("\"")) { // prepare multiple word strings
							lexercurrentword++;
							while (lexercurrentword < newline.Length) {
								lexerword += " " + newline [lexercurrentword];
								if(newline[lexercurrentword].StartsWith ("\"")){
									stringerror = 1;
									break;
								}
								else if (newline [lexercurrentword].EndsWith ("\"")) {
									break;
								}
								lexercurrentword++;
							}
						}
						if(stringerror == 0){
							errorchecker = showMatch (lexerword, textview7, textview5, textview6, ref symboltablesize);  // this is the call for the lexer
						}
						else{
							lexererror = 1;
							textview4.Buffer.Text += ("Error Detected at Line " + linenum + "\n");
							break;
						}
						if (errorchecker.Length != 0) {
							textview4.Buffer.Text += ("Error Detected at Line " + linenum + "\n");
							lexererror = 1;
							break;
						}
						if (rgx3.IsMatch (lexerword)) {
							break;
						}

						lexercurrentword++;
					}

					syntaxerror = syntaxchecker(line, ref oicneeded, ref insideorly, ref insidewtf, ref  mustyarly, ref symboltablesize, ref run, ref condition); // this the call for the syntax analyzer

				}
				if (lexererror == 1) {
					break;
				}
				if(syntaxerror == 1 || omgerror != ""){
					Console.WriteLine (syntaxerror);
					Console.WriteLine (omgerror);
					textview4.Buffer.Text += ("Syntax Error Detected at Line " + linenum + "\n");
					break;
				}
				comment = 0;
				syntaxerror = 0;
				linenum++;

			}

			//sets IT for Boolean and Comparison
			if(condition != "") {
				BooleanComparison(condition);
				condition = ""; //resets condition
			}

		}
		if (oicneeded == 1) {
			textview4.Buffer.Text += "Exception Detected Expecting OIC\n";
		}
		else if (mustyarly == 1) {
			textview4.Buffer.Text += "Exception Detected Expecting YA RLY\n";
		}
		else if (inside == 1 && syntaxerror == 0 && lexererror == 0) {
			textview4.Buffer.Text += "Exception Detected Expecting KTHXBYE\n";
		}
		else if(syntaxerror == 0 && lexererror == 0) {
			if (InitializeSymbolTable ()) {
				TypeChecker (textview4);
				AssignmentExecution ();
				IOExecution ();
//				Execute ();
				RenderSymbolTable();
			}
		}
		file.Close ();
	}
		
	public void Execute() {
		// @TODO: merge AssignmentExecution and IOExecution under this function
		for(int i = 0; i < tokens.Count; i++) {
			Token currentToken = (Token)tokens [i];

			// if token is arithmetic AND not part of other statements
			if (Matcher.IsArithmeticOperation (currentToken.getLexeme ())) {
				// @TODO: handle floats
				int result = NumExecution(i - 1);
				Console.WriteLine (result);

				symboltable.Add (new Symbol ("IT", result.ToString (), "NUMBR" )); //, nextToken.getType(), "1"

			}

			// put all other statements here!
		}
	}

	public void updateSymbol(string identifier, string type, string value) {
		foreach(Symbol symbol in symboltable) {
			if (symbol.GetIdentifier () == identifier) {
				symbol.SetType (type);
				symbol.SetValue (value);

				return;
			}
		}
	}
// GET ALL FROM HERE ========================================================================================================================================================================

	public Boolean InitializeSymbolTable() {
		float flt;
		int num;
		string stringVal = "";
		Regex numbar = new Regex(@"^-?\d*\.\d+$");
		for (int i = 0; i < tokens.Count; i++) {
			Token token = (Token)tokens [i];
			// search for all declarations
			if (token.getType () == "VARIABLE DECLARATION KEYWORD") {
				Token nextToken = (Token)tokens [i + 1];

				// check if identifier already exists on symbol table
				foreach (Symbol symbol in symboltable) {
					if (nextToken.getLexeme () == symbol.GetIdentifier ()) {
						textview4.Buffer.Text += ("Variable " + nextToken.getLexeme () + " already declared")  + "\n";
						return false;
					}
				}

				Token itzToken = (Token)tokens [i + 2];

				string dataType= "";

				//ITZ SUM OF 1 AN 1
				//  2   3    4  5  6
				// ITZ SUM OF "1" AN "1"
				// 2    3     456  7 8910
				if (itzToken.getType () == "ITZ KEYWORD") {
					Token afterItzToken = (Token)tokens [i + 3];

					if (afterItzToken.getType () == "INTEGER LITERAL") {
						dataType = "NUMBR";
						stringVal = afterItzToken.getLexeme ();
					} else if (afterItzToken.getType () == "STRING DELIMITER") {
						dataType = "YARN";
						Token yarnToken = (Token)tokens [i + 4];
						stringVal = yarnToken.getLexeme ();
					} else if (afterItzToken.getType () == "BOOLEAN LITERAL") {
						stringVal = afterItzToken.getLexeme ();
						dataType = "TROOF";
					} else if (afterItzToken.getType () == "DECIMAL LITERAL") {
						stringVal = afterItzToken.getLexeme ();
						dataType = "NUMBAR";
					} else { //else like arithmetic operation
						Token firstToken = (Token)tokens [i + 4];
						Token secondToken = (Token)tokens [i + 6];

						if (firstToken.getType () == "DECIMAL LITERAL" || secondToken.getType () == "DECIMAL LITERAL") {
							dataType = "NUMBAR";
							flt = FloatExecution(i + 2);
							stringVal = Convert.ToString(flt);
						} else if(firstToken.getType() == "STRING DELIMITER" || secondToken.getType() == "STRING DELIMITER"){
							Token firstYarnToken = (Token)tokens [i+5];
							Token secondYarnToken = (Token)tokens [i+9];
							Console.WriteLine (secondYarnToken.getLexeme());
							Console.WriteLine (firstYarnToken.getLexeme());
							if (numbar.IsMatch (secondYarnToken.getLexeme ()) == true || numbar.IsMatch (firstYarnToken.getLexeme ()) == true) {
								dataType = "NUMBAR";
								flt = FloatExecution (i + 2);
								stringVal = Convert.ToString (flt);
							} else {
								dataType = "NUMBR";
								num = NumExecution (i + 2);
								stringVal = Convert.ToString (num);
							}

						}else{
							for (int j = 0; j < symboltable.Count; j++) {
								Symbol symbol = (Symbol)symboltable [j];
								if(symbol.GetIdentifier() == firstToken.getLexeme()){
									Console.WriteLine (symbol.GetType ());
									if (symbol.GetType () == "NUMBAR") {
										dataType = "NUMBAR";
										flt = FloatExecution (i + 2);
										stringVal = Convert.ToString (flt);
									} else if (symbol.GetType () == "NUMBR") {
										if (secondToken.getType () == "IDENTIFIER") {
											for (int k = 0; k < symboltable.Count; k++) {
												Symbol symbol2 = (Symbol)symboltable [k];
												if (symbol2.GetIdentifier () == secondToken.getLexeme ()) {
													Console.WriteLine (symbol2.GetType ());
													if (symbol2.GetType () == "NUMBAR") {
														dataType = "NUMBAR";
														flt = FloatExecution (i + 2);
														stringVal = Convert.ToString (flt);
													} else if(symbol2.GetType () == "NUMBR"){
														dataType = "NUMBR";
														num = NumExecution (i + 2);
														stringVal = Convert.ToString (num);
													}else{
														if (numbar.IsMatch (symbol2.GetValue() ) == true) {
															dataType = "NUMBAR";
															flt = FloatExecution (i + 2);
															stringVal = Convert.ToString (flt);
														}else{
															dataType = "NUMBR";
															num = NumExecution (i + 2);
															stringVal = Convert.ToString (num);
														}
													}
												}
											}
										} else if (secondToken.getType () == "DECIMAL LITERAL") {
											dataType = "NUMBAR";
											flt = FloatExecution (i + 2);
											stringVal = Convert.ToString (flt);
										} else if (secondToken.getType () == "STRING DELIMITER") {
											Token secondYarnToken = (Token)tokens [i + 7];
											if (numbar.IsMatch (secondYarnToken.getLexeme ()) == true) {
												dataType = "NUMBAR";
												flt = FloatExecution (i + 2);
												stringVal = Convert.ToString (flt);
											} else {
												dataType = "NUMBR";
												num = NumExecution (i + 2);
												stringVal = Convert.ToString (num);
											}
										} else {
											dataType = "NUMBR";
											num = NumExecution (i + 2);
											stringVal = Convert.ToString (num);
										}
									} else { // IT A FUCKING YARN JEEZ
										if (numbar.IsMatch (symbol.GetValue() ) == true) {
											dataType = "NUMBAR";
											flt = FloatExecution (i + 2);
											stringVal = Convert.ToString (flt);
										} else {
											Console.WriteLine (secondToken.getType ());
											if (secondToken.getType () == "IDENTIFIER") {
												for (int k = 0; k < symboltable.Count; k++) {
													Symbol symbol2 = (Symbol)symboltable [k];
													if (symbol2.GetIdentifier () == secondToken.getLexeme ()) {
														Console.WriteLine ("YO " +symbol2.GetType ());
														if (symbol2.GetType () == "NUMBAR") {
															dataType = "NUMBAR";
															flt = FloatExecution (i + 2);
															stringVal = Convert.ToString (flt);
														} else if(symbol2.GetType () == "NUMBR") {
															dataType = "NUMBR";
															num = NumExecution (i + 2);
															stringVal = Convert.ToString (num);
														}else{
															if (numbar.IsMatch (symbol2.GetValue() ) == true) {
																dataType = "NUMBAR";
																flt = FloatExecution (i + 2);
																stringVal = Convert.ToString (flt);
															}else{
																dataType = "NUMBR";
																num = NumExecution (i + 2);
																stringVal = Convert.ToString (num);
															}
														}
													}
												}
											} else if (secondToken.getType () == "DECIMAL LITERAL") {
												dataType = "NUMBAR";
												flt = FloatExecution (i + 2);
												stringVal = Convert.ToString (flt);
											} else if (secondToken.getType () == "STRING DELIMITER") {
												Token secondYarnToken = (Token)tokens [i + 7];
												if (numbar.IsMatch (secondYarnToken.getLexeme ()) == true) {
													dataType = "NUMBAR";
													flt = FloatExecution (i + 2);
													stringVal = Convert.ToString (flt);
												} else {
													dataType = "NUMBR";
													num = NumExecution (i + 2);
													stringVal = Convert.ToString (num);
												}
											} else {
												dataType = "NUMBR";
												num = NumExecution (i + 2);
												stringVal = Convert.ToString (num);
											}
										}

									}
								}
							}
						}
					}
					symboltable.Add (new Symbol (nextToken.getLexeme (), stringVal, dataType));
				} else {
					dataType = "NOOB";
					symboltable.Add (new Symbol (nextToken.getLexeme (), dataType)); //, nextToken.getType(), "1"
				}
			}
		}
		return true;
	}

	public void RenderSymbolTable() {
		textview7.Buffer.Text = "";
		textview8.Buffer.Text = "";
		textview9.Buffer.Text = "";

		foreach(Symbol symbol in symboltable) {
			textview7.Buffer.Text += (symbol.GetIdentifier() + "\n");
			textview8.Buffer.Text += (symbol.GetType() + "\n");
			textview9.Buffer.Text += (symbol.GetValue()) + "\n";
		}
	}
	public void AssignmentExecution(){
		string stringVal = "";
		float flt;
		int num;
		Regex numbar = new Regex(@"^-?\d*\.\d+$");
		for (int i = 0; i < tokens.Count; i++) {
			Token token = (Token)tokens [i];

			// noot R SUM OF 1 AN 1
			// -1   i  1     2  3 4
			//noot R SUM OF "1" AN "1"
			// -1  i  1     234  5 678
			if (token.getType () == "ASSIGNMENT OPERATOR") {
				string dataType = "";
				Token nextToken = (Token)tokens [i + 1];
				Token prevToken = (Token)tokens [i - 1];

				if (nextToken.getType () == "DECIMAL LITERAL") {
					dataType = "NUMBAR";
					stringVal = nextToken.getLexeme ();
				}else if (nextToken.getType () == "INTEGER LITERAL") {
					dataType = "NUMBR";
					stringVal = nextToken.getLexeme ();
				}else if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnToken = (Token)tokens [i + 2];
					stringVal = yarnToken.getLexeme ();
					dataType = "YARN";
				}else if (nextToken.getType () == "BOOLEAN LITERAL") {
					dataType = "TROOF";
					stringVal = nextToken.getLexeme ();
				}else { //if arithmetic operation
					Token firstToken = (Token)tokens [i + 2];
					Token secondToken = (Token)tokens [i + 4];

					if (firstToken.getType () == "DECIMAL LITERAL" || secondToken.getType () == "DECIMAL LITERAL") {
						dataType = "NUMBAR";
						flt = FloatExecution(i);
						stringVal = Convert.ToString(flt);
					} else if(firstToken.getType() == "STRING DELIMITER" || secondToken.getType() == "STRING DELIMITER"){
						Token firstYarnToken = (Token)tokens [i+3];
						Token secondYarnToken = (Token)tokens [i+7];
						if (numbar.IsMatch(secondYarnToken.getLexeme()) == true || numbar.IsMatch(firstYarnToken.getLexeme ()) == true) {
							dataType = "NUMBAR";
							flt = FloatExecution (i);
							stringVal = Convert.ToString (flt);
						}else {
							dataType = "NUMBR";
							num = NumExecution (i);
							stringVal = Convert.ToString (num);
						}


					}else{
						for (int j = 0; j < symboltable.Count; j++) {
							Symbol symbol = (Symbol)symboltable [j];
							if(symbol.GetIdentifier() == firstToken.getLexeme()){
								if (symbol.GetType () == "NUMBAR") {
									dataType = "NUMBAR";
									flt = FloatExecution (i );
									stringVal = Convert.ToString (flt);
								} else if (symbol.GetType () == "NUMBR") {
									if (secondToken.getType () == "IDENTIFIER") {
										for (int k = 0; k < symboltable.Count; k++) {
											Symbol symbol2 = (Symbol)symboltable [k];
											if (symbol.GetIdentifier () == firstToken.getLexeme ()) {
												if (symbol2.GetType () == "NUMBAR") {
													dataType = "NUMBAR";
													flt = FloatExecution (i);
													stringVal = Convert.ToString (flt);
												} else if(symbol2.GetType () == "NUMBR"){
													dataType = "NUMBR";
													num = NumExecution (i);
													stringVal = Convert.ToString (num);
												}else{
													if (numbar.IsMatch (symbol2.GetValue() ) == true) {
														dataType = "NUMBAR";
														flt = FloatExecution (i);
														stringVal = Convert.ToString (flt);
													}else{
														dataType = "NUMBR";
														num = NumExecution (i);
														stringVal = Convert.ToString (num);
													}
												}
											}
										}
									} else if (secondToken.getType () == "DECIMAL LITERAL") {
										dataType = "NUMBAR";
										flt = FloatExecution (i);
										stringVal = Convert.ToString (flt);
									} else if (secondToken.getType () == "STRING DELIMITER") {
										Token secondYarnToken = (Token)tokens [i + 7];
										if (numbar.IsMatch (secondYarnToken.getLexeme ()) == true) {
											dataType = "NUMBAR";
											flt = FloatExecution (i);
											stringVal = Convert.ToString (flt);
										} else {
											dataType = "NUMBR";
											num = NumExecution (i);
											stringVal = Convert.ToString (num);
										}
									} else {
										dataType = "NUMBR";
										num = NumExecution (i);
										stringVal = Convert.ToString (num);
									}
								} else { // IT A FUCKING YARN JEEZ
									if (numbar.IsMatch (symbol.GetValue() ) == true) {
										dataType = "NUMBAR";
										flt = FloatExecution (i);
										stringVal = Convert.ToString (flt);
									} else {
										Console.WriteLine (secondToken.getType ());
										if (secondToken.getType () == "IDENTIFIER") {
											for (int k = 0; k < symboltable.Count; k++) {
												Symbol symbol2 = (Symbol)symboltable [k];
												if (symbol2.GetIdentifier () == secondToken.getLexeme ()) {
													Console.WriteLine ("YO " +symbol2.GetType ());
													if (symbol2.GetType () == "NUMBAR") {
														dataType = "NUMBAR";
														flt = FloatExecution (i);
														stringVal = Convert.ToString (flt);
													} else if(symbol2.GetType () == "NUMBR") {
														dataType = "NUMBR";
														num = NumExecution (i);
														stringVal = Convert.ToString (num);
													}else{
														if (numbar.IsMatch (symbol2.GetValue() ) == true) {
															dataType = "NUMBAR";
															flt = FloatExecution (i);
															stringVal = Convert.ToString (flt);
														}else{
															dataType = "NUMBR";
															num = NumExecution (i);
															stringVal = Convert.ToString (num);
														}
													}
												}
											}
										} else if (secondToken.getType () == "DECIMAL LITERAL") {
											dataType = "NUMBAR";
											flt = FloatExecution (i);
											stringVal = Convert.ToString (flt);
										} else if (secondToken.getType () == "STRING DELIMITER") {
											Token secondYarnToken = (Token)tokens [i + 7];
											if (numbar.IsMatch (secondYarnToken.getLexeme ()) == true) {
												dataType = "NUMBAR";
												flt = FloatExecution (i);
												stringVal = Convert.ToString (flt);
											} else {
												dataType = "NUMBR";
												num = NumExecution (i);
												stringVal = Convert.ToString (num);
											}
										} else {
											dataType = "NUMBR";
											num = NumExecution (i);
											stringVal = Convert.ToString (num);
										}
									}
								}
							}
						}
					}
				}
				for (int j = 0; j < symboltable.Count; j++) {
					Symbol symbol = (Symbol)symboltable [j];
					if(symbol.GetIdentifier() == prevToken.getLexeme()){
						symbol.SetType(dataType);
						symbol.SetValue(stringVal);
					}
				}
			}
		}
	}
	public void IOExecution(){
		float flt;
		int num = 0;
		string stringVal;
		Regex numbr = new Regex(@"^-?\d+$");
		Regex numbar = new Regex(@"^-?\d*\.\d+$");
		Regex yarn = new Regex(@"""?[A-Za-z](_*\d*[A-Za-z]*)*""?");
		Regex troof = new Regex(@"^(WIN|FAIL)$");
		for (int i = 0; i < tokens.Count; i++) {
			Token token = (Token)tokens [i];
			if (token.getType () == "SYSTEM OUTPUT KEYWORD") { // VISIBLE meep / VISIBLE "hoi"
				Token nextToken = (Token)tokens [i + 1];

				if (nextToken.getType () == "STRING DELIMITER") { // if finds a delimiter " gets the next token (which is the yarn)
					Token yarnToken = (Token)tokens [i + 2];
					stringVal = yarnToken.getLexeme ();
					textview4.Buffer.Text += (stringVal + "\n");
				} else if (nextToken.getType () == "INTEGER LITERAL" || nextToken.getType () == "DECIMAL LITERAL" || nextToken.getType () == "BOOLEAN LITERAL") { //if finds a literal just gets the lexeme
					stringVal = nextToken.getLexeme ();
					textview4.Buffer.Text += (stringVal + "\n");
				} else if (nextToken.getType () == "IDENTIFIER") { //else it's an idetifier so i find it in symbol table and gets its value
					for (int j = 0; j < symboltable.Count; j++) {
						Symbol symbol = (Symbol)symboltable [j];
						if (symbol.GetIdentifier () == nextToken.getLexeme ()) {
							stringVal = symbol.GetValue ();
							textview4.Buffer.Text += (stringVal + "\n");
						}
					}
				} else { //VISIBLE SUM OF 1 AN 1 / VISIBLE SUM OF "1" AN "1"
							//  i   1     2 3  4//      i   1    2 3 4 5 6 7 8
					Token firstToken = (Token)tokens [i+2];
					Token secondToken = (Token)tokens [i+4];
					if (firstToken.getType () == "DECIMAL LITERAL" || secondToken.getType () == "DECIMAL LITERAL") {
						flt = FloatExecution(i);
						stringVal = Convert.ToString(flt);
						textview4.Buffer.Text += (flt + "\n");
					} else if(firstToken.getType() == "STRING DELIMITER" || secondToken.getType() == "STRING DELIMITER"){
						Token firstYarnToken = (Token)tokens [i+3];
						Token secondYarnToken = (Token)tokens [i+7];

						if (numbar.IsMatch(secondYarnToken.getLexeme()) == true || numbar.IsMatch(firstYarnToken.getLexeme ()) == true) {
							flt = FloatExecution (i);
							stringVal = Convert.ToString (flt);
							textview4.Buffer.Text += (flt + "\n");
						}else {
							num = NumExecution (i);
							stringVal = Convert.ToString (num);
							textview4.Buffer.Text += (num + "\n");
						}
					}else{
						for (int j = 0; j < symboltable.Count; j++) {
							Symbol symbol = (Symbol)symboltable [j];
							if(symbol.GetIdentifier() == firstToken.getLexeme()){
								if (symbol.GetType () == "NUMBAR") {
									flt = FloatExecution (i + 2);
									stringVal = Convert.ToString (flt);
									textview4.Buffer.Text += (flt + "\n");
								} else if (symbol.GetType () == "NUMBR") {
									if (secondToken.getType () == "IDENTIFIER") {
										for (int k = 0; k < symboltable.Count; k++) {
											Symbol symbol2 = (Symbol)symboltable [k];
											if (symbol.GetIdentifier () == firstToken.getLexeme ()) {
												if (symbol2.GetType () == "NUMBAR") {
													flt = FloatExecution (i + 2);
													stringVal = Convert.ToString (flt);
													textview4.Buffer.Text += (flt + "\n");
												} else if(symbol2.GetType () == "NUMBR"){
													num = NumExecution (i + 2);
													stringVal = Convert.ToString (num);
													textview4.Buffer.Text += (num + "\n");
												}else{
													if (numbar.IsMatch (symbol2.GetValue() ) == true) {
														flt = FloatExecution (i + 2);
														stringVal = Convert.ToString (flt);
														textview4.Buffer.Text += (flt + "\n");
													}else{
														num = NumExecution (i + 2);
														stringVal = Convert.ToString (num);
														textview4.Buffer.Text += (num + "\n");
													}
												}
											}
										}
									} else if (secondToken.getType () == "DECIMAL LITERAL") {
										flt = FloatExecution (i + 2);
										stringVal = Convert.ToString (flt);
										textview4.Buffer.Text += (flt + "\n");
									} else if (secondToken.getType () == "STRING DELIMITER") {
										Token secondYarnToken = (Token)tokens [i + 7];
										if (numbar.IsMatch (secondYarnToken.getLexeme ()) == true) {
											flt = FloatExecution (i + 2);
											stringVal = Convert.ToString (flt);
											textview4.Buffer.Text += (flt + "\n");
										} else {
											num = NumExecution (i + 2);
											stringVal = Convert.ToString (num);
											textview4.Buffer.Text += (num + "\n");
										}
									} else {
										num = NumExecution (i + 2);
										stringVal = Convert.ToString (num);
										textview4.Buffer.Text += (num + "\n");
									}
								} else { // IT A FUCKING YARN JEEZ
									if (numbar.IsMatch (symbol.GetValue() ) == true) {
										flt = FloatExecution (i + 2);
										stringVal = Convert.ToString (flt);
										textview4.Buffer.Text += (stringVal + "\n");
									} else {
										Console.WriteLine (secondToken.getType ());
										if (secondToken.getType () == "IDENTIFIER") {
											for (int k = 0; k < symboltable.Count; k++) {
												Symbol symbol2 = (Symbol)symboltable [k];
												if (symbol2.GetIdentifier () == secondToken.getLexeme ()) {
													Console.WriteLine ("YO " +symbol2.GetType ());
													if (symbol2.GetType () == "NUMBAR") {

														flt = FloatExecution (i + 2);
														stringVal = Convert.ToString (flt);
														textview4.Buffer.Text += (stringVal + "\n");
													} else if(symbol2.GetType () == "NUMBR") {
														num = NumExecution (i + 2);
														stringVal = Convert.ToString (num);
														textview4.Buffer.Text += (stringVal + "\n");
													}else{
														if (numbar.IsMatch (symbol2.GetValue() ) == true) {

															flt = FloatExecution (i + 2);
															stringVal = Convert.ToString (flt);
															textview4.Buffer.Text += (stringVal + "\n");
														}else{
															num = NumExecution (i + 2);
															stringVal = Convert.ToString (num);
															textview4.Buffer.Text += (stringVal + "\n");
														}
													}
												}
											}
										} else if (secondToken.getType () == "DECIMAL LITERAL") {
											flt = FloatExecution (i + 2);
											stringVal = Convert.ToString (flt);
											textview4.Buffer.Text += (stringVal + "\n");
										} else if (secondToken.getType () == "STRING DELIMITER") {
											Token secondYarnToken = (Token)tokens [i + 7];
											if (numbar.IsMatch (secondYarnToken.getLexeme ()) == true) {
												flt = FloatExecution (i + 2);
												stringVal = Convert.ToString (flt);
												textview4.Buffer.Text += (stringVal + "\n");
											} else {
												num = NumExecution (i + 2);
												stringVal = Convert.ToString (num);
												textview4.Buffer.Text += (stringVal + "\n");
											}
										} else {
											num = NumExecution (i + 2);
											stringVal = Convert.ToString (num);
											textview4.Buffer.Text += (stringVal + "\n");
										}
									}

								}
							}
						}
					}
				}
			}else if (token.getType () == "SYSTEM INPUT KEYWORD") { // GIMMEH meep / GIMMEH
				Token nextToken = (Token)tokens [i + 1];

				//Console.WriteLine ("enter here: "); //terminal pa lang
				//stringVal = Interaction.InputBox("ENTER INPUT","GIMMEH","");
				stringVal ="";
				//stringVal=Console.ReadLine ();
				for (int j = 0; j < symboltable.Count; j++) {
					Symbol symbol = (Symbol)symboltable [j];
					if(symbol.GetIdentifier() == nextToken.getLexeme()){ //gets the next token which is the identifier and finds in symbol

						if(numbr.IsMatch(stringVal) == true){ //number checko regex
							symbol.SetValue (stringVal);
							symbol.SetType ("NUMBR");
						}else if(numbar.IsMatch(stringVal) == true){ //decimal checko regex
							symbol.SetValue (stringVal);
							symbol.SetType ("NUMBAR");
						}else if(troof.IsMatch(stringVal) == true){ //boolean
							symbol.SetValue (stringVal);
							symbol.SetType ("TROOF");
						}else{
							symbol.SetValue (stringVal);
							symbol.SetType ("YARN");
						}
					}
				}
			}
		}
	}

	public int NumExecution(int index){
		int i = index;
		int answer=0;
		string add = "ADDITION OPERATOR";
		string sub = "SUBTRACTION OPERATOR";
		string mul = "MULTIPLICATION OPERATOR";
		string div = "DIVISION OPERATOR";
		string mod = "MODULO OPERATOR";

		for (i = index+ 1; i < tokens.Count; i++) { //check all tokens
			Token token = (Token)tokens [i];
			Token nextToken = (Token)tokens [i + 1];
			Token secondToken = (Token)tokens [i + 3];
			if (token.getType () == add) {
				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token)tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = NumPatternOfOperations (yarnNextToken, yarnSecondToken, add);
					} else {
						answer = NumPatternOfOperations (yarnNextToken, delimiterSecond, add);
					}
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, add);
					} else {
						answer = NumPatternOfOperations (nextToken, secondToken, add);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, add);
					}else{
						answer = NumPatternOfOperations (nextToken, secondToken, add);
					}
				}
				break;
			} else if (token.getType () == sub) {
				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = NumPatternOfOperations (yarnNextToken, yarnSecondToken, sub);
					} else {
						answer = NumPatternOfOperations (yarnNextToken, delimiterSecond, sub);
					}
				}else if (nextToken.getType () == "INTEGER LITERAL" && secondToken.getType() == "INTEGER LITERAL") {
					answer = NumPatternOfOperations (nextToken, secondToken, sub);
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, sub);
					} else {
						answer = NumPatternOfOperations (nextToken, secondToken, sub);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, sub);
					}else{
						answer = NumPatternOfOperations (nextToken, secondToken, sub);
					}
				}
				break;
			} else if (token.getType () == mul) {
				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = NumPatternOfOperations (yarnNextToken, yarnSecondToken, mul);
					} else {
						answer = NumPatternOfOperations (yarnNextToken, delimiterSecond, mul);
					}
				}else if (nextToken.getType () == "INTEGER LITERAL" && secondToken.getType() == "INTEGER LITERAL") {
					answer = NumPatternOfOperations (nextToken, secondToken, mul);
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, mul);
					} else {
						answer = NumPatternOfOperations (nextToken, secondToken, mul);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, mul);
					}else{
						answer = NumPatternOfOperations (nextToken, secondToken, mul);
					}
				}
				break;
			} else if (token.getType () == div) {
				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = NumPatternOfOperations (yarnNextToken, yarnSecondToken, div);
					} else {
						answer = NumPatternOfOperations (yarnNextToken, delimiterSecond, div);
					}
				}else if (nextToken.getType () == "INTEGER LITERAL" && secondToken.getType() == "INTEGER LITERAL") {
					answer = NumPatternOfOperations (nextToken, secondToken, div);
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, div);
					} else {
						answer = NumPatternOfOperations (nextToken, secondToken, div);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, div);
					}else{
						answer = NumPatternOfOperations (nextToken, secondToken, div);
					}
				}
				break;

			} else if (token.getType () == mod) {
				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = NumPatternOfOperations (yarnNextToken, yarnSecondToken, mod);
					} else {
						answer = NumPatternOfOperations (yarnNextToken, delimiterSecond, mod);
					}
				}else if (nextToken.getType () == "INTEGER LITERAL" && secondToken.getType() == "INTEGER LITERAL") {
					answer = NumPatternOfOperations (nextToken, secondToken, mod);
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, mod);
					} else {
						answer = NumPatternOfOperations (nextToken, secondToken, mod);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = NumPatternOfOperations (nextToken, yarnSecondToken, mod);
					}else{
						answer = NumPatternOfOperations (nextToken, secondToken, mod);
					}
				}

				break;
			}

		}
		return answer;
	}
	public int NumPatternOfOperations(Token first, Token second, string operation){ //checks the pattern of the operation
		int num1=0;
		int num2=0;
		int answer = 0;


		Console.WriteLine ("NUM PATTERN" + first.getLexeme());
		Console.WriteLine ("NUM PATTERN" + second.getLexeme());
		if (first.getType() == "IDENTIFIER") { // SUM OF var

			for (int j = 0; j < symboltable.Count; j++) { //finds var in symbol table
				Symbol symbol = (Symbol)symboltable [j];

				if (symbol.GetIdentifier () == first.getLexeme ()) {
					num1 = Int32.Parse(symbol.GetValue ()); //num 1 = var.getValue
					if (second.getType () == "IDENTIFIER") { //SUM OF var AN avar
						for (int k = 0; k < symboltable.Count; k++) { //finds avar
							Symbol symbol2 = (Symbol)symboltable [k];
							if(symbol2.GetIdentifier() == second.getLexeme()){
								try{
									num2 = Int32.Parse(symbol2.GetValue ()); //num 1 = var.getValue
									answer=NumOperationExecution (num1, num2, operation);
								}catch{
									Console.WriteLine ("error in function pattern of operations!");
									break;
								}
							}
						}
					} else { // SUM of var an 1
						try{
							num2 = Int32.Parse (second.getLexeme ());
							answer=NumOperationExecution (num1, num2, operation);
						}catch{
							Console.WriteLine ("error in function pattern of operations!");
						}
					}
				}
			}
		}else{
			try{
				num1 = Int32.Parse (first.getLexeme ());
			}
			catch{
			}
			if (second.getType () == "IDENTIFIER") { //SUM OF 1 AN avar

				for (int k = 0; k < symboltable.Count; k++) { //finds avar
					Symbol symbol2 = (Symbol)symboltable [k];

					if(symbol2.GetIdentifier() == second.getLexeme()){

						try{
							num2 = Int32.Parse(symbol2.GetValue ()); //num 1 = var.getValue
							answer=NumOperationExecution (num1, num2, operation);
						}catch{
							Console.WriteLine ("error in function pattern of operations!");

						}
					}
				}
			} else { // SUM of 1 an 1
				try{
					num2 = Int32.Parse (second.getLexeme ());
					answer=NumOperationExecution (num1, num2, operation);
				}
				catch{
					Console.WriteLine ("error in function pattern of operations!");
				}
			}
		}
		return answer;
	}
	public int NumOperationExecution(int num1, int num2, string operation){
		int answer=0;
		string add = "ADDITION OPERATOR";
		string sub = "SUBTRACTION OPERATOR";
		string mul = "MULTIPLICATION OPERATOR";
		string div = "DIVISION OPERATOR";
		string mod = "MODULO OPERATOR";
		if (operation == add) {
			answer = num1 + num2;
		} else if (operation == sub) {
			answer = num1 - num2;
		} else if (operation == mul) {
			answer = num1 * num2;
		} else if (operation == div) {
			answer = num1 / num2;
		} else if (operation == mod) {
			answer = num1 % num2;
		}
		return answer;
	}

	public float FloatExecution(int index){
		int i = index;
		float answer=0;
		string add = "ADDITION OPERATOR";
		string sub = "SUBTRACTION OPERATOR";
		string mul = "MULTIPLICATION OPERATOR";
		string div = "DIVISION OPERATOR";
		string mod = "MODULO OPERATOR"; //ITZ SUM OF "1" AN "1"

		Console.WriteLine ("ONE OF ME IS A DAMN FLOAT");
		for (i = index + 1; i < tokens.Count; i++) { //check all tokens
			Token token = (Token)tokens [i];
			Token nextToken = (Token)tokens [i + 1];
			Token secondToken = (Token)tokens [i + 3];

			Console.WriteLine ("INSIDE FLOAT EXECUTION " + token.getType());
			if (token.getType () == add) {
				if (nextToken.getType () == "STRING DELIMITER") { //
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = FloatPatternOfOperations (yarnNextToken, yarnSecondToken, add);
					} else {
						answer = FloatPatternOfOperations (yarnNextToken, delimiterSecond, add);
					}
				}else if (nextToken.getType () == "DECIMAL LITERAL" || secondToken.getType() == "DECIMAL LITERAL") {
					answer = FloatPatternOfOperations (nextToken, secondToken, add);
				}else if (nextToken.getType () == "IDENTIFIER") {//SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, add);
					} else {
						Console.WriteLine ("I KNOW IM AN IDENTIFIER");
						answer = FloatPatternOfOperations (nextToken, secondToken, add);
					}
				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, add);
					}else{ // P AN V
						answer = FloatPatternOfOperations (nextToken, secondToken, add);
					}

				}
				break;
			} else if (token.getType () == sub) {

				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = FloatPatternOfOperations (yarnNextToken, yarnSecondToken, sub);
					} else {
						answer = FloatPatternOfOperations (yarnNextToken, delimiterSecond, sub);
					}
				}else if (nextToken.getType () == "DECIMAL LITERAL" || secondToken.getType() == "DECIMAL LITERAL") {
					answer = FloatPatternOfOperations (nextToken, secondToken, sub);
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, sub);
					} else {
						answer = FloatPatternOfOperations (nextToken, secondToken, sub);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, sub);
					}else{
						answer = FloatPatternOfOperations (nextToken, secondToken, sub);
					}
				}

				break;
			} else if (token.getType () == mul) {
				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = FloatPatternOfOperations (yarnNextToken, yarnSecondToken, mul);
					} else {
						answer = FloatPatternOfOperations (yarnNextToken, delimiterSecond, mul);
					}
				}else if (nextToken.getType () == "DECIMAL LITERAL" || secondToken.getType() == "DECIMAL LITERAL") {
					answer = FloatPatternOfOperations (nextToken, secondToken, mul);
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, mul);
					} else {
						answer = FloatPatternOfOperations (nextToken, secondToken, mul);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, mul);
					}else{
						answer = FloatPatternOfOperations (nextToken, secondToken, mul);
					}
				}
				break;
			} else if (token.getType () == div) {
				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = FloatPatternOfOperations (yarnNextToken, yarnSecondToken, div);
					} else {
						answer = FloatPatternOfOperations (yarnNextToken, delimiterSecond, div);
					}
				}else if (nextToken.getType () == "DECIMAL LITERAL" || secondToken.getType() == "DECIMAL LITERAL") {
					answer = FloatPatternOfOperations (nextToken, secondToken, div);
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, div);
					} else {
						answer = FloatPatternOfOperations (nextToken, secondToken, div);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, div);
					}else{
						answer = FloatPatternOfOperations (nextToken, secondToken, div);
					}
				}

				break;
			} else if (token.getType () == mod) {
				if (nextToken.getType () == "STRING DELIMITER") {
					Token yarnNextToken = (Token)tokens [i + 2];
					Token delimiterSecond = (Token) tokens [i + 5];
					if (delimiterSecond.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 6];
						answer = FloatPatternOfOperations (yarnNextToken, yarnSecondToken, mod);
					} else {
						answer = FloatPatternOfOperations (yarnNextToken, delimiterSecond, mod);
					}
				}else if (nextToken.getType () == "DECIMAL LITERAL" || secondToken.getType() == "DECIMAL LITERAL") {
					answer = FloatPatternOfOperations (nextToken, secondToken, mod);
				}else if (nextToken.getType () == "IDENTIFIER") { //SUM OF
					if (secondToken.getType () == "STRING DELIMITER") {
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, mod);
					} else {
						answer = FloatPatternOfOperations (nextToken, secondToken, mod);
					}

				}else{
					if(secondToken.getType() == "STRING DELIMITER"){
						Token yarnSecondToken = (Token)tokens [i + 4];
						answer = FloatPatternOfOperations (nextToken, yarnSecondToken, mod);
					}else{
						answer = FloatPatternOfOperations (nextToken, secondToken, mod);
					}
				}

				break;
			}
		}
		return answer;
	}
	public float FloatPatternOfOperations(Token first, Token second, string operation){ //checks the pattern of the operation
		float num1=0;
		float num2=0;
		float float1=0;
		float float2=0;
		float answer = 0;
		if (first.getType() == "IDENTIFIER") { // SUM OF VAR
			for (int j = 0; j < symboltable.Count; j++) {
				Symbol symbol = (Symbol)symboltable [j];
				if (symbol.GetIdentifier () == first.getLexeme ()) {
					if(symbol.GetType() == "NUMBR"){ //WHAT IF STRING
						try{ // 1 AN 1.3
							num1 = Single.Parse(symbol.GetValue ());
							float2 = Single.Parse (second.getLexeme ());
							answer=FloatOperationExecution (num1, float2, operation);
						}catch{
							Console.WriteLine ("error in function pattern of operations!");
						}
					}else{
						try{
							float1 = Single.Parse(symbol.GetValue ());
						}catch{
							Console.WriteLine ("error in function pattern of operations!");
						}

						if(second.getType() == "INTEGER LITERAL"){ //SUM OF FLT AN 1
							try{
								num2 = Single.Parse (second.getLexeme ());
								answer=FloatOperationExecution ( float1, num2, operation);
							}catch{
								Console.WriteLine ("error in function pattern of operations!");
							}
						}else if(second.getType() == "IDENTIFIER"){ //SUM OF FLT AN 1.5
							for (int k = 0; k < symboltable.Count; k++) {
								Symbol symbol2 = (Symbol)symboltable [k];
								if (symbol2.GetIdentifier () == first.getLexeme ()) {
									try{
										float1 = Single.Parse(symbol2.GetValue ());
									}catch{
										Console.WriteLine ("error in function pattern of operations!");
									}
								}
							}
						}else{
							try{
								float2 = Single.Parse (second.getLexeme ());
								answer=FloatOperationExecution (float1, float2, operation);
							}catch{
								Console.WriteLine ("error in function pattern of operations!");
							}
						}
					}
				}
			}
		}else{ //SUM OF 1
			if(first.getType() == "INTEGER LITERAL"){
				try{
					num1 = Single.Parse (first.getLexeme ());
				}catch{
					Console.WriteLine ("error in function pattern of operations!");
				}
				if(second.getType() == "IDENTIFIER"){ //SUM OF 1 AN FLT
					for (int k = 0; k< symboltable.Count; k++) {
						Symbol symbol2 = (Symbol)symboltable [k];
						if(symbol2.GetIdentifier() == second.getLexeme()){
							try{
								float2 = Single.Parse (second.getLexeme ());
								answer=FloatOperationExecution (num1, float2, operation);
							}catch{
								Console.WriteLine ("error in function pattern of operations!");
							}
						}
					}
				}else{ //SUM OF 1 AN 1.5
					Console.WriteLine("IN PATTERN CHECKO BEFORE PARSE "+ first.getLexeme() + " AND " + second.getLexeme());
					try{
						float2 = Single.Parse (second.getLexeme ());
						Console.WriteLine("IN PATTERN CHECKO "+ num1 + " AND " + float2);
						answer=FloatOperationExecution (num1, float2, operation);
					}catch{
						Console.WriteLine ("error in function pattern of operations!");
					}
				}
			}else{
				try{
					float1 = Single.Parse (first.getLexeme ());
				}catch{
					Console.WriteLine ("error in function pattern of operations!");
				}
				if (second.getType() == "INTEGER LITERAL"){// SUM OF 1.5 AN 1
					try{
						num2 = Single.Parse (second.getLexeme ());
						answer=FloatOperationExecution (float1, num2, operation);
					}catch{
						Console.WriteLine ("error in function pattern of operations!");
					}
				}else if(second.getType() == "IDENTIFIER"){ //SUM OF 1.5 AN VAR
					for (int k = 0; k< symboltable.Count; k++) {
						Symbol symbol2 = (Symbol)symboltable [k];
						if(symbol2.GetIdentifier() == second.getLexeme()){
							try{
								float1 = Single.Parse (second.getLexeme ());
								answer=FloatOperationExecution (float1, float2, operation);
							}catch{
								Console.WriteLine ("error in function pattern of operations!");
							}
						}
					}
				}else{ //SUM OF 1.5 AN 1.5
					try{
						float2 = Single.Parse (second.getLexeme ());
						answer=FloatOperationExecution (float1, float2, operation);
					}catch{
						Console.WriteLine ("error in function pattern of operations!");
					}
				}
			}
		}
		return answer;
	}
	public float FloatOperationExecution(float num1, float num2, string operation){
		float answer=0;
		string add = "ADDITION OPERATOR";
		string sub = "SUBTRACTION OPERATOR";
		string mul = "MULTIPLICATION OPERATOR";
		string div = "DIVISION OPERATOR";
		string mod = "MODULO OPERATOR";
		if (operation == add) {
			answer = num1 + num2;
			Console.WriteLine("IN OPERATION "+ num1 + " + " + num2 + " EQUALS" + answer);
			return answer;
		} else if (operation == sub) {
			answer = num1 - num2;
		} else if (operation == mul) {
			answer = num1 * num2;
		} else if (operation == div) {
			answer = num1 / num2;
		} else if (operation == mod) {
			answer = num1 % num2;
		}
		return answer;
	}
// HERE ========================================================================================================================================================================================

	public int syntaxchecker(string text, ref int oicneeded, ref int insideorly, ref int insidewtf, ref int mustyarly, ref int symboltablesize, ref Boolean run, ref string condition){
		//--- TO THIS LINE
		int currentword = -1;
		string[] words;
		words = text.Split (default(string[]), StringSplitOptions.RemoveEmptyEntries);
		string word = "";
		Regex rgx;
		Regex rgx2;
		Regex rgx3;
		Regex rgx4;
		Regex rgx5;
		Regex rgx6;
		Regex rgx7;
		Regex rgx8;
		Regex rgx9;
		Regex rgx10;
		Regex rgx11;
		Regex rgx12;
		Regex rgx13;
		Regex rgx14;
		Regex rgx15;
		Regex rgx16;
		//--- THIS LINE
		Regex rgx17;
		//--- TO THIS LINE
		int next = 0; //  0=end  1=sum,diff..etc 2=identifier
		int commandwait = 0;
		int anreq = 0;
		int smooshprintonly=0;
		int compareon = 0;
		int needval = 0;
		int varexception = 0;
		int itzuse = 0;
		int datatypeneeded = 0;
		string toupdate = "";
		int update = 0;
		int directval = 0;
		int elements = 0;
		int infinite = 0;
		string tempstring = "";


		while(true){
			rgx = new Regex(@"^(SUM|DIFF|PRODUKT|QUOSHUNT|BIGGR|SMALLR|BOTH|EITHER|WON|ANY|ALL|SAEM|DIFFRINT|MOD)$");
			rgx2 = new Regex(@"""?[A-Za-z](_*\d*[A-Za-z]*)*""?");
			rgx3 = new Regex(@"^(AN)$");
			rgx4 = new Regex(@"^(I|IM|IS)$");
			rgx5 = new Regex(@"^(VISIBLE|OIC|SMOOSH)$");
			rgx6 = new Regex(@"^(GIMMEH|UPPIN|NERFIN|NOT)$");
			rgx7 = new Regex(@"^(O|YA|NO)$");
			rgx8 = new Regex(@"^(ITZ)$");
			rgx9 = new Regex(@"^(UPPIN|NERFIN)$");
			rgx10 = new Regex(@"^-?\d+$");
			rgx11 = new Regex(@"^-?\d*\.\d+$");
			rgx12 = new Regex(@"^(WIN|FAIL)$");
			rgx13 = new Regex(@"^(IS|R)$");
			rgx14 = new Regex(@"^(NUMBR|NUMBAR|TROOF|YARN|NOOB)$");
			rgx15 = new Regex(@"^(R)$");
			rgx16 = new Regex(@"^(BTW)$");
			//--- THIS LINE
			rgx17 = new Regex(@"^(WTF\?|OMG|OMGWTF|GTFO)$");
			//--- TO THIS LINE
			currentword++;

			if( currentword >= words.Length){
				break;
			}
			word = "";
			word += words [currentword];
			//Console.WriteLine ("Start If " + word); ERIKA
			if(word.StartsWith("\"") && word.EndsWith("\"")){
				if(currentword == 0){
					return 1;
				}
				else if(commandwait > 0){
					needval = 0;
					commandwait--;
					directval--;
					anreq = 1;
					if(commandwait == 0){
						anreq = 0;
					}
					continue;
				}
				else if(needval == 1){
					needval = 0;

					continue;
				}
				else if(itzuse == 1 && needval == 0){
					return 1;
				}
				else{
					if(compareon == 1){
						commandwait--;
					}
					else if(commandwait > 0 && anreq == 0){
						commandwait--;
						directval--;
						if(words.Length  == currentword + 1 && directval > 0){
							return 1;
						}
						else if(words.Length  > currentword + 1  && directval == 0 && varexception == 0){
							if(rgx16.IsMatch(words[currentword + 1])){
								break;
							}
							return 1;
						}
						else if(directval + 1 >= 2){
							anreq = 1;
							continue;
						}
					}
					continue;
				}
			}

			else if(rgx16.IsMatch(word)){
				break;
			}

			else if(rgx.IsMatch(word)){
				//--- THIS LINE
				if (text.Contains ("VISIBLE ")) { //removes VISIBLE
					int i = text.IndexOf("VISIBLE ") + 8;
					condition = text.Substring (i);
				} else {
					condition = text;
				}
				//--- TO THIS LINE
				if(words [currentword].Equals ("DIFFRINT", StringComparison.Ordinal)){
					compareon = 1;
					commandwait = 2;
					directval = 2;
					next = 2;
					continue;
				}
				currentword++;
				if(words.Length == currentword){
					return 1;
				}

				else if((words [currentword-1].Equals ("ANY", StringComparison.Ordinal) || words [currentword-1].Equals ("ALL", StringComparison.Ordinal)) && words [currentword].Equals ("OF", StringComparison.Ordinal) ){
					if(infinite == 1){
						return 1;
					}
					infinite = 1;
					continue;
				}

				else if (words [currentword].Equals ("SAEM", StringComparison.Ordinal)) {
					compareon = 1;
					commandwait = 2;
					directval = 2;
					next = 2;
					continue;
				}
				else {
					next = 2;
					if (commandwait > 0) {
						commandwait++;
						directval++;
						needval = 0;

					} else {
						commandwait = 2;
						directval = 2;
						needval = 0;
					}
					continue;
				}
			}

			else if(rgx7.IsMatch(word) && word.Length <= 2){
				currentword++;
				if(words.Length == currentword){
					return 1;
				}
				else if (words [currentword].Equals ("RLY?", StringComparison.Ordinal)) {
					oicneeded = 1;
					insideorly = 1;
					mustyarly = 1;
					currentword++;
					if(words.Length > currentword){
						return 1;
					}
					return 0;
				}
				else if (words [currentword].Equals ("RLY", StringComparison.Ordinal)) {
					mustyarly = 0;
					currentword++;
					if(words.Length > currentword){
						return 1;
					}
					continue;
				}
				else if (words [currentword].Equals ("WAI", StringComparison.Ordinal)) {
					currentword++;
					if(words.Length > currentword){
						return 1;
					}
					continue;
				}
			}
			//--- THIS LINE
			else  if(rgx17.IsMatch(word) && words.Length <= 2) {
				//WTF? OMG ____ OMG ____ OMGWTF OIC
				if (words [currentword].Equals ("OMG", StringComparison.Ordinal) && words.Length < 2) {return 1;}

				if (words [currentword].Equals ("WTF?", StringComparison.Ordinal) && words.Length != 1) {return 1;}

				if (words [currentword].Equals ("OMGWTF", StringComparison.Ordinal) && words.Length != 1) {return 1;}

				if (words [currentword].Equals ("GTFO", StringComparison.Ordinal) && words.Length != 1) {return 1;}

				if (insidewtf == 0) {
					if (words [currentword].Equals ("WTF?", StringComparison.Ordinal)) {
						insidewtf = 1;
						return 0;
					} 
					else {return 1;}
				}
				return 0;
			}
			//--- TOO THIS LINE
			else if(rgx3.IsMatch(word) && anreq == 1){
				anreq = 0;
				if(words.Length == currentword + 1){
					return 1;
				}
			}

			else if(infinite == 1 && anreq == 0){
				anreq = 1;
			}

			else if (rgx4.IsMatch(word) && word.Length <= 2) {
				currentword++;
				string first = word;
				try {
					word += " " + words [currentword];
					currentword++;
					word += " " + words [currentword];
					if(first.Equals ("I", StringComparison.Ordinal)){
						commandwait = 1;
						next = 2;
						varexception = 1;
					}
					else if(first.Equals ("IS", StringComparison.Ordinal)){
						datatypeneeded = 1;
						toupdate = words [0];
						update = 1;
					}
				} catch {
					//Console.WriteLine ("End of newline"); ERIKA
				}
				//Console.WriteLine ("Continue"); ERIKA
				continue;
			}

			else if (rgx8.IsMatch(word) && word.Length == 3) {
				if (currentword == 0) {
					return 1;
				}
				needval = 1;
				itzuse = 1;
				update = 1;
				toupdate = words[currentword - 1];
				continue;
			}

			else if (rgx10.IsMatch(word) && needval == 1) {
				needval = 0;
				elements = 0;
				if (update == 1) {
					while(elements < symboltablesize){
						tempstring = "";
						tempstring += symboltable [elements];
						if(toupdate.Equals(tempstring, StringComparison.Ordinal)){

							break;
						}
					}
				}
				continue;
			}

			else if (rgx11.IsMatch(word) && needval == 1) {
				needval = 0;
				elements = 0;
				if (update == 1) {
					while(elements < symboltablesize){
						tempstring = "";
						tempstring += symboltable [elements];
						if(toupdate.Equals(tempstring, StringComparison.Ordinal)){
							break;
						}
					}
				}
				continue;
			}

			else if (rgx12.IsMatch(word) && needval == 1) {
				needval = 0;
				elements = 0;
				if (update == 1) {
					while(elements < symboltablesize){
						tempstring = "";
						tempstring += symboltable [elements];
						if(toupdate.Equals(tempstring, StringComparison.Ordinal)){
							//LINES 496 AND 497
							// symboltable [elements + 2] = "TROOF";
							// symboltable [elements + 1] = word;
							break;
						}
						// elements += 3;
					}
				}
				continue;
			}

			else if (rgx9.IsMatch(word)) {
				commandwait = 1;
				next = 2;
				continue;
			}

			else if (rgx14.IsMatch(word) && datatypeneeded == 1) {
				elements = 0;
				if (update == 1) {
					while(elements < symboltablesize){
						tempstring = "";
						tempstring += symboltable [elements];
						if(toupdate.Equals(tempstring, StringComparison.Ordinal)){
							// symboltable [elements + 1] = word;
							break;
						}
						// elements += 3;
					}
				}
				continue;
			}

			else if (rgx15.IsMatch(word) && word.Length == 1) {
				needval = 1;
				toupdate = words [0];
				update = 1;
				continue;
			}


			else if(rgx5.IsMatch(word)){
				if(word.Equals ("VISIBLE", StringComparison.Ordinal) || word.Equals ("SMOOSH", StringComparison.Ordinal)){
					smooshprintonly = 1;
				}
				else if(word.Equals ("OIC", StringComparison.Ordinal)){
					//--- THIS LINE
					if(insideorly == 0 && insidewtf == 0){
						//--- TO THIS LINE
						return 1;
					}
					else if(mustyarly == 1){
						oicneeded = 0;
						return 1;
					}
					oicneeded = 0;
					insideorly = 0;
					currentword++;
					if(words.Length > currentword){
						return 1;
					}
				}
				continue;
			}
			//--- FROM THIS LINE
			else if(rgx6.IsMatch(word)){
				if (word.Equals ("NOT", StringComparison.Ordinal)) {
					if (text.Contains ("VISIBLE ")) { //removes VISIBLE
						int i = text.IndexOf("VISIBLE ") + 8;
						condition = text.Substring (i);
					} else {
						condition = text;
					}
				}
				commandwait = 1;
				next = 2;
				continue;
			}
			//--- TO THIS LINE
			else if (word.StartsWith ("\"")) {
				//Console.WriteLine ("String Prompt1");
				currentword++;
				while (currentword < words.Length) {
					word += " " + words [currentword];
					if (words [currentword].EndsWith ("\"")) {
						break;
					}
					currentword++;
				}
				if(currentword == words.Length){
					return 1;
				}
				else if(needval == 1){
					needval = 0;
					elements = 0;
					if (update == 1) {
						while(elements < symboltablesize){
							tempstring = "";
							tempstring += symboltable [elements];
							if(toupdate.Equals(tempstring, StringComparison.Ordinal)){
								// symboltable [elements + 2] = "YARN";
								// symboltable [elements + 1] = word;
								break;
							}
							// elements += 3;
						}
					}
					continue;
				}
				else if(itzuse == 1 && needval == 0){
					return 1;
				}
				else{
					if(compareon == 1){
						commandwait--;
					}
					continue;
				}
			}

			else if (word.StartsWith("\"") && word.EndsWith("\"")) {
				if(currentword == 0){
					return 1;
				}
				else{
					if(compareon == 1){
						commandwait--;
					}
					continue;
				}
			}

			else if(!(word.StartsWith("\"")) && !(word.EndsWith("\"")) && rgx2.IsMatch(word) && next==2 && anreq == 0 && commandwait > 0){
				commandwait--;
				directval--;
				//Console.WriteLine ("ENTERED HERE RGX2!");
				//Console.WriteLine(word);
				if(words.Length  == currentword + 1 && commandwait > 0){ //hanggat hindi 0 ung value ng command di pa kumpleto variabes na kailangan
					return 1;
				}
				else if(words.Length  > currentword + 1  && commandwait == 0 && varexception == 0){
					if(rgx16.IsMatch(words[currentword + 1])){
						Console.WriteLine ("here at checker!");
						break;
					}
					return 1;
				}
				else if(commandwait + 1 >= 2){
					anreq = 1;
					continue;
				}

			}

			else if(directval > 0 && next == 2 && anreq == 0){
				commandwait--;
				directval--;
				if(words.Length  == currentword + 1 && directval > 0){
					return 1;
				}
				else if(words.Length  > currentword + 1  && directval == 0 && varexception == 0){
					if(rgx16.IsMatch(words[currentword + 1])){
						break;
					}
					return 1;
				}
				else if(directval + 1 >= 2){
					anreq = 1;
					continue;
				}
			}


			else if(!(word.StartsWith("\"")) && !(word.EndsWith("\"")) && rgx2.IsMatch(word) && smooshprintonly == 1){
				//Console.WriteLine ("smooshprintonly");
				continue;

			}

			else if(rgx10.IsMatch(word) && smooshprintonly == 1){
				//Console.WriteLine ("smooshprintonly");
				continue;

			}

			else if(rgx11.IsMatch(word) && smooshprintonly == 1){
				//Console.WriteLine ("smooshprintonly");
				continue;

			}

			else if(rgx12.IsMatch(word) && smooshprintonly == 1){
				//Console.WriteLine ("smooshprintonly");
				continue;

			}

			else if(rgx2.IsMatch(word)){
				if(currentword+1 == words.Length){
					return 1;
				}
				if(rgx13.IsMatch(words[currentword + 1])){
					continue;
				}
			}

			else if(infinite == 1 && anreq == 1){
				return 1;
			}

			else{
				Console.WriteLine ("Final If " + word);
				return 1;
			}

		}
		if (commandwait > 0) {
			return 1;
		}
		else if(needval == 1){
			return 1;
		}
		else {
			return 0;
		}

	}


	public static string Replace(string Source, string Find, string Replace) // replace the the 1st occurence of the subtring found in a string
	{
		int Place = Source.IndexOf(Find);
		string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
		return result;
	}

	public static string showMatch(string text, TextView textview3,  TextView textview5, TextView textview6,  ref int symboltablesize) {
		//MatchCollection keycheck;
		//MatchCollection keycheck1;
		string repstring = "";

		MatchCollection mc = Regex.Matches(text, @"^(SUM OF)$");	// The folowing lines of code filters all valid lexemes
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "ADDITION OPERATOR\n";
			tokens.Add (new Token("SUM OF", "ADDITION OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(MOD OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "MODULO OPERATOR\n";
			tokens.Add (new Token("MOD OF", "MODULO OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(PRODUKT OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "MULTIPLICATION OPERATOR\n";
			tokens.Add (new Token("PRODUKT OF", "MULTIPLICATION OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(QUOSHUNT OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "DIVISION OPERATOR\n";
			tokens.Add (new Token("QUOSHUNT OF", "DIVISION OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(DIFF OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "SUBTRACTION OPERATOR\n";
			tokens.Add (new Token("DIFF OF", "SUBTRACTION OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(MOD OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "MODULO OPERATOR\n";
			tokens.Add (new Token("MOD OF", "MODULO OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(BIGGR OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "MAX OPERATOR\n";
			tokens.Add (new Token("BIGGR OF", "MAX OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(SMALLR OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "MIN OPERATOR\n";
			tokens.Add (new Token("SMALLR OF", "MIN OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(BOTH OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "AND OPERATOR\n";
			tokens.Add (new Token("BOTH OF", "AND OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(EITHER OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "OR OPERATOR\n";
			tokens.Add (new Token("EITHER OF", "OR OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(WON OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "XOR OPERATOR\n";
			tokens.Add (new Token("WON OF", "XOR OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(ANY OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "INIFINITE ARITY OR OPERATOR\n";
			tokens.Add (new Token("ANY OF", "INFITE ARITY OR OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(ALL OF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "INIFINITE ARITY AND OPERATOR\n";
			tokens.Add (new Token("ALL OF", "INFITE ARITY AND OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(BOTH SAEM)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "EQUAL OPERATOR\n";
			tokens.Add (new Token("BOTH SAEM", "EQUAL OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}
		//Console.WriteLine (text);


		mc = Regex.Matches(text, @"^(GIMMEH)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "SYSTEM INPUT  KEYWORD\n";
			tokens.Add (new Token("GIMMEH", "SYSTEM INPUT KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(NOT)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "NOT OPERATOR\n";
			tokens.Add (new Token("NOT", "NOT OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^R$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "ASSIGNMENT OPERATOR\n";
			tokens.Add (new Token("R", "ASSIGNMENT OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(DIFFRINT)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "NOT EQUAL OPERATOR\n";
			tokens.Add (new Token("DIFFRINT", "NOT EQUAL OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(SMOOSH)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "CONCATENATION OPERATOR\n";
			tokens.Add (new Token("SMOOSH", "CONCATENATION OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(MAEK)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "TYPECAST OPERATOR\n";
			tokens.Add (new Token("MAEK", "TYPECAST OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(VISIBLE)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "SYSTEM OUTPUT KEYWORD\n";
			tokens.Add (new Token("VISIBLE", "SYSTEM OUTPUT KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(O RLY\?)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "IF KEYWORD\n";
			tokens.Add (new Token("O RLY?", "IF KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(YA RLY)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "IF TRUE KEYWORD\n";
			tokens.Add (new Token("YA RLY", "IF TRUE KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(MEBBE)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "IF ELSE KEYWORD\n";
			tokens.Add (new Token("MEBBE", "IF ELSE KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(NO WAI)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "IF FALSE KEYWORD\n";
			tokens.Add (new Token("NO WAI", "IF FALSE KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(OIC)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "END CONDITION KEYWORD\n";
			tokens.Add (new Token("OIC", "END CONDITION KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(WTF\?)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "SWITCH START KEYWORD\n";
			tokens.Add (new Token("WTF?", "SWITCH START KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(OMG)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "SWITCH CASE KEYWORD\n";
			tokens.Add (new Token("OMG", "SWITCH CASE KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}


		mc = Regex.Matches(text, @"^(OMGWTF)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "SWITCH DEFAULT KEYWORD\n";
			tokens.Add (new Token("OMGWTF", "SWITCH DEFAULT KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(IM IN YR)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "ITERATION START KEYWORD\n";
			tokens.Add (new Token("IM IN YR", "ITERATION START KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}
		//variable declaration
		mc = Regex.Matches(text, @"^(I HAS A)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "VARIABLE DECLARATION KEYWORD\n";
			tokens.Add (new Token("I HAS A", "VARIABLE DECLARATION KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";


		}

		mc = Regex.Matches(text, @"^(IS NOW A)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "TYPECAST OPERATOR\n";
			tokens.Add (new Token("IS NOW A", "TYPECAST OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(UPPIN)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "INCREMENT OPERATOR\n";
			tokens.Add (new Token("UPPIN", "INCREMENT OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(NERFIN)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "DECREMENT OPERATOR\n";
			tokens.Add (new Token("NERFIN", "DECREMENT OPERATOR"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(TIL)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "ITERATION KEYWORD\n";
			tokens.Add (new Token("TIL", "ITERATION KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(WILE)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "ITERATION KEYWORD\n";
			tokens.Add (new Token("WILE", "ITERATION KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(IM OUTTA YR)$");
		foreach (Match m in mc){

			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "ITERATION END KEYWORD\n";
			tokens.Add (new Token("IM OUTTA YR", "ITERATION END KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(AN)$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  KEYWORD");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "AN KEYWORD\n";
			tokens.Add (new Token("AN", "AN KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}
		//@"[^\.\d+]-?\d+$"
		mc = Regex.Matches(text, @"^-?\d+$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  NUMBR");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "INTEGER LITERAL\n";
			tokens.Add (new Token(text, "INTEGER LITERAL"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^-?\d*\.\d+$");
		foreach (Match m in mc){
			//Console.WriteLine(m + "  NUMBAR");
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "DECIMAL LITERAL\n";
			tokens.Add (new Token(text, "DECIMAL LITERAL"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(WIN|FAIL)$");
		foreach (Match m in mc){
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "BOOLEAN LITERAL\n";
			tokens.Add (new Token(text, "BOOLEAN LITERAL"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(TROOF|NUMBAR|YARN|BUKKIT|NOOB|NUMBR)$");
		foreach (Match m in mc){
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "DATA TYPE LITERAL\n";
			tokens.Add (new Token(text, "DATA TYPE LITERAL"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}


		mc = Regex.Matches(text, @"^(ITZ)$");
		foreach (Match m in mc){
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "ITZ KEYWORD\n";
			tokens.Add (new Token("ITZ", "ITZ KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^""?[A-Za-z](_*\d*[A-Za-z]*)*""?$");

		int i = 0;
		string word;
		bool keyword = false;
		string word2;
		foreach (Match m in mc){
			word = "";
			word2 = "";


			word = word + mc[i];
			string line;
			System.IO.StreamReader file =
				new System.IO.StreamReader(@"keywords.txt");  // this check if the identifier detected is a keyword
			while ((line = file.ReadLine ()) != null) {
				if(line.Equals(word, StringComparison.Ordinal)){
					keyword = true;
					break;
				}
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
				if (word2.StartsWith ("\"") && word2.EndsWith ("\"")) {
					int numberofquotes = 0;
					MatchCollection quotes = Regex.Matches(text, @"""");
					foreach (Match quote in quotes){
						numberofquotes++;
					}
					if(numberofquotes > 2 || numberofquotes < 2){
						return text;
					}


					try{
						text = Replace (text, "\"", "");// to remove quotes
						text = Replace (text, "\"", "");// to remove quotes
					}
					catch{
						Console.WriteLine ("error during quote removal");
					}

					repstring = text;
					textview5.Buffer.Text += "\"\n";
					textview6.Buffer.Text += "STRING DELIMITER OPERATOR\n";
					tokens.Add (new Token("\"", "STRING DELIMITER"));
					textview5.Buffer.Text += text + "\n";
					textview6.Buffer.Text += "STRING LITERAL\n";
					tokens.Add (new Token(text, "STRING LITERAL"));
					textview5.Buffer.Text += "\"\n";
					textview6.Buffer.Text += "STRING DELIMITER OPERATOR\n";
					tokens.Add (new Token("\"", "STRING DELIMITER"));
					text = Replace (text, repstring, "");
					repstring = "";
				}
				else if (!(word2.StartsWith("\"")) && !(word2.EndsWith("\""))){
					textview5.Buffer.Text += m + "\n";
					textview6.Buffer.Text += "IDENTIFIER\n";
					tokens.Add (new Token(text, "IDENTIFIER"));
					repstring += m;
					text = Replace (text, repstring, "");
					repstring = "";
				}

			}
			i++;

			keyword = false;

		}

		if(text.StartsWith("\"") && text.EndsWith("\"")){
			int numberofquotes = 0;
			MatchCollection quotes = Regex.Matches(text, @"""");
			foreach (Match quote in quotes){
				numberofquotes++;
			}
			if(numberofquotes > 2 || numberofquotes < 2){
				return text;
			}
			try{
				text = Replace (text, "\"", "");// to remove quotes
				text = Replace (text, "\"", "");// to remove quotes
			}
			catch{
				Console.WriteLine ("error during quote removal");
			}


			repstring = text;

			textview5.Buffer.Text += "\"\n";
			textview6.Buffer.Text += "STRING DELIMITER OPERATOR\n";
			tokens.Add (new Token("\"", "STRING DELIMITER"));
			textview5.Buffer.Text += text + "\n";
			textview6.Buffer.Text += "STRING LITERAL\n";
			tokens.Add (new Token(text, "STRING LITERAL"));
			textview5.Buffer.Text += "\"\n";
			textview6.Buffer.Text += "STRING DELIMITER OPERATOR\n";
			tokens.Add (new Token("\"", "STRING DELIMITER"));
			text = Replace (text, repstring, "");
			repstring = "";
		}

		mc = Regex.Matches(text, @"^(BTW)$");
		foreach (Match m in mc){
			textview5.Buffer.Text += m + "\n";
			textview6.Buffer.Text += "SINGLE LINE COMMENT KEYWORD\n";
			tokens.Add (new Token(text, "SINGLE LINE COMMENT KEYWORD"));
			repstring += m;
			text = Replace (text, repstring, "");
			repstring = "";
		}

		//Console.WriteLine ("text is " + text);

		return text;

	}

	public static Boolean TypeChecker(TextView textview4){
		Queue expectationQueue = new Queue ();

		foreach(Token token in tokens){
			// check if current token is in expectation
			// 	enqueue expectation of current token to the queue
			if (expectationQueue.Count > 0){
				string currType = ExpectationTable.typesTable [token.getType ()];
				ArrayList expectedTypes;

				if (expectationQueue.Peek () is string) {
					expectedTypes = new ArrayList{ (string)expectationQueue.Peek () };
				}
				else {
					expectedTypes = (ArrayList)expectationQueue.Peek ();
				}

				if (currType == "STRING DELIMITER") {

				}else if (expectedTypes.Contains(currType)) {
					expectationQueue.Dequeue ();
				} else {
					textview4.Buffer.Text += ("Expected " + expectedTypes[0] + ", got " + currType)  + "\n";

					return false;
				}
			}
			if (ExpectationTable.table.ContainsKey(token.getType())){
				foreach (object keyword in ExpectationTable.table[token.getType()]) {
					expectationQueue.Enqueue(keyword);
				}
			}

			// variable checking - if token is identifier, check if it exists on symbol table
			if(token.getType() == "IDENTIFIER") {
				Boolean doesExist = false;

				foreach (Symbol symbol in symboltable) {
					if (token.getLexeme () == symbol.GetIdentifier ()) {
						doesExist = true;
					}
				}
				if (!doesExist) {
					textview4.Buffer.Text += ("Undeclared identifier " + token.getLexeme()) + "\n";

					return false;
				}
			}
		}

		return true;

	}
	//--- YOU KNOW WHAT JUST COPY PASTE EVERYTHING FROM HERE
	//--- as in lahat

	//for things such as VISIBLE NOT WIN
	// 5.00 == 5 gagamitin ko as default yung setFloat
	public void BooleanComparison(string text) {
		float temp1 = 0;
		float temp2 = 0;
		bool temp3 = false;
		bool temp4 = false;
		int temp5 = 0;
		int temp6 = 0;
		string temp7 = "";
		string temp8 = "";
		Regex yarn = new Regex(@"""?[A-Za-z](_*\d*[A-Za-z]*)*""?");

		string[] words;
		words = text.Split (default(string[]), StringSplitOptions.RemoveEmptyEntries);

		//CREATE pseudo symbol table for control flow purposes
		CreatePseudo ();

		if(words.Length == 5){
			//--- THIS IF FUNCTION			//for BOTH SAEM x AN y
			if(words[0].Equals("BOTH", StringComparison.Ordinal) && words[1].Equals("SAEM", StringComparison.Ordinal) && words[3].Equals("AN", StringComparison.Ordinal)) {
				if (words [2].StartsWith ("\"") && words [2].EndsWith ("\"")) { //means inside "" obv not an identifier
					words [2] = words [2].Substring (1); //removes first quotation mark
					words [2] = words [2].Remove (words [2].Length - 1); //removes last quotation mark
				} else {
					if (yarn.IsMatch (words [2])) { //an identifier
						foreach (Symbol symbol in pseudo) { //get from symbol table
							if (words [2] == symbol.GetIdentifier ()) {
								if (symbol.GetType ().Equals ("STRING LITERAL", StringComparison.Ordinal)) {
									words [2] = symbol.GetValue (); //get value bec string na naman sya
									words [2] = words [2].Substring (1); //removes first quotation mark
									words [2] = words [2].Remove (words [2].Length - 1); //removes last quotation mark
								} else {
									words[2] = symbol.GetValue().ToString(); //string it para yun yung ipapasa
								}
								break;
							}
						} 
					}
				}

				if (IsDigitsOnly (words [2])) { 
					float.TryParse (words [2], out temp1);  //tries to convert to float
				} else {
					//get value from symbol table
					if (words [2].Equals ("WIN", StringComparison.Ordinal)) {
						temp3 = true;
					} else if (words [2].Equals ("FAIL", StringComparison.Ordinal)) {
						temp3 = false;
					} else {
						temp7 = words [2];
					}
				}

				if (words [4].StartsWith ("\"") && words [4].EndsWith ("\"")) { //means inside "" obv not an identifier
					words [4] = words [4].Substring (1); //removes first quotation mark
					words [4] = words [4].Remove (words [4].Length - 1); //removes last quotation mark
				} else {
					if (yarn.IsMatch (words [4])) { //an identifier
						foreach (Symbol symbol in pseudo) { //get from symbol table
							if (words [4] == symbol.GetIdentifier ()) {
								if (symbol.GetType ().Equals ("STRING LITERAL", StringComparison.Ordinal)) {
									words [4] = symbol.GetValue (); //get value bec string na naman sya
									words [4] = words [4].Substring (1); //removes first quotation mark
									words [4] = words [4].Remove (words [4].Length - 1); //removes last quotation mark
								} else {
									words[4] = symbol.GetValue().ToString(); //string it para yun yung ipapasa
								}
								break;
							}
						} 
					}
				}

				if (IsDigitsOnly (words [4])) { 
					float.TryParse (words [4], out temp2);  //tries to convert to float
				} else {
					//get value from symbol table
					if (words [4].Equals ("WIN", StringComparison.Ordinal)) {
						temp4 = true;
					} else if (words [4].Equals ("FAIL", StringComparison.Ordinal)) {
						temp4 = false;
					} else {
						temp8 = words [4];
					}
				}

				if (temp1 == temp2 && temp3 == temp4 && temp7.Equals (temp8, StringComparison.Ordinal)) {
					it.setValue(true);
				} else {
					it.setValue(false);
				}
			}

			//for BOTH OF x AN y
			if(words[0].Equals("BOTH", StringComparison.Ordinal) && words[1].Equals("OF", StringComparison.Ordinal) && words[3].Equals("AN", StringComparison.Ordinal)) {
				if (words [2].Equals ("WIN", StringComparison.Ordinal)) {
					temp3 = true;
				} else {
					temp3 = false;
				}

				if (words [4].Equals ("WIN", StringComparison.Ordinal)) {
					temp4 = true;
				} else {
					temp4 = false;
				}
				//TRUE AND TRUE
				if (temp3 && temp4) {
					it.setValue(true);
				} else {
					it.setValue(false);
				}
			}

			//for EITHER OF x AN y
			if(words[0].Equals("EITHER", StringComparison.Ordinal) && words[1].Equals("OF", StringComparison.Ordinal) && words[3].Equals("AN", StringComparison.Ordinal)) {
				if (words [2].Equals ("WIN", StringComparison.Ordinal)) {
					temp3 = true;
				} else if (words [2].Equals ("FAIL", StringComparison.Ordinal)) {
					temp3 = false;
				}

				if (words [4].Equals ("WIN", StringComparison.Ordinal)) {
					temp4 = true;
				} else if (words [4].Equals ("FAIL", StringComparison.Ordinal)) {
					temp4 = false;
				}

				//TRUE OR TRUE
				if (temp3 || temp4) {
					it.setValue(true);
				} else {
					it.setValue(false);
				}
			}

			//for WON OF x AN y
			if(words[0].Equals("WON", StringComparison.Ordinal) && words[1].Equals("OF", StringComparison.Ordinal) && words[3].Equals("AN", StringComparison.Ordinal)) {
				if (words [2].Equals ("WIN", StringComparison.Ordinal)) {
					temp3 = true;
				} else if (words [2].Equals ("FAIL", StringComparison.Ordinal)) {
					temp3 = false;
				}

				if (words [4].Equals ("WIN", StringComparison.Ordinal)) {
					temp4 = true;
				} else if (words [4].Equals ("FAIL", StringComparison.Ordinal)) {
					temp4 = false;
				}

				//TRUE XOR FALSE
				if (temp3 ^ temp4) {
					it.setValue(true);
				} else {
					it.setValue(false);
				}
			}

			//--- THIS WHOLE IF FUNCTION		//for BIGGR OF x AN y
			if(words[0].Equals("BIGGR", StringComparison.Ordinal) && words[1].Equals("OF", StringComparison.Ordinal) && words[3].Equals("AN", StringComparison.Ordinal)) {
				if (IsDigitsOnly (words [2])) { 
					float.TryParse (words [2], out temp1);  //tries to convert to float
				} else {
					//get value from symbol table
					foreach (Symbol symbol in pseudo) {
						if (words [2] == symbol.GetIdentifier ()) {
							float.TryParse(symbol.GetValue (), out temp1);		
						}
					} 
				}

				if (IsDigitsOnly (words [4])) { 
					float.TryParse (words [4], out temp2);  //tries to convert to float
				} else {
					//get value from symbol table
					foreach (Symbol symbol in pseudo) {
						if (words [4] == symbol.GetIdentifier ()) {
							float.TryParse(symbol.GetValue (), out temp2);
						}
					} 
				}

				if (temp1 >= temp2) {
					it.setFloatNum(temp1);
				} else {
					it.setFloatNum(temp2);
				}
			}
			//--- THIS WHOLE IF			//FOR SMALLR OF x AN y
			if(words[0].Equals("SMALLR", StringComparison.Ordinal) && words[1].Equals("OF", StringComparison.Ordinal) && words[3].Equals("AN", StringComparison.Ordinal)) {
				if (IsDigitsOnly (words [2])) { 
					float.TryParse (words [2], out temp1);  //tries to convert to float
				} else {
					//get value from symbol table
					foreach (Symbol symbol in pseudo) {
						if (words [2] == symbol.GetIdentifier ()) {
							float.TryParse(symbol.GetValue (), out temp1);		
						}
					} 
				}

				if (IsDigitsOnly (words [4])) { 
					float.TryParse (words [4], out temp2);  //tries to convert to float
				} else {
					//get value from symbol table
					foreach (Symbol symbol in pseudo) {
						if (words [4] == symbol.GetIdentifier ()) {
							float.TryParse(symbol.GetValue (), out temp2);
						}
					} 
				}

				if (temp1 <= temp2) {
					it.setFloatNum(temp1);
				} else {
					it.setFloatNum(temp2);
				}
			}
		}

		if (words.Length == 2) {
			if(words[0].Equals("NOT", StringComparison.Ordinal)) {
				if (words [1].Equals ("WIN", StringComparison.Ordinal)) {
					it.setValue(false);
				} else if (words [1].Equals ("FAIL", StringComparison.Ordinal)) {
					it.setValue(true);
				}

			}
		}

		if (words.Length == 4) {
			///THIS IF FUNCTION			//for DIFFRINT x AN y
			if(words[0].Equals("DIFFRINT", StringComparison.Ordinal) && words[2].Equals("AN", StringComparison.Ordinal)) {
				if (words [1].StartsWith ("\"") && words [1].EndsWith ("\"")) { //means inside "" obv not an identifier
					words [1] = words [1].Substring (1); //removes first quotation mark
					words [1] = words [1].Remove (words [1].Length - 1); //removes last quotation mark
				} else {
					if (yarn.IsMatch (words [1])) { //an identifier
						foreach (Symbol symbol in pseudo) { //get from symbol table
							if (words [1] == symbol.GetIdentifier ()) {
								if (symbol.GetType ().Equals ("STRING LITERAL", StringComparison.Ordinal)) {
									words [1] = symbol.GetValue (); //get value bec string na naman sya
									words [1] = words [1].Substring (1); //removes first quotation mark
									words [1] = words [1].Remove (words [1].Length - 1); //removes last quotation mark
								} else {
									words[1] = symbol.GetValue().ToString(); //string it para yun yung ipapasa
								}
							}
						} 
					}
				}

				if (IsDigitsOnly (words [1])) { 
					float.TryParse (words [1], out temp1);  //tries to convert to float
				} else {
					//get value from symbol table
					if (words [1].Equals ("WIN", StringComparison.Ordinal)) {
						temp3 = true;
					} else if (words [1].Equals ("FAIL", StringComparison.Ordinal)) {
						temp3 = false;
					} else {
						temp7 = words [1];
					}
				}



				if (words [3].StartsWith ("\"") && words [3].EndsWith ("\"")) { //means inside "" obv not an identifier
					words [3] = words [3].Substring (1); //removes first quotation mark
					words [3] = words [3].Remove (words [3].Length - 1); //removes last quotation mark
				} else {
					if (yarn.IsMatch (words [3])) { //an identifier
						foreach (Symbol symbol in pseudo) { //get from symbol table
							if (words [3] == symbol.GetIdentifier ()) {
								if (symbol.GetType ().Equals ("STRING LITERAL", StringComparison.Ordinal)) {
									words [3] = symbol.GetValue (); //get value bec string na naman sya
									words [3] = words [3].Substring (1); //removes first quotation mark
									words [3] = words [3].Remove (words [3].Length - 1); //removes last quotation mark
								} else {
									words[3] = symbol.GetValue().ToString(); //string it para yun yung ipapasa
								}
							}
						} 
					}
				}

				if (IsDigitsOnly (words [3])) { 
					float.TryParse (words [3], out temp2);  //tries to convert to float
				} else {
					//get value from symbol table
					if (words [3].Equals ("WIN", StringComparison.Ordinal)) {
						temp4 = true;
					} else if (words [3].Equals ("FAIL", StringComparison.Ordinal)) {
						temp4 = false;
					} else {
						temp8 = words [3];
					}
				}

				if (temp1 == temp2 && temp3 == temp4 && temp7.Equals (temp8, StringComparison.Ordinal)) {
					it.setValue(false);
				} else {
					it.setValue(true);
				}
			}
		}
		if (words.Length == 8) {
			//GETS VARIABLES FIRST
			if (IsDigitsOnly (words [1])) { 
				float.TryParse (words [1], out temp1);  //tries to convert to float
			} else {
				//get value from symbol table
				foreach (Symbol symbol in pseudo) {
					if (words [1] == symbol.GetIdentifier ()) {
						float.TryParse(symbol.GetValue (), out temp1);		
					}
				} 
			}

			if (IsDigitsOnly (words [7])) { 
				float.TryParse (words [7], out temp2);  //tries to convert to float
			} else {
				//get value from symbol table
				foreach (Symbol symbol in pseudo) {
					if (words [7] == symbol.GetIdentifier ()) {
						float.TryParse(symbol.GetValue (), out temp2);		
					}
				} 
			}

			if(words[0].Equals("DIFFRINT", StringComparison.Ordinal) && words[3].Equals("BIGGR", StringComparison.Ordinal) && words[6].Equals("AN", StringComparison.Ordinal)) {
				if (temp1 < temp2 && temp5 < temp6) {
					it.setValue(true);
				} else {
					it.setValue(false);
				}
			}

			if(words[0].Equals("DIFFRINT", StringComparison.Ordinal) && words[3].Equals("SMALLR", StringComparison.Ordinal) && words[6].Equals("AN", StringComparison.Ordinal)) {
				if (temp1 > temp2) {
					it.setValue(true);
				} else {
					it.setValue(false);
				}
			}
		}
		if (words.Length == 9) {
			//GETS VARIABLES FIRST
			if (IsDigitsOnly (words [2])) { 
				float.TryParse (words [2], out temp1);  //tries to convert to float
			} else {
				//get value from symbol table
				foreach (Symbol symbol in pseudo) {
					if (words [2] == symbol.GetIdentifier ()) {
						float.TryParse(symbol.GetValue (), out temp1);		
					}
				} 
			}

			if (IsDigitsOnly (words [8])) { 
				float.TryParse (words [8], out temp2);  //tries to convert to float
			} else {
				//get value from symbol table
				foreach (Symbol symbol in pseudo) {
					if (words [8] == symbol.GetIdentifier ()) {
						float.TryParse(symbol.GetValue (), out temp2);		
					}
				} 
			}

			if(words[0].Equals("BOTH", StringComparison.Ordinal) && words[4].Equals("BIGGR", StringComparison.Ordinal) && words[7].Equals("AN", StringComparison.Ordinal)) {
				//they are all equal by default
				if (temp1 <= temp2 && temp5 <= temp6) {
					it.setValue(true);
				} else {
					it.setValue(false);
				}
			}

			if(words[0].Equals("BOTH", StringComparison.Ordinal) && words[4].Equals("SMALLR", StringComparison.Ordinal) && words[7].Equals("AN", StringComparison.Ordinal)) {
				//they are all equal by default
				if (temp1 >= temp2 && temp5 >= temp6) {
					it.setValue(true);
				} else {
					it.setValue(false);
				}
			}
		}
		//FLUSHES PSEUDO VALUES
		pseudo.Clear ();
	}

	//checks if everything is simply digits
	//gotten from stack overflow
	public bool IsDigitsOnly(string str)
	{
		foreach (char c in str)
		{
			if (c < '0' || c > '9')
				return false;
		}

		return true;
	}

	//--- THIS WHOLE FUNCTION
	public void omgmatch(string text, ref bool omgfound){
		Regex yarn = new Regex(@"""?[A-Za-z](_*\d*[A-Za-z]*)*""?");
		Regex troof = new Regex(@"^(WIN|FAIL)$");
		float temp1 = 0;
		bool temp2 = false;
		string[] words;
		int i = text.IndexOf ("OMG ") + 4;
		text = text.Substring (4);
		words = text.Split (default(string[]), StringSplitOptions.RemoveEmptyEntries);

		if (IsDigitsOnly (words [0])) { 
			float.TryParse (words [0], out temp1);  //tries to convert to float
			if(temp1 == it.getFloatNum()){
				omgfound = true;
			}
		} else {	//not number so must be yarn or troof
			if(yarn.IsMatch(words[0])){
				if (text == it.getYarn ()) {
					omgfound = true;
				}
			}
			if (troof.IsMatch (words [0])) {
				//default ng temp2 ay false
				if (text.Equals ("WIN", StringComparison.Ordinal)) {
					temp2 = true;
				}
				if (temp2 == it.getValue ()) {
					omgfound = true;
				}
			}
		}
	}

	public void CreatePseudo() {
		//CREATE PSEUDO SYMBOL TABLE
		float flt;
		int num;
		string stringVal;
		for (int i = 0; i < tokens.Count; i++) {
			Token token = (Token)tokens [i];
			// search for all declarations
			if (token.getType () == "VARIABLE DECLARATION KEYWORD") {
				Token nextToken = (Token)tokens [i + 1];
				Token itzToken = (Token)tokens [i + 2];
				string dataType;

				//ITZ SUM OF 1 AN 1
				//  2   3    4  5  6

				if (itzToken.getType () == "ITZ KEYWORD") {
					Token afterItzToken = (Token)tokens [i + 3];

					if (afterItzToken.getType () == "INTEGER LITERAL") {
						dataType = "NUMBR";
						stringVal = afterItzToken.getLexeme ();
					} else if (afterItzToken.getType () == "STRING DELIMITER") {
						dataType = "YARN";
						Token yarnToken = (Token)tokens [i + 4];
						stringVal = yarnToken.getLexeme ();
					} else if (afterItzToken.getType () == "BOOLEAN LITERAL") {
						stringVal = afterItzToken.getLexeme ();
						dataType = "TROOF";
					} else if (afterItzToken.getType () == "DECIMAL LITERAL") {
						stringVal = afterItzToken.getLexeme ();
						dataType = "NUMBAR";
					} else { //else like arithmetic operation
						Token firstToken = (Token)tokens [i + 4];
						Token secondToken = (Token)tokens [i + 6];
						Console.WriteLine (firstToken.getType());
						Console.WriteLine (secondToken.getType());
						if (firstToken.getType () == "DECIMAL LITERAL" || secondToken.getType () == "DECIMAL LITERAL") {
							Console.WriteLine ("=======================================");
							dataType = "NUMBAR";
							flt = FloatExecution (i + 2);
							stringVal = Convert.ToString (flt);
						} else {
							dataType = "NUMBR";
							num = NumExecution (i + 2);
							stringVal = Convert.ToString (num);

						}
					}
					pseudo.Add (new Symbol (nextToken.getLexeme (), stringVal, dataType));
				} else {
					dataType = "NOOB";
					pseudo.Add (new Symbol (nextToken.getLexeme (), dataType)); //, nextToken.getType(), "1"
				}
			}
		}
	}

}
