using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Interfaces
{
	/// <summary>
	/// Интерфейс для вывода таблицы или загрузки таблицы.
	/// </summary>
	internal interface ISerialize
	{
		public void Serialize(Table table);
		public Table Deserialize(string path);
		public Table Deserialize(Stream stream);
	}
}
