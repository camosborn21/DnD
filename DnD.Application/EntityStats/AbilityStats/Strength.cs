using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.EntityStats.AbilityStats
{
	public class Strength : AbilityTemplate
	{
		public Skill Athletics { get; set; }

		public Strength()
		{
			Athletics = new Skill();
		}
	}
}
