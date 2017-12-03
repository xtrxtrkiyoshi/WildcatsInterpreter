using System;
using System.Text.RegularExpressions;

namespace sample124
{
	public class Matcher
	{
		public static Regex sumof = new Regex(@"SUM OF$");
		public static Regex diffrint = new Regex(@"^(DIFFRINT)$");
		public static Regex produktof = new Regex(@"^(PRODUKT OF)$");
		public static Regex quoshuntof = new Regex(@"^(QUOSHUNT OF)$");
		public static Regex modof = new Regex(@"^(MOD OF)$");

		public static bool IsArithmeticOperation(string token) {
			return
				sumof.IsMatch (token) ||
				diffrint.IsMatch (token) ||
				produktof.IsMatch (token) ||
				quoshuntof.IsMatch (token) ||
				modof.IsMatch (token);
		}
	}
}


