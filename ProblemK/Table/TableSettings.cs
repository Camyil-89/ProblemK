using ProblemK.Table.Interfaces;
using ProblemK.Table.Validates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table
{
	internal class TableSettings
	{
		public IExpressionSolver ExpressionSolver { get; set; } = new ExpressionSolver();
		public IValidate ValidateManager { get; set; } = new SimpleValidate();
	}
}
