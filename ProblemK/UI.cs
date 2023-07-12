using ProblemK.Table;
using ProblemK.Table.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK
{
	internal static class UI
	{
		private static PrintManager PrintManager = new PrintManager();
		public static void Initial()
		{
			while (true)
			{
				try
				{
					Console.Write($"1 - Выбор ячейки\n" +
						$"2 - Вывод таблицы\n" +
						$"3 - Вывод только значений\n" +
						$"4 - Очистка экрана\n" +
						$"0 - Выход\n" +
						$"------------------\n" +
						$"Ввод:");
					var input = Console.ReadLine();
					Console.WriteLine();
					if (input == "1")
					{
						SelectCell();
					}
					else if (input == "2")
					{

						PrintManager.Serialize(Program.Table);
					}
					else if (input == "3")
					{
						PrintManager.PrintOnlyValue(Program.Table);
					}
					else if (input == "4")
					{
						Console.Clear();
					}
					else if (input == "0")
					{
						return;
					}
					Console.WriteLine("\n\n\n");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
		}
		public static void SelectCell()
		{
			Console.Write($"Введите ячейку: ");
			try
			{
				var pos = Cell.GetNumberFromChar(Console.ReadLine());
				var cell = Program.Table.Rows[pos[0]].Cells[pos[1]];
				Console.Write("Ввод:");
				cell.Write(Console.ReadLine());
			}
			catch (Exception ex) { Console.WriteLine("Не удалось найти такую ячейку!"); }
		}
	}
}
