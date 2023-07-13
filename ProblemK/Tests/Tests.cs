using ProblemK.Table;
using ProblemK.Table.Interfaces;
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
			Console.WriteLine("START TEST 1\n");
			Table.Table table = new TableManager().Create();
			PrintManager PrintManager = new PrintManager();
			table.Rows[0].Cells[0].Write("=A1");
			table.Rows[1].Cells[0].Write("=A2");
			table.Rows[2].Cells[0].Write("=A0");

			table.Rows[0].Cells[1].Write("12");
			table.Rows[1].Cells[1].Write("=B0");
			table.Rows[2].Cells[1].Write("=10+B1+B0");

			PrintManager.Serialize(table);
			Console.WriteLine("\nEND TEST 1");
		}
		public static void Test_2()
		{
			Console.WriteLine("START TEST 2\n");
			Table.Table table = new TableManager().Create();
			ISerialize serializer = new SerializerTXT();
			PrintManager PrintManager = new PrintManager();
			table.Rows[0].Cells[0].Write("=A1");
			table.Rows[1].Cells[0].Write("=A2");
			table.Rows[2].Cells[0].Write("=A0");

			table.Rows[0].Cells[1].Write("12"); // B0
			table.Rows[1].Cells[1].Write("=B0"); // B1
			table.Rows[2].Cells[1].Write("=10+B1+B0"); // B2

			table.Rows[0].Cells[2].Write("5"); // C0
			table.Rows[1].Cells[2].Write("=C0+C0*3"); // C1

			serializer.Serialize(table, "test.txt");


			table = serializer.Deserialize("test.txt", new TableSettings());
			PrintManager.Serialize(table);
			Console.WriteLine("\nEND TEST 2");
		}
		public static void Test_3()
		{
			Console.WriteLine("START TEST 3\n");
			Table.Table table = new TableManager().Create();
			PrintManager PrintManager = new PrintManager();
			table.Rows[0].Cells[0].Write("12"); // A0
			table.Rows[1].Cells[0].Write("=A4"); // A1
			table.Rows[2].Cells[0].Write("=A0+A1"); // A2
			table.Rows[3].Cells[0].Write("=A2"); // A3
			table.Rows[4].Cells[0].Write("=A2"); // A4

			table.Rows[0].Cells[1].Write("10"); // B0
			table.Rows[1].Cells[1].Write("0"); // B1
			table.Rows[2].Cells[1].Write("=B0/B1"); // B2

			table.Rows[0].Cells[2].Write("str"); // C0
			table.Rows[1].Cells[2].Write("0"); // C1
			table.Rows[2].Cells[2].Write("=C0/C1"); // C2

			table.Rows[0].Cells[3].Write("'str"); // D0
			table.Rows[1].Cells[3].Write("0"); // D1
			table.Rows[2].Cells[3].Write("=D0/D1"); // D2

			PrintManager.Serialize(table);
			Console.WriteLine("\nEND TEST 3");
		}
	}
}
