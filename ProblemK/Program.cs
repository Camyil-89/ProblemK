using ProblemK.Table;
using ProblemK.Table.Print;

namespace ProblemK
{
	/// <summary>
	/// https://wiki.haskell.org/Ru/Problem_K
	/// проект для решение задачки.
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			Tests.Tests.Test_1();
			Console.WriteLine();
			Console.WriteLine();
			Tests.Tests.Test_2();
			Console.WriteLine();
			Console.WriteLine();
			Tests.Tests.Test_3();
			Console.WriteLine();
			Console.WriteLine();
			UI.Initial();
		}
	}
}