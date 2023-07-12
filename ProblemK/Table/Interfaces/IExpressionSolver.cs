using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Interfaces
{
	/// <summary>
	/// Интерфейс для реализации вычисления выражений.
	/// В случаях если необходимо расширить функционал выражений, просто создаем новый класс и наследуем этот интерфейс.
	/// </summary>
	internal interface IExpressionSolver
	{
		public string Calculate(string expression);
	}
}
