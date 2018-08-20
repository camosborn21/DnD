using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.EntityStats.AbilityStats
{
	public class Skill
	{
		
		public bool Proficiency { get; set; }
	
		public int Check(int modifier, int proficiencyBonus)
		{
			DiceBag dice = new DiceBag();
			int roll = dice.Roll_d20(false);
			roll += modifier;
			if (Proficiency)
				roll += proficiencyBonus;

			return roll;
		}
	}
}
