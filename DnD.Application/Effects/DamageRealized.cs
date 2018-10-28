using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.Effects
{
	public class DamageRealized
	{
		public List<Damage> Damages { get; set; }
		public int TotalDamage { get; private set; }
		public string DamageDescription { get; private set; }
		public DamageRealized()
		{
			Damages = new List<Damage>();
		}

		public void ResolveDamage()
		{
			foreach (var damage in Damages)
			{
				int damageAmount = damage.RollDamage();
				TotalDamage += damageAmount;
				if (DamageDescription == null)
				{
					DamageDescription = $"{damageAmount} {damage.DamageType} damage";
				}
				else
				{
					DamageDescription += $"; {damageAmount} {damage.DamageType} damage";
				}
			}
		}

	}
}
