using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
	internal static class ASCIICodes
	{
		public static readonly List<int> Lowercases = new List<int>();
		public static readonly List<int> Uppercases = new List<int>();
		public static readonly List<int> Digits = new List<int>();
		public static readonly List<int> AlphaNumerics = new List<int>();
		public static readonly List<int> NonAlphaNumerics = new List<int>();
		public static readonly List<int> Printables = new List<int>();
		
		static ASCIICodes()
		{
			for (int i = 33; i <= 126; ++i)
			{
				if (i >= 97 && i <= 122)
				{
					Lowercases.Add(i);
					AlphaNumerics.Add(i);
				}
				else if (i >= 65 && i <= 90)
				{
					Uppercases.Add(i);
					AlphaNumerics.Add(i);
				}
				else if (i >= 48 && i <= 57)
				{
					Digits.Add(i);
					AlphaNumerics.Add(i);
				}
				else
				{
					NonAlphaNumerics.Add(i);
				}

				Printables.Add(i);
			}
		}
	}
}
