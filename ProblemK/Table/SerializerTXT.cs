using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table
{
	internal class SerializerTXT : ISerialize
	{
		public Table Deserialize(string path, TableSettings settings)
		{
			return DeserializeFromText(File.ReadAllText(path),settings);
		}

		public Table Deserialize(Stream stream, TableSettings settings)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return DeserializeFromText(Encoding.UTF8.GetString(array), settings);
		}
		public void Serialize(Table table, string path)
		{
			using (FileStream fileStream = new FileStream(path, FileMode.Create))
			{
				fileStream.Write(Encoding.UTF8.GetBytes(SerializeToText(table)));
			}
		}

		public Table DeserializeFromText(string text, TableSettings settings)
		{
			var rows = text.Split("\n");
			Table table = new Table(0, 0, new TableSettings());
			table.Rows.Clear();
			foreach (var row in rows)
			{
				Row row1 = new Row();
				foreach (var col in row.Split("\t"))
				{
					var cel = new Cell(settings.ExpressionSolver, settings.ValidateManager);
					cel.Write(col);
					row1.Cells.Add(cel);
				}
				table.AddRow(row1);
			}
			return table;
		}

		public string SerializeToText(Table table)
		{
			var data = "";
			foreach (var row in table.Rows)
			{
				var line = "";
				foreach (var col in row.Cells)
				{
					line += $"{col.Data.GetString()}\t";
				}
				data += $"{line.TrimEnd('\t')}\n";
			}
			return data.TrimEnd('\n');
		}
	}
}
