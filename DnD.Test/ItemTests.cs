using System;
using DnD.Application.Effects;
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

		[TestMethod]
		public void TestWeaponDamage()
		{
			Weapon shortSword = new Weapon
			{
				Name = "Short Sword",
				WeaponType = "Martial Melee",
				Weight = 2,
				Cost = new CoinPurse() { Gold=10},
				Properties = new []{"Finesse","light"}
			};
			shortSword.WeaponDamages.Add(new Damage()
			{
				DamageType = "piercing",
				DefaultDamage = 3,
				QuantityOfDice = 1,
				SidesOfDice = 6
			});

			DamageRealized attack = shortSword.WeaponHit();
			Console.WriteLine(attack.DamageDescription);
		}

		[TestMethod]
		public void TestRangedWeaponAttack()
		{
			RangedWeapon longBow = new RangedWeapon()
			{
				Name = "Longbow"
				,WeaponType = "Martial Ranged",
				AmmunitionType = "Arrow",
				CloseRange = 150,
				MaxRange = 600,
				Cost=new CoinPurse() { Gold=50},
				Weight = 2,
				Properties = new []{"heavy","two-handed"}
			};
			longBow.WeaponDamages.Add(new Damage()
			{
				DefaultDamage = 4,
				QuantityOfDice = 2,
				SidesOfDice = 8,
				DamageType = "piercing"
			});
			Ammunition basicArrows = new Ammunition()
			{
				AmmunitionType = "Arrow",
				Name = "Basic Arrows",
				Quantity = 20
			};
			DamageRealized attack = longBow.WeaponHit(ref basicArrows);
			Console.WriteLine(attack.DamageDescription);
			Assert.AreEqual(19,basicArrows.Quantity);
		}

		[TestMethod]
		public void TestRangedWeaponAttackSpecialAmmo()
		{
			RangedWeapon longBow = new RangedWeapon()
			{
				Name = "Longbow"
				,
				WeaponType = "Martial Ranged",
				AmmunitionType = "Arrow",
				CloseRange = 150,
				MaxRange = 600,
				Cost = new CoinPurse() { Gold = 50 },
				Weight = 2,
				Properties = new[] { "heavy", "two-handed" }
			};
			longBow.WeaponDamages.Add(new Damage()
			{
				DefaultDamage = 4,
				QuantityOfDice = 2,
				SidesOfDice = 8,
				DamageType = "piercing"
			});
			Ammunition fireArrows = new Ammunition()
			{
				AmmunitionType = "Arrow",
				Name = "Fire Arrows",
				Quantity = 20
			};

			fireArrows.Damages.Add(new Damage()
			{
				DamageType = "fire",
				DefaultDamage = 5,
				QuantityOfDice = 1,
				SidesOfDice = 10
					
			});
			DamageRealized attack = longBow.WeaponHit(ref fireArrows);
			Console.WriteLine(attack.DamageDescription);
			Assert.AreEqual(19, fireArrows.Quantity);
		}
	}
}
