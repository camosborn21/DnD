using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnD.Application;
using DnD.Application.EntityStats;
using DnD.Application.EntityStats.AbilityStats;
using DnD.Application.Game;

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
			Character kethra = new Character(19, 16, 16, 14, 14, 9)
			{
				Name = "Kethra",
				Race = "Human",
				Alignment = "Neutral",
				ArmorClass = 14,
				Class = "Rouge: Thief",
				Speed = 30,
				ProficiencyBonus = 3,
				HitPoints = 40,
				ExperiencePoints = 6500
			};
			//Act
			game.LoadGame(@"C:\Users\camos\Documents\D&D\Characters.xml");

			//Assert
			Assert.AreEqual("Talen Il'Marin", game.CharacterManager.Characters[0].Name);
			
		

		}
	}
}
