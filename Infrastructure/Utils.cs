using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace JustEng.Infrastructure
{
	public static class Utils
	{
		public static void Shuffle<T>(this List<T> list, Random rng)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				(list[k], list[n]) = (list[n], list[k]);
			}
		}
	}
}
