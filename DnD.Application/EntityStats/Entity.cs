using DnD.Application.EntityStats.AbilityStats;

namespace DnD.Application.EntityStats
{
	public class Entity
	{
		public int ArmorClass { get; set; }
		public int HitPoints { get; set; }
		public int CurrentHitPoints { get; set; }
		public int Speed { get; set; }
		public Strength Strength { get; set; }
		public Dexterity Dexterity { get; set; }
		public Constitution Constitution { get; set; }
		public Intelligence Intelligence { get; set; }
		public Wisdom Wisdom { get; set; }
		public Charisma Charisma { get; set; }

		public Entity()
		{
			Strength = new Strength();
			Dexterity = new Dexterity();
			Constitution = new Constitution();
			Intelligence = new Intelligence();
			Wisdom = new Wisdom();
			Charisma = new Charisma();
		}

		public Entity(int strength, int dex, int con, int intelligence,int wisdom, int charisma)
		{
			Strength = new Strength(){Score=strength};
			Dexterity = new Dexterity(){Score=dex};
			Constitution = new Constitution(){Score=con};
			Intelligence = new Intelligence(){Score=intelligence};
			Wisdom = new Wisdom(){Score=wisdom};
			Charisma = new Charisma(){Score=charisma};
		}

		public int Heal(int amount)
		{
			CurrentHitPoints += amount;
			if (CurrentHitPoints > HitPoints)
				CurrentHitPoints = HitPoints;
			return CurrentHitPoints;
		}

		public int Hit(int damage)
		{
			CurrentHitPoints -= damage;
			return CurrentHitPoints;
		}
	}
}
