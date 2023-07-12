using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table
{
	internal class TableManager: ITableManager
	{
		/// <summary>
		/// создает 5 на 5 таблицу.
		/// </summary>
		/// <returns></returns>
		public Table Create()
		{
			return new Table(5, 5, new ExpressionSolver());
		}

		public Table Create(int width, int height)
		{
			return new Table(width, height, new ExpressionSolver());
		}

		public Table Create(int width, int height, IExpressionSolver solver)
		{
			return new Table(width, height, solver);
		}
	}
}
