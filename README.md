# ProblemK

Решение задачи (https://wiki.haskell.org/Ru/Problem_K).


## Вывод в консоль тестовых таблиц.
![image](https://github.com/Camyil-89/ProblemK/assets/76705837/3458c860-4b14-4822-808f-3ad87f63c3d1)

## 
> Представьте, что это требования к первой фазе проекта. Необходимо реализовать
только то, что нужно на этой фазе. Однако, известно, что планируется вторая
фаза, в которой требования будут расширены следующими:
> - Расширить формулы операциями над строками,
> - Оптимизировать производительность для громадных таблиц.

### Оптимизировать производительность для громадных таблиц
1. Для начала, чтобы можно было создавать большие таблицы, необходимо переписать эти две функции. Они переводят формат ячеек из A0 в позицию в массиве вида X,Y.
```C#
public static string GetCharFromNumber(int number)
		{
			return $"{(char)('A' + number)}";
		}
		public static int[] GetNumberFromChar(string str)
		{
			return new int[2] { int.Parse(string.Join("", str.Skip(1))), (int)str[0] - 65 };
		}
```

2. Сделать динамическую подгрузку таблицы из файла, путем добавления в интерфейс ISerialize новых функций направленых на это.
```C#
public IEnumerable<Row> GetFromTop(string path, int start, int count);
```

3. Изменить способ создания таблиц. Не создавать все ячейки сразу. а добавлять их постепенно по мере нужды.
4. Сделать все вычисления в ячейках асинхронными.


### IExpressionSolver
Для реализации операций над строками необходимо будет создать новый класс наследуя интерфейс IExpressionSolver, в котором будет реализация работы со строками.
```C#
internal interface IExpressionSolver
	{
		public string Calculate(string expression);
	}
```
> Пример реализации. Тут используется DataTable для вычисления выражения. Так как главная задача стояла не в написании функционала для вычисления выражения, я использовал встроеные.
```C#
internal class ExpressionSolver : IExpressionSolver
	{
		public string Calculate(string expression)
		{
			return new DataTable().Compute(expression, null).ToString();
		}
	}
```

### IData
В случаях если необходима реализация нового типа ячеек (допустим для обработки выражения со строками), нужно создать новый класс наследуя интерфейс IData.
```C#
internal interface IData
	{
		public string Calculate(Table table, IExpressionSolver expressionSolver = null);
		public string GetString();
	}
```
> Пример реализации.
```C#
internal class DataCell : IData
	{
		public string Data { get; set; }
		public string Calculate(Table table, IExpressionSolver expressionSolver)
		{

			try
			{
				if (CheckSelfreference(table, Data))
				{
					return "#ССЫЛКАНАСЕБЯ";
				}
				if (Data.IndexOfAny(new char[] { '+', '-', '*', '/' }) == -1)
				{
					var pos = Cell.GetNumberFromChar(Data);
					var cell = table.Rows[pos[0]].Cells[pos[1]];
					return cell.GetCalculate(table);
				}
				var data = Data;
				var tmp = Data.Replace("+", ",").Replace("-", ",").Replace("*", ",").Replace("/", ",").Replace("=", "").Split(",");
				foreach (var i in tmp)
				{
					try
					{
						var pos = Cell.GetNumberFromChar(i);
						var cell = table.Rows[pos[0]].Cells[pos[1]];
						data = data.Replace(i, cell.GetCalculate(table));
					}
					catch { }
				}
				return expressionSolver.Calculate(data);
			}
			catch { return "#НЕВЫРАЖЕНИЕ"; }
		}

		public string GetString()
		{
			return $"={Data}";
		}
		private bool CheckSelfreference(Table table, string data)
		{
			var tmp = data.Replace("+", ",").Replace("-", ",").Replace("*", ",").Replace("/", ",").Replace("=", "").Split(",");
			foreach (var i in tmp)
			{
				Cell cell;
				try
				{
					var pos = Cell.GetNumberFromChar(i);
					cell = table.Rows[pos[0]].Cells[pos[1]];
				}
				catch { continue; }
				if (cell.Data.GetString() == GetString())
					return true;
				if (CheckSelfreference(table, cell.Data.GetString()))
					return true;
			}
			return false;
		}
	}
```
```C#
internal class DataNumber : IData
	{
		public string Data { get; set; }

		public string Calculate(Table table, IExpressionSolver expressionSolver = null)
		{
			if (int.TryParse(Data, out _))
			{
				return Data;
			}
			else
				return $"#НЕЧИСЛО";
		}

		public string GetString()
		{
			return $"{Data}";
		}
	}
```
```C#
internal class DataString : IData
	{
		public string Data = string.Empty;
		public string Calculate(Table table, IExpressionSolver expressionSolver = null)
		{
			return Data;
		}

		public string GetString()
		{
			return $"'{Data}";
		}
	}
```

### IValidate
Если нужна валидация вводимых данных, можно создать класс с наследованием интерфейса IValidate.
```C#
internal interface IValidate
	{
		public bool Validate(string text);
	}
```
> Пример реализации
```C#
internal class SimpleValidate : IValidate
	{
		public bool Validate(string text)
		{
			return text.IndexOfAny(new char[] { ';', '\t' }) == -1;
		}
	}
```

### ISerialize
Интерфейс ISerialize предназначен для сериализации и десериализации таблиц.
```C#
internal interface ISerialize
	{
		public string SerializeToText(Table table);
		public Table DeserializeFromText(string text, TableSettings settings);
		public void Serialize(Table table, string path);
		public Table Deserialize(string path, TableSettings settings);
		public Table Deserialize(Stream stream, TableSettings settings);
	}
```
> Пример реализации. Здесь сериализациия и десериализация происходит в .txt файл.
```C#
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
```

### ITableManager
ITableManager интерфейс для создания фабрики таблиц.
```C#
internal interface ITableManager
	{
		public Table Create();
		public Table Create(int width, int height);
		public Table Create(int width, int height, TableSettings settings);
	}
```
> Пример реализации.
```C#
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
```
