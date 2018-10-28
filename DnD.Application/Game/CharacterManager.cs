using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DnD.Application.EntityStats;
using DnD.Application.Items;

namespace DnD.Application.Game
{
	[XmlRoot("CharacterList")]
	[XmlInclude(typeof(Character))]
	[XmlInclude(typeof(Weapon))]
	[XmlInclude(typeof(RangedWeapon))]
	[XmlInclude(typeof(Ammunition))]
	public class CharacterManager
	{
		[XmlArray("CharacterArray")]
		[XmlArrayItem("Character")]
		public List<Character> Characters = new List<Character>();

		[XmlElement("Listname")]
		public string Listname { get; set; }

		public CharacterManager()
		{
			
		}

		public CharacterManager(string name)
		{
			Listname = name;
		}

		public void AddCharacter(Character character)
		{
			Characters.Add(character);
		}
	}
}

