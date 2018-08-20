using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.EntityStats.AbilityStats
{
	public class Charisma : AbilityTemplate
	{
		public Skill Deception { get; set; }
		public Skill Intimidation { get; set; }
		public Skill Performance { get; set; }
		public Skill Persuasion { get; set; }

		public Charisma()
		{
			Deception = new Skill();
			Intimidation = new Skill();
			Performance = new Skill();
			Persuasion = new Skill();
		}
	}
}
