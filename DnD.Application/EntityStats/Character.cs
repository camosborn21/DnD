using System;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace DnD.Application.EntityStats
{
	//[XmlType("Character")]
	public class Character : Entity
	{
		//[XmlElement("Name")]
		public string Name { get; set; }

		//[XmlElement("Class")]
		public string Class { get; set; }

		//[XmlElement("Race")]
		public string Race { get; set; }

		//[XmlElement("Alignment")]
		public string Alignment { get; set; }

		//[XmlElement("Experience")]
		public int ExperiencePoints { get; set; }

		//[XmlElement("Proficiency")]
		public int ProficiencyBonus { get; set; }

		public Character()
		{
			
		}
		public Character(int strength, int dex, int con, int intelligence, int wisdom, int charisma) :base(strength,dex,con,intelligence,wisdom,charisma)
		{
			
		}

	}
}
