using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Application.Effects;

namespace DnD.Application.Items
{
	public class Ammunition
	{
		public string Name { get; set; }
		public string AmmunitionType { get; set; }
		public int Quantity { get; set; }		
		public List<Damage> Damages { get; set; }

		public Ammunition()
		{
			Damages = new List<Damage>();
		}
	}
}
