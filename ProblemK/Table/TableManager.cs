using ProblemK.Table.Interfaces;
using ProblemK.Table.Validates;
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
			return Create(5, 5);
		}

		public Table Create(int width, int height)
		{
			return Create(width, height, new TableSettings());
		}


		public Table Create(int width, int height, TableSettings settings)
		{
			return new Table(width, height, settings);
		}
	}
}
