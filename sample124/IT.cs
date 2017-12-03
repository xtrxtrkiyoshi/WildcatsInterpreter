using System;

namespace sample124
{
	/*
	  IT - has default value of false;
	  give value through setInt() for NUMBR,
	  setFloat() for NUMBAR, setBool() for TROOF;
	  get value through getInt() for NUMBR,
	  getFloat() for NUMBAR, getBool() for TROOF;

		Format for type:
		- "TROOF"
		- "NUMBR"
		- "NUMBAR"
		- "YARN"
	*/
	public class IT
	{
		private bool value;
		private int intNum;
		private float floatNum;
		private string yarn;
		private string type;

		public IT ()
		{
			this.value = false;
			this.intNum = 0;
			this.floatNum = 0;
			this.yarn = "";
			this.type = "TROOF";
		}

		public void setValue(bool value){
			this.value = value;
			this.type = "TROOF";
		}

		public void setIntNum(int num){
			this.intNum = num;
			this.type = "NUMBR";
			this.value = true;
		}

		public void setFloatNum(float num){
			this.floatNum = num;
			this.type = "NUMBAR";
			this.value = true;
		}

		public void setYarn(string text){
			this.yarn = text;
			this.type = "YARN";
			this.value = true;
		}

		public bool getValue(){
			return this.value;
		}

		public int getIntNum(){
			return this.intNum;
		}

		public float getFloatNum(){
			return this.floatNum;
		}

		public string getYarn(){
			return this.yarn;
		}

		public string getType(){
			return this.type;
		}
	}
}


