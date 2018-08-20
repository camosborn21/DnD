using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.EntityStats.AbilityStats
{
	public class Wisdom : AbilityTemplate
	{
		public Skill AnimalHandling { get; set; }
		public Skill Insight { get; set; }
		public Skill Medicine { get; set; }
		public Skill Perception { get; set; }
		public Skill Survival { get; set; }

		public Wisdom()
		{
			AnimalHandling = new Skill();
			Insight = new Skill();
			Medicine = new Skill();
			Perception = new Skill();
			Survival = new Skill();
		}
	}
}
