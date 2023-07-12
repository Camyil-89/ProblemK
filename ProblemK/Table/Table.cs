using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table
{
	internal class Table
	{
		public List<Row> Rows { get; set; } = new List<Row>();
		public IExpressionSolver ExpressionSolver { get; set; }
		public Table(int width, int height, IExpressionSolver expressionSolver)
		{
			if (width > 26 || height > 26)
				throw new ArgumentException("Не реализована обработка размера больше 26!");
			for (int row = 0; row < height; row++)
			{
				var x = new Row();
				for (int cell = 0; cell < width; cell++)
				{
					x.Cells.Add(new Cell());
				}
				Rows.Add(x);
			}
			ExpressionSolver = expressionSolver;
		}
	}
}
