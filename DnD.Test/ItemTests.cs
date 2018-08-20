using System;
using DnD.Application.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnD.Test
{
	[TestClass]
	public class ItemTests
	{
		[TestMethod]
		public void ConvertCoinPurseToGold()
		{
			CoinPurse coins = new CoinPurse
			{
				Copper = 3245,
				Silver = 170,
				Electrum = 28,
				Gold = 1800,
				Platinum = 30
			};

			double result = coins.GetValueInGold();

			Assert.AreEqual(2163.45,result);
		}
	}
}
