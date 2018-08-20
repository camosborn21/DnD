using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.Items
{
	public class CoinPurse
	{
		public int Copper { get; set; }
		public int Silver { get; set; }
		public int Electrum { get; set; }
		public int Gold { get; set; }
		public int Platinum { get; set; }

		public double GetValueInGold()
		{
			return (double)Copper / 100 + (double)Silver / 10 + (double)Electrum / 2 + Gold + Platinum * 10;
		}
	}
}
