using System;

namespace sample124
{
	public class Token
	{
		private string lexeme;
		private string type;

		public Token (string lexeme, string type)
		{
			this.lexeme = lexeme;
			this.type = type;
		}

		public string getLexeme(){
			return this.lexeme;
		}

		public string getType(){
			return this.type;
		}
	}
}
