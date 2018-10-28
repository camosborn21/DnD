using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.Effects
{
	public class Damage
	{
		public string DamageType { get; set; }
		public int QuantityOfDice { get; set; }
		public int SidesOfDice { get; set; }
		public int DefaultDamage { get; set; }

		public int RollDamage()
		{
			return new DiceBag().Roll(QuantityOfDice,SidesOfDice);
		}

	}
}
