using ProblemK.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemK.Table.Validates
{
	internal class SimpleValidate : IValidate
	{
		public bool Validate(string text)
		{
			return text.IndexOfAny(new char[] { ';', '\t' }) == -1;
		}
	}
}
