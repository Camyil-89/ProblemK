using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Datas
{
	internal class DataCell : IData
	{
		/// <summary>
		/// В Data может быть только ссылка на другую ячейку или ссылка вместе с выражением которое содержит цифры, все остальное не валидно.
		/// </summary>
		public string Data;
		public string Calculate(IExpressionSolver expressionSolver)
		{
			
			try
			{
				if (CheckSelfreference(Data))
				{
					return "#ССЫЛКАНАСЕБЯ";
				}
				if (Data.IndexOfAny(new char[] { '+', '-', '*', '/' }) == -1)
				{
					var pos = Cell.GetNumberFromChar(Data);
					var cell = Program.Table.Rows[pos[0]].Cells[pos[1]];
					return cell.GetCalculate();
				}
				var data = Data;
				var tmp = Data.Replace("+", ",").Replace("-", ",").Replace("*", ",").Replace("/", ",").Split(",");
				foreach (var i in tmp)
				{
					try
					{
						var pos = Cell.GetNumberFromChar(i);
						var cell = Program.Table.Rows[pos[0]].Cells[pos[1]];
						data = data.Replace(i, cell.GetCalculate());
					}
					catch { }
				}
				return expressionSolver.Calculate(data);
			}
			catch { return "#НЕВЫРАЖЕНИЕ"; }
		}

		public string GetString()
		{
			return Data;
		}
		/// <summary>
		/// Проверка на то, чтобы ячейки не ссылались друг на друга по типу A0 -> A1 - > A0, такого быть не должно.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private bool CheckSelfreference(string data)
		{
			var tmp = data.Replace("+", ",").Replace("-", ",").Replace("*", ",").Replace("/", ",").Split(",");
			foreach (var i in tmp)
			{
				try
				{
					var pos = Cell.GetNumberFromChar(i);
					var cell = Program.Table.Rows[pos[0]].Cells[pos[1]];
					if (cell.Data.GetString() == Data)
						return true;
					return CheckSelfreference(cell.Data.GetString());
				}
				catch { }
			}
			return false;
		}
	}
}
