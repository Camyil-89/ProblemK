using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Interfaces
{
	/// <summary>
	/// Интерфейст для взаимодействия с разными типами данных в ячейке
	/// </summary>
	internal interface IData
	{
		public string Calculate(IExpressionSolver expressionSolver = null);
		public string GetString();
	}

}
