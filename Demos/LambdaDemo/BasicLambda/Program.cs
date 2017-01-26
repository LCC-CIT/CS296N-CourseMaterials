using System;

namespace BasicLambda
{
	class MathOps
	{
		private int number1;
		private int number2;

		// Normal read-only property
		public int Number1 { get { return number1; } }

		// Lambda read-only properties
		public int Number2 => number2;
		public float Quotient => number1 / number2;

		// Constructors
		public MathOps() { }

		public MathOps(int n1, int n2)
		{
			number1 = n1;
			number2 = n2;
		}
		               
		// A normal method definition
		public static float Sum(int a, int b)
		{
			return a + b;
		}

		// A lambda method difinition
		public static float Product(int a, int b) => a * b;

		// This method accepts another method as an argument
		// Func defines the signature of any method that will be passed in
		// The first two types are the parameter types, the third is the return type
		public static void DisplayResult(Func<int, int, float> MathOp, int num1, int num2)
		{
			Console.WriteLine(MathOp(num1, num2));
		}
	}


	class MainClass
	{
		public static void Main(string[] args)
		{
			int a = 3, b = 7;
			Console.WriteLine("MathOp using Sum");
			MathOps.DisplayResult(MathOps.Sum, a, b);

			Console.WriteLine("MathOp using Product");
			MathOps.DisplayResult(MathOps.Product, a, b);

			Console.WriteLine("MathOp using an anonymous method");
			MathOps.DisplayResult((n1, n2) => n1 - n2, a, b);

			Console.WriteLine("Using MathOps properties");
			var math = new MathOps(100, 11);
			Console.WriteLine(String.Format("{0} / {1} = {2}",
			               math.Number1, math.Number2, math.Quotient));
		}
	}
}