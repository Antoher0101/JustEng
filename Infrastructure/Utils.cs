using System;

namespace JustEng.Infrastructure
{
	public static class Utils
	{
		public static void Shuffle<T>(this Random rng, T[] array)
		{
			int n = array.Length;
			while (n > 1)
			{
				int k = rng.Next(n--);
				(array[n], array[k]) = (array[k], array[n]);
			}
		}
	}
}
