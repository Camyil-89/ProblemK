using ProblemK.Table.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProblemK.Table
{
	internal class Table
	{
		public List<Row> Rows { get; set; } = new List<Row>();
		private TableSettings TableSettingsSettings { get; set; }
		public Table(int width, int height, TableSettings tableSettingsSettings)
		{
			TableSettingsSettings = tableSettingsSettings;
			CreateTable(width, height);
		}
		public void CreateTable(int width, int height)
		{
			if (width > 26 || height > 26)
				throw new ArgumentException("Не реализована обработка размера больше 26!");
			Clear();
			for (int row = 0; row < height; row++)
			{
				var x = new Row();
				for (int cell = 0; cell < width; cell++)
				{
					x.Cells.Add(new Cell(TableSettingsSettings.ExpressionSolver, TableSettingsSettings.ValidateManager));
				}
				Rows.Add(x);
			}
		}
		public void Clear()
		{
			Rows.Clear();
		}
		public void AddRow(Row row)
		{
			Rows.Add(row);
		}
		public bool Validate(string text)
		{
			if (TableSettingsSettings.ValidateManager == null)
				return true;
			else
				return TableSettingsSettings.ValidateManager.Validate(text);
		}
	}
}
