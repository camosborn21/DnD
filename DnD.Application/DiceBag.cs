using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application
{
	public class DiceBag
	{
		public int Roll(int quantity, int sides)
		{
			Random r = new Random();
			int total = 0;
			for (int i = 0; i < quantity; i++)
			{
				int temp = r.Next(1, sides + 1);
				Console.WriteLine("{0}. Rolled a {1}", i + 1, temp);
				total += temp;
			}
			if (quantity > 1)
				Console.WriteLine("Total ({0}d{1}): {2}", quantity, sides, total);

			return total;
		}

		public int Roll_d20(bool withAdvantage)
		{
			Random r = new Random();
			int temp = r.Next(1, 21);
			int second = r.Next(1, 21);
			if (!withAdvantage)
			{
				Console.WriteLine("Rolled a {0}", temp);
				return temp;
			}
			Console.WriteLine("First roll: {0}",temp);
			Console.WriteLine("Second roll: {0}", second);
			return Math.Max(temp, second);
		}

		public int Roll_Percent()
		{
			int result = new Random().Next(1,101);
			Console.WriteLine("Percent rolled: {0}",result);
			return result;
		}

		public int[] RollCharacterCreation()
		{
			Random r = new Random();
			int[] allStats = new int[7];
			DiceBag dice = new DiceBag();
			for (int i = 0; i < 7; i++)
			{
				Console.WriteLine("Rolling for stat {0} out of 6", i + 1);
				int[] stat = new int[4];
				for (int x = 0; x < 4; x++)
				{
					int temp = r.Next(1, 6);
					Console.WriteLine("-->Roll {0} is {1}", x + 1, temp);
					stat[x] = temp;
				}
				int totalForStat = stat.Sum() - stat.Min();
				allStats[i] = totalForStat;
				Console.WriteLine("-->Total: {0}", totalForStat);
			}
			Array.Sort(allStats);
			Console.WriteLine("Your character creation rolls are: ");
			int s = 0;
			foreach (var stat in allStats)
			{

				Console.Write(stat.ToString());
				s++;
				if (s > 0 && s < 7)
					Console.Write(", ");

			}
			return allStats;
		}
	}
}
