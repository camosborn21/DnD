using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Application.EntityStats.AbilityStats
{
	public class AbilityTemplate
	{
		public int Score { get; set; }
		public bool SavingThrowProficiency { get; set; }

		public AbilityTemplate()
		{
			
		}

		public AbilityTemplate(int score)
		{
			Score = score;
		}
		public int Modifier()
		{
			// ReSharper disable once PossibleLossOfFraction
			return (int) Math.Floor((double) ((Score-10)/2));
		}

		public int SavingThrow(int proficiencyBonus)
		{
			DiceBag dice = new DiceBag();
			int roll = dice.Roll_d20(false);
			roll += Modifier();
			if (SavingThrowProficiency)
			{
				roll += proficiencyBonus;
			}
			return roll;
		}

	}
}
