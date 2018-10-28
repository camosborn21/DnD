using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Application.Items;
using System.Xml.Serialization;
namespace DnD.Application.Libraries
{
	[XmlRoot("CharacterList")]
	[XmlInclude(typeof(Weapon))]
	[XmlInclude(typeof(RangedWeapon))]
	[XmlInclude(typeof(Ammunition))]
	public class WeaponLibrary
	{
		[XmlArray("WeaponLibrary")]
		[XmlArrayItem("Weapon")]
		public List<Weapon> Weapons { get; set; }

		public string Name { get; set; }

		public string FileName { get; set; }

		public void SaveLibrary(string fileName)
		{
			var trueName = fileName == "" ? FileName : fileName;
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeaponLibrary));
			FileStream fs = new FileStream(trueName,FileMode.Create);
			xmlSerializer.Serialize(fs,this);
			fs.Close();
		}


	}
}
