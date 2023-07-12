using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Interfaces
{
	/// <summary>
	/// Интерфейс для создания фабрики таблиц
	/// </summary>
	internal interface ITableManager
	{
		public Table Create();
		public Table Create(int width, int height);
		public Table Create(int width, int height, TableSettings settings);
	}
}
