using System;

namespace twL
{
	public class Misc
	{
		public static void bubble_sort_generic<T>(T[] array) where T : IComparable
		{
			long right_border = array.Length - 1;

			do
			{
				long last_exchange = 0;

				for (long i = 0; i < right_border; i++)
				{
					if (array[i].CompareTo(array[i + 1]) > 0)
					{
						T temp = array[i];
						array[i] = array[i + 1];
						array[i + 1] = temp;

						last_exchange = i;
					}
				}

				right_border = last_exchange;
			} while (right_border > 0);
		}
	}
}