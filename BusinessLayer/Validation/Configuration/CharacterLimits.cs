using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.Configuration
{
	internal static class CharacterLimits
	{
		// 32
		public static readonly int Word1 =
			Convert.ToInt32(Math.Pow(2, 5));

		// 64
		public static readonly int Line1 =
			Convert.ToInt32(Math.Pow(2, 6));

		// 128
		public static readonly int Line2 =
			Convert.ToInt32(Math.Pow(2, 7));

		// 256 - nvarchar(256)
		public static readonly int Paragraph1 =
			Convert.ToInt32(Math.Pow(2, 8));

		// 512
		public static readonly int Paragraph2 =
			Convert.ToInt32(Math.Pow(2, 9));

		// 1.024
		public static readonly int Paragraph4 =
			Convert.ToInt32(Math.Pow(2, 10));

		// 2.048 - 2 kb
		public static readonly int Page1 =
			Convert.ToInt32(Math.Pow(2, 11));

		// 4.096
		public static readonly int Page2 =
			Convert.ToInt32(Math.Pow(2, 12));

		// 8.192
		public static readonly int Page4 =
			Convert.ToInt32(Math.Pow(2, 13));

		// 16.384
		public static readonly int Page8 =
			Convert.ToInt32(Math.Pow(2, 14));

		// 32.768 - 32 kb - 16 pages
		public static readonly int Chapter1 =
			Convert.ToInt32(Math.Pow(2, 15));

		/*
		// 65.536
		public static readonly int Chapter2 =
			Convert.ToInt32(Math.Pow(2, 16));

		// 131.072
		public static readonly int Chapter4 =
				  Convert.ToInt32(Math.Pow(2, 17));

		// 262.144
		public static readonly int Chapter8 =
				  Convert.ToInt32(Math.Pow(2, 18));

		// 524.288
		public static readonly int Chapter16 =
				  Convert.ToInt32(Math.Pow(2, 19));
		*/

		// 1.048.576 - 1 mb - 32 chapters
		public static readonly int Book1 =
			Convert.ToInt32(Math.Pow(2, 20));

		/*
		// 2.097.152
		public static readonly int Book2 =
				  Convert.ToInt32(Math.Pow(2, 21));

		// 4.194.304
		public static readonly int Book4 =
				  Convert.ToInt32(Math.Pow(2, 22));

		// 8.388.608
		public static readonly int Book8 =
				  Convert.ToInt32(Math.Pow(2, 23));

		// 16.777.216
		public static readonly int Book16 =
				  Convert.ToInt32(Math.Pow(2, 24));

		// 33.554.432
		public static readonly int Book32 =
				  Convert.ToInt32(Math.Pow(2, 25));
		*/

		/*
		public static readonly int Shelf1 = 
            Convert.ToInt32(Math.Pow(2,26)); // 67.108.864

		public static readonly int Shelf2 = 
            Convert.ToInt32(Math.Pow(2,27)); // 134.217.728

		public static readonly int Shelf4 = 
            Convert.ToInt32(Math.Pow(2,28)); // 268.435.456

		public static readonly int Shelf8 = 
            Convert.ToInt32(Math.Pow(2,29)); // 536.870.912

		public static readonly int Shelf16 = 
            Convert.ToInt32(Math.Pow(2,30)); // 1.073.741.824
        */

		// 2.147.483.648 - nvarchar(max) - 2 gb - 2048 books
		public static readonly int Library1 =
			Convert.ToInt32(Math.Pow(2, 31) - 1);
	}
}
