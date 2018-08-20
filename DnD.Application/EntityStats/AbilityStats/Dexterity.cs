using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.EntityStats.AbilityStats
{
	public class Dexterity : AbilityTemplate
	{
		public Skill Acrobatics { get; set; }
		public Skill SleightOfHand { get; set; }
		public Skill Stealth { get; set; }

		public Dexterity()
		{
			Acrobatics = new Skill();
			SleightOfHand = new Skill();
			Stealth = new Skill();
		}

	}
}
