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
		public static Table.Table Table;
		static void Main(string[] args)
		{
			Table = new TableManager().CreateTable(5, 5);
			UI.Initial();
		}
	}
}