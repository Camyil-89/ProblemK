using ProblemK.Table.Datas;
using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table
{
	internal class Cell
	{
		public IData Data { get; private set; } = new DataString();
		public IExpressionSolver ExpressionSolver { get; set; }
		public IValidate ValidateManager { get; set; }
		public Cell(IExpressionSolver expressionSolver, IValidate validateManager)
		{
			ExpressionSolver = expressionSolver;
			ValidateManager = validateManager;
		}

		public void Write(string str)
		{
			if (string.IsNullOrEmpty(str))
				return;
			if (ValidateManager != null && ValidateManager.Validate(str) == false)
			{
				throw new Exception("Ошибка валидации!");
			}
			if (str[0] == '\'')
			{
				Data = new DataString() { Data = string.Join("", str.Skip(1)) };
			}
			else if (str[0] == '=')
			{
				Data = new DataCell() { Data = string.Join("", str.Skip(1)) };
			}
			else
			{
				Data = new DataNumber() { Data = str};
			}
		}
		public string GetWithoutCalculate()
		{
			return Data.GetString();
		}
		public string GetCalculate(Table table)
		{
			return Data.Calculate(table, ExpressionSolver);
		}
		/// <summary>
		/// Получение строки из числа, для удобного выбора ячейки.
		/// Для упращения было заложено что количество столбцов не больше 26 (A-Z).
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static string GetCharFromNumber(int number)
		{
			return $"{(char)('A' + number)}";
		}
		/// <summary>
		/// Получение позиции из строки вида "A0", "A12".
		/// не предпологается что передадут строку вида "AA0"
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static int[] GetNumberFromChar(string str)
		{
			return new int[2] { int.Parse(string.Join("", str.Skip(1))), (int)str[0] - 65 };
		}
	}
}
