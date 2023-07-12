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
		public string SerializeToText(Table table);
		public Table DeserializeFromText(string text, TableSettings settings);
		public void Serialize(Table table, string path);
		public Table Deserialize(string path, TableSettings settings);
		public Table Deserialize(Stream stream, TableSettings settings);
	}
}
