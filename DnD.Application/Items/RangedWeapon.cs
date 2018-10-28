using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Application.Effects;

namespace DnD.Application.Items
{
	public class RangedWeapon : Weapon
	{
		public int CloseRange { get; set; }
		public int MaxRange { get; set; }
		public string AmmunitionType { get; set; }
		public DamageRealized  WeaponHit(ref Ammunition ammo)
		{
			ammo.Quantity -= 1;
			DamageRealized result = new DamageRealized();
			foreach (var weaponDamage in WeaponDamages)
			{
				result.Damages.Add(weaponDamage);
			}
			foreach (var ammoDamage in ammo.Damages)
			{
				result.Damages.Add(ammoDamage);
			}
			result.ResolveDamage();
			return result;
		}

	}
}
