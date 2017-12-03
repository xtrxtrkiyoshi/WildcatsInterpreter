using System;

namespace sample124
{
	public class Symbol
	{
		string identifier;
		string type;
		string value;

		public Symbol (string identifier, string type) 
		{
			this.identifier = identifier;
			this.type = type;
		}

		public Symbol (string identifier, string value, string type) //, string value
		{
			this.identifier = identifier;
			this.type = type;
			this.value = value;
		}

		// @TODO: constructor with specified type and/or value

		public string GetIdentifier() {
			return this.identifier;
		}

		public string GetType() {
			return this.type;
		}

		public string GetValue() {
			return this.value;
		}

		public void SetType(string type) {
			this.type = type;
		}

		public void SetValue(string value) {
			this.value = value;
		}
	}
}

