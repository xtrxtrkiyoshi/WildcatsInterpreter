using System;
using System.Collections.Generic;
using System.Collections;

namespace sample124
{
	public class ExpectationTable
	{
		//const string ANYOF = "INFINITE ARITY OR OPERATOR";
		//const string ALLOF = "INFINITE ARITY AND OPERATOR";
		const string DIFFRINT = "NOT EQUAL OPERATOR";
		const string NOT = "NOT OPERATOR";
		const string BOTHSAEM = "EQUAL OPERATOR";
		const string WONOF = "XOR OPERATOR";
		const string BOTHOF = "AND OPERATOR";
		const string EITHEROF = "OR OPERATOR";

		const string SMALLEROF = "MIN OPERATOR";
		const string BIGGEROF = "MAX OPERATOR";

		const string QUOSHUNTOF = "DIVISION OPERATOR";
		const string PRODUKTOF = "MULTIPLICATION OPERATOR";
		const string SUMOF = "ADDITION OPERATOR";
		const string DIFFOF = "SUBTRACTION OPERATOR";
		const string MODOF = "MODULO OPERATOR";


		const string UPPIN = "INCREMENT OPERATOR";
		const string NERFIN = "DECREMENT OPERATOR";

		const string YARN = "STRING LITERAL";
		const string NUMBAR = "DECIMAL LITERAL";
		const string NUMBR = "INTEGER LITERAL";
		const string BOOLEAN = "BOOLEAN LITERAL";
		const string DATATYPE = "DATA TYPE LITERAL";

		const string SMOOSH = "CONCATENATION OPERATOR";

		//const string MAEK = "TYPECAST OPERATOR";
		//const string ISNOWA = "TYPECAST OPERATOR";

		//const string IMINYR = "ITERATION START KEYWORD";
		//const string TIL = "ITERATION KEYWORD";
		//const string WILE = "ITERATION KEYWORD";
		//const string IMOUTTAYR = "ITERATION END KEYWORD";

		//LACKS DATA TYPE CONST

		const string R = "ASSIGNMENT OPERATOR";
		const string IHASA = "VARIABLE DECLARATION KEYWORD";
		const string AN = "AN KEYWORD";
		const string ITZ = "ITZ KEYWORD";

		const string GIMMEH = "SYSTEM INPUT KEYWORD";
		const string VISIBLE = "SYSTEM OUTPUT KEYWORD";

		const string ORLY = "IF KEYWORD";
		const string YARLY = "IF TRUE KEYWORD";
		const string MEBBE = "IF ELSE KEYWORD";
		const string NOWAI = "IF FALSE KEYWORD";

		const string WTF = "SWITCH START KEYWORD";
		const string OMG = "SWITCH CASE KEYWORD";
//---		//const string OMGWTF = "SWITCH DEFAULT KEYWORD";

		const string OIC = "END CONDITION KEYWORD";

		const string IDENTIFIER = "IDENTIFIER";
		const string NUMBER = "NUMBER";
		const string STRING = "STRING";

		const string STRINGDELIMITER = "STRING DELIMITER";


		public static Dictionary<string, ArrayList> table = new Dictionary<string, ArrayList> ();

		public static Dictionary<string, string> typesTable = new Dictionary<string, string> () {
			{ NUMBAR, NUMBER },
			{ NUMBR, NUMBER },
			{ BOOLEAN, BOOLEAN },
			{ YARN, STRING },

			{STRINGDELIMITER, STRINGDELIMITER},

			{ VISIBLE, VISIBLE },
			{ GIMMEH, GIMMEH },

			{ ITZ, ITZ },
			{ AN, AN },
			{ R, R },
			{ IHASA, IHASA },
		
			//{ IMINYR, IMINYR },
			//{ TIL, TIL },
			//{ WILE, WILE },
			//{ IMOUTTAYR, IMOUTTAYR },

			//{ MAEK, MAEK },
			//{ ISNOWA, ISNOWA },

			{ WTF, WTF },
			{ OMG, OMG },
//---			//{ OMGWTF, OMGWTF },

			{ ORLY, ORLY },
			{ YARLY, YARLY },
			{ MEBBE, MEBBE },
			{ NOWAI, NOWAI },

			{ OIC, OIC },

			{ SMOOSH, STRING },

			{ BOTHOF, BOOLEAN },
			{ EITHEROF, BOOLEAN },
			{ WONOF, BOOLEAN },
			{ DIFFRINT, BOOLEAN },
			{ BOTHSAEM, BOOLEAN },
			{ NOT, BOOLEAN },

			{ UPPIN, NUMBER }, 
			{ NERFIN, NUMBER }, 

			{ IDENTIFIER, IDENTIFIER }, 

			{ MODOF, NUMBER }, 
			{ SUMOF, NUMBER }, 
			{ PRODUKTOF, NUMBER },
			{ QUOSHUNTOF, NUMBER },
			{ BIGGEROF, NUMBER },
			{ SMALLEROF, NUMBER },
			{ DIFFOF, NUMBER },


		};

	

		static ExpectationTable(){
			//table.Add ("CONCNATENATION OPERATOR", new ArrayList{STRING, AN, STRING.. MKAY });
			table.Add ("ASSIGNMENT OPERATOR", new ArrayList{
				new ArrayList{ YARN, BOOLEAN, NUMBER, STRINGDELIMITER, STRING }
			}); //
			table.Add ("VARIABLE DECLARATION KEYWORD", new ArrayList{IDENTIFIER}); //identifier
			table.Add ("ITZ KEYWORD", new ArrayList{
				new ArrayList{ STRINGDELIMITER, BOOLEAN, NUMBER, YARN, STRING}
			});

			table.Add ("SYSTEM INPUT KEYWORD", new ArrayList{IDENTIFIER}); //problem
			table.Add ("SYSTEM OUTPUT KEYWORD", new ArrayList{
				new ArrayList{ NUMBER, BOOLEAN, STRING, STRINGDELIMITER, IDENTIFIER}
			}); //problem

			table.Add ("SWITCH CASE KEYWORD", new ArrayList{
				new ArrayList{ BOOLEAN, NUMBER,  STRINGDELIMITER }
			}); // expect value literal
//---			//table.Add ("SWITCH DEFAULT KEYWORD", new ArrayList{NUMBER}); // 

			//table.Add ("END CONDITION KEYWORD", new ArrayList{NUMBER});
		
			table.Add ("INCREMENT OPERATOR", new ArrayList{NUMBER});
			table.Add ("DECREMENT OPERATOR", new ArrayList{NUMBER});

			table.Add ("ADDITION OPERATOR", new ArrayList{new ArrayList{YARN, NUMBER, IDENTIFIER} , AN, new ArrayList{YARN, NUMBER, IDENTIFIER} });
			table.Add ("SUBTRACTION OPERATOR", new ArrayList{new ArrayList{YARN, NUMBER, IDENTIFIER} , AN, new ArrayList{YARN, NUMBER, IDENTIFIER} });
			table.Add ("MULTIPLICATION OPERATOR", new ArrayList{new ArrayList{YARN, NUMBER, IDENTIFIER} , AN, new ArrayList{YARN, NUMBER, IDENTIFIER} });
			table.Add ("DIVISION OPERATOR", new ArrayList{new ArrayList{YARN, NUMBER, IDENTIFIER} , AN, new ArrayList{YARN, NUMBER, IDENTIFIER} });
			table.Add ("MODULO OPERATOR", new ArrayList{new ArrayList{YARN, NUMBER, IDENTIFIER} , AN, new ArrayList{YARN, NUMBER, IDENTIFIER} });

//---- EVERYTHING BELOW THIS LINE

			table.Add ("MAX OPERATOR", new ArrayList{new ArrayList{ STRING, NUMBER, IDENTIFIER} , AN, new ArrayList{ STRING, NUMBER, IDENTIFIER} });
			table.Add ("MIN OPERATOR", new ArrayList{new ArrayList{ STRING, NUMBER, IDENTIFIER} , AN, new ArrayList{ STRING, NUMBER, IDENTIFIER} });
			table.Add ("NOT EQUAL OPERATOR",  new ArrayList{new ArrayList{ STRING, NUMBER, IDENTIFIER, BOOLEAN} , AN, new ArrayList{ STRING, NUMBER, IDENTIFIER, BOOLEAN} });
			table.Add ("NOT OPERATOR", new ArrayList{new ArrayList{ STRING, IDENTIFIER, BOOLEAN}});
			table.Add ("EQUAL OPERATOR",  new ArrayList{new ArrayList{ STRING, NUMBER, IDENTIFIER, BOOLEAN} , AN, new ArrayList{ STRING, NUMBER, IDENTIFIER, BOOLEAN} });
			table.Add ("XOR OPERATOR",  new ArrayList{new ArrayList{ STRING,IDENTIFIER, BOOLEAN} , AN, new ArrayList{ STRING, IDENTIFIER, BOOLEAN} });
			table.Add ("AND OPERATOR",  new ArrayList{new ArrayList{ STRING, IDENTIFIER, BOOLEAN} , AN, new ArrayList{ STRING, IDENTIFIER, BOOLEAN} });
			table.Add ("OR OPERATOR",  new ArrayList{new ArrayList{ STRING, IDENTIFIER, BOOLEAN} , AN, new ArrayList{ STRING, IDENTIFIER, BOOLEAN} });

		}
	}
}

