using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Print
{
	internal class PrintManager
	{
		public void Serialize(Table table)
		{
			for (int row = 0; row < table.Rows.Count; row++)
			{
				for (int cell = 0; cell < table.Rows[row].Cells.Count; cell++)
				{
					var _cell = table.Rows[row].Cells[cell];
					Console.Write("{0,30}", $"{Cell.GetCharFromNumber(cell)}{row} ({_cell.GetWithoutCalculate()}) [{_cell.GetCalculate(table)}]\t");
				}
				Console.WriteLine();
			}
		}
		public void PrintOnlyValue(Table table)
		{
			for (int row = 0; row < table.Rows.Count; row++)
			{
				for (int cell = 0; cell < table.Rows[row].Cells.Count; cell++)
				{
					var _cell = table.Rows[row].Cells[cell];
					var res = _cell.GetCalculate(table);
					if (string.IsNullOrEmpty(res))
					{
						Console.Write($"[{Cell.GetCharFromNumber(cell)}{row}]\t");
					}
					else
						Console.Write($"{res}\t");
				}
				Console.WriteLine();
			}
		}
	}
}
