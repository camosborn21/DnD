using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Application.Effects;

namespace DnD.Application.Items
{
	public class Weapon
	{
		public string Name { get; set; }
		public string WeaponType { get; set; }
		public string[] Properties { get; set; }
		public CoinPurse Cost { get; set; }
		public int Weight { get; set; }
		public List<Damage> WeaponDamages { get; set; }

		public Weapon()
		{
			WeaponDamages = new List<Damage>();
			Cost = new CoinPurse();
		}

		public  DamageRealized WeaponHit()
		{
			DamageRealized result = new DamageRealized();
			foreach (var weaponDamage in WeaponDamages)
			{
				result.Damages.Add(weaponDamage);
			}
			result.ResolveDamage();
			return result;
		}
	}
}
