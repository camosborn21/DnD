using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.EntityStats.AbilityStats
{
	public class Intelligence : AbilityTemplate
	{
		public Skill Arcana { get; set; }
		public Skill History { get; set; }
		public Skill Investigation { get; set; }
		public Skill Nature { get; set; }
		public Skill Religion { get; set; }

		public Intelligence()
		{
			Arcana = new Skill();
			History = new Skill();
			Investigation = new Skill();
			Nature = new Skill();
			Religion = new Skill();
		}
	}
}
