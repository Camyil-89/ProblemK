using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Interfaces
{
	/// <summary>
	/// Интерфейс для реализации вычисления выражений.
	/// </summary>
	internal interface IExpressionSolver
	{
		public string Calculate(string expression);
	}
}
