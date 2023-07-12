using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table
{
	internal class ExpressionSolver : IExpressionSolver
	{
		public string Calculate(string expression)
		{
			return new DataTable().Compute(expression, null).ToString();
		}
	}
}
