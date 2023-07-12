using ProblemK.Table;
using ProblemK.Table.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Tests
{
	internal static class Tests
	{
		public static void Test_1()
		{
			Console.WriteLine("START TEST 1");
			Table.Table table = new Table.Table(5, 5, new ExpressionSolver());
			PrintManager PrintManager = new PrintManager();
			table.Rows[0].Cells[0].Write("=A1");
			table.Rows[1].Cells[0].Write("=A2");
			table.Rows[2].Cells[0].Write("=A0");

			table.Rows[0].Cells[1].Write("12");
			table.Rows[1].Cells[1].Write("=B0");
			table.Rows[2].Cells[1].Write("=10+B1+B0");

			PrintManager.Serialize(table);
			Console.WriteLine("END TEST 1");
		}
		public static void Test_2()
		{
			Console.WriteLine("START TEST 2");
			Table.Table table = new Table.Table(5, 5, new ExpressionSolver());
			PrintManager PrintManager = new PrintManager();
			table.Rows[0].Cells[0].Write("=A1");
			table.Rows[1].Cells[0].Write("=A0");

			PrintManager.Serialize(table);
			Console.WriteLine("END TEST 2");
		}
	}
}
