using System;
using System.Linq;
using DnD.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnD.Test
{
	[TestClass]
	public class DiceBagTests
	{
		[TestMethod]
		public void TestRollD20()
		{
			DiceBag dice = new DiceBag();
			int result = dice.Roll_d20(false);

			Assert.IsTrue(Enumerable.Range(1, 20).Contains(result));
		}

		[TestMethod]
		public void TestRollWithAdvantage()
		{
			DiceBag dice = new DiceBag();
			int result = dice.Roll_d20(true);

			Assert.IsTrue(Enumerable.Range(1, 20).Contains(result));
		}

		[TestMethod]
		public void TestRollPercentage()
		{
			DiceBag dice = new DiceBag();
			int result = dice.Roll_Percent();

			Assert.IsTrue(Enumerable.Range(1, 100).Contains(result));
		}

		[TestMethod]
		public void TestRollEach()
		{
			DiceBag dice = new DiceBag();
			int[] sides = { 2, 3, 4, 6, 8, 10, 12 };
			foreach (int side in sides)
			{
				for (int i =1; i < 6; i++)
				{
					Console.WriteLine($"Rolling {i}d{side}");
					var result = dice.Roll(i, side);
					Assert.IsTrue(Enumerable.Range(i, side*i).Contains(result));
				}

			}

		}

		[TestMethod]
		public void TestRollCharacterCreation()
		{
			DiceBag dice = new DiceBag();
			int[] results = dice.RollCharacterCreation();
			foreach (var result in results)
			{
				Assert.IsTrue(Enumerable.Range(3,18).Contains(result));
			}

		}
	}
}
