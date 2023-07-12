using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Interfaces
{
	/// <summary>
	/// Интерфейс для валидации данных которые записываются в ячейку
	/// </summary>
	internal interface IValidate
	{
		public bool Validate(string text);
	}
}
