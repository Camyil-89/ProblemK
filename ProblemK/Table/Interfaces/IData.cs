using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Interfaces
{
	/// <summary>
	/// Интерфейст для взаимодействия с разными типами данных в ячейке
	/// Если необходимо расширить функционал создаем новый класс и наследуем данный интерфейс и пишем свою реализацию вычисления.
	/// </summary>
	internal interface IData
	{
		public string Calculate(Table table, IExpressionSolver expressionSolver = null);
		public string GetString();
	}

}
