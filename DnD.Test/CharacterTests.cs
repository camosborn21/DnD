using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnD.Application;
using DnD.Application.Effects;
using DnD.Application.EntityStats;
using DnD.Application.EntityStats.AbilityStats;
using DnD.Application.Game;
using DnD.Application.Items;

namespace DnD.Test
{
	[TestClass]
	public class CharacterTests
	{
		[TestMethod]
		public void TestCreate()
		{
			Character character = new Character {Alignment = "Lawful Good"};
			Assert.AreEqual("Lawful Good", character.Alignment);
		}

		[TestMethod]
		public void TestHeal()
		{
			//Arrange
			Character character = new Character(){HitPoints = 37,CurrentHitPoints = 15};

			//Act:Assert 1
			character.Heal(15);
			Assert.AreEqual(30,character.CurrentHitPoints);

			//Act:Assert 2
			character.Heal(15);
			Assert.AreEqual(37, character.CurrentHitPoints);
		}

		[TestMethod]
		public void TestHit()
		{
			Character character = new Character(){HitPoints = 37,CurrentHitPoints = 37};
			
			//Act
			character.Hit(15);

			//Assert
			Assert.AreEqual(22,character.CurrentHitPoints);
		}

		[TestMethod]
		public void TestModifierCalculation()
		{
			//Arrange
			Character talen = new Character(10, 17, 13, 15, 12, 8);


			//Assert
			Assert.AreEqual(0,talen.Strength.Modifier());
			Assert.AreEqual(3, talen.Dexterity.Modifier());
			Assert.AreEqual(1, talen.Constitution.Modifier());
			Assert.AreEqual(2, talen.Intelligence.Modifier());
			Assert.AreEqual(1, talen.Wisdom.Modifier());
			Assert.AreEqual(-1, talen.Charisma.Modifier());
		}

		[TestMethod]
		public void TestSavingThrowCalculation()
		{
			//Arrange
			Character talen = new Character(10, 17, 13, 15, 12, 8){ProficiencyBonus = 3};
			talen.Dexterity.SavingThrowProficiency = true;

			//Assert
			Assert.AreEqual(6,talen.Dexterity.Modifier() + talen.ProficiencyBonus);
		}

		[TestMethod]
		public void TestNewWeapon()
		{
			RangedWeapon longBow=new RangedWeapon(){Name = "Longbow"};
			longBow.WeaponDamages.Add(new Damage()
			{
				DefaultDamage = 4,
				QuantityOfDice = 1,
				SidesOfDice = 8,
				DamageType = "Piercing"
			});
			Character talen = new Character(10, 17, 13, 15, 12, 8)
			{
				Alignment = "Neutral",
				Name = "Talen Il'Marin",
				ArmorClass = 15,
				Class = "Ranger: Horizon Walker",
				HitPoints = 39,
				CurrentHitPoints = 39,
				Race = "High Elf",
				ProficiencyBonus = 3,
				Speed = 30,
				ExperiencePoints = 6500
			};
			talen.Weapons.Add(longBow);

			Assert.AreEqual(1,talen.Weapons.Count);
		}

		[TestMethod]
		public void TestAttack()
		{

			Character talen = new Character(10, 17, 13, 15, 12, 8)
			{
				Alignment = "Neutral",
				Name = "Talen Il'Marin",
				ArmorClass = 15,
				Class = "Ranger: Horizon Walker",
				HitPoints = 39,
				CurrentHitPoints = 39,
				Race = "High Elf",
				ProficiencyBonus = 3,
				Speed = 30,
				ExperiencePoints = 6500
			};
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
				QuantityOfDice = 1,
				SidesOfDice = 8,
				DamageType = "Piercing"
			});			
			Ammunition arrows = new Ammunition() { AmmunitionType = "Arrow", Name = "Special Arrow", Quantity = 20 };
			arrows.Damages.Add(new Damage()
			{
				DamageType = "force",
				QuantityOfDice = 1,
				SidesOfDice = 8
			});
			talen.Weapons.Add(longBow);
			talen.Ammunition.Add(arrows);
			var ammo = talen.Ammunition.ElementAt(0);
			DamageRealized attack = ((RangedWeapon)talen.Weapons.ElementAt(0)).WeaponHit(ref ammo);
			Console.WriteLine(attack.DamageDescription);


		}

		[TestMethod]
		public void TestSave()
		{
			Character talen = new Character(10,17,13,15,12,8)
			{
				Alignment = "Neutral",
				Name = "Talen Il'Marin",
				ArmorClass = 15,
				Class = "Ranger: Horizon Walker",
				HitPoints = 39,
				CurrentHitPoints = 39,
				Race = "High Elf",
				ProficiencyBonus = 3,
				Speed = 30,
				ExperiencePoints = 6500
			};
			Character kethra = new Character(19,16,16,14,14,9)
			{
				Name = "Kethra",
				Race = "Human",
				Alignment = "Neutral",
				ArmorClass = 14,
				Class = "Rouge: Thief",
				Speed = 30,
				ProficiencyBonus = 3,
				HitPoints = 40,
				CurrentHitPoints = 40,
				ExperiencePoints = 6500
			};
			RangedWeapon longBow = new RangedWeapon()
			{
				Name = "Longbow",
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
				QuantityOfDice = 1,
				SidesOfDice = 8,
				DamageType = "Piercing"
			});
			Weapon rapier = new Weapon()
				{
					Name = "Rapier",
					WeaponType = "Martial Melee",
					Cost = new CoinPurse() { Gold = 25},
					Weight = 2,
					Properties = new []{"finesse"}

				};
			rapier.WeaponDamages.Add(new Damage()
			{
				DamageType = "piercing",
				QuantityOfDice = 1,
				SidesOfDice = 8
			});
			Ammunition arrows = new Ammunition() { AmmunitionType = "Arrow", Name = "Special Arrow", Quantity = 20 };
			arrows.Damages.Add(new Damage()
			{
				DamageType = "force",
				QuantityOfDice = 1,
				SidesOfDice = 8
			});
			talen.Weapons.Add(longBow);
			talen.Ammunition.Add(arrows);
			kethra.Weapons.Add(rapier);
			GameManager game = new GameManager();
			game.CharacterManager.AddCharacter(talen);
			game.CharacterManager.AddCharacter(kethra);
			game.SaveGame(@"C:\Users\camos\Documents\D&D\Characters.xml");

			
		}

		[TestMethod]
		public void TestLoad()
		{
			//Arrange
			GameManager game = new GameManager();

			//Act
			game.LoadGame(@"C:\Users\camos\Documents\D&D\Characters.xml");

			//Assert
			Assert.AreEqual("Talen Il'Marin", game.CharacterManager.Characters[0].Name);
			Assert.AreEqual(1,game.CharacterManager.Characters[0].Weapons.Count);
		

		}
	}
}
