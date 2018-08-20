using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.EntityStats
{
	public class Creature : Entity
	{
		public string TypeName { get; set; }
		public Double ChallengeRating { get; set; }
		public int ExperienceGiven { get; set; }
	}
}
