using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Datas
{
	internal class DataNumber : IData
	{
		public string Data { get; set; }

		public string Calculate(Table table, IExpressionSolver expressionSolver = null)
		{
			if (int.TryParse(Data, out _))
			{
				return Data;
			}
			else
				return $"#НЕЧИСЛО";
		}

		public string GetString()
		{
			return $"{Data}";
		}
	}
}
