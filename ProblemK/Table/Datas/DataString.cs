using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Datas
{
	internal class DataString : IData
	{
		public string Data = string.Empty;
		public string Calculate(Table table, IExpressionSolver expressionSolver = null)
		{
			return Data;
		}

		public string GetString()
		{
			return $"'{Data}";
		}
	}
}
