using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DnD.Application.Libraries;

namespace DnD.Application.Game
{
	public class LibraryManager
	{
		public List<WeaponLibrary> WeaponLibraries;


		public void OpenWeaponLibrary(string fileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeaponLibrary));
			FileStream fs = new FileStream(fileName,FileMode.Open);
			WeaponLibrary newWeaponLibrary = (WeaponLibrary) xmlSerializer.Deserialize(fs);

			newWeaponLibrary.FileName = fileName;
			WeaponLibraries.Add(newWeaponLibrary);
			
		}

		public void SaveWeaponLibraries()
		{
			foreach (var weaponLibrary in WeaponLibraries)
			{
				weaponLibrary.SaveLibrary("");
			}
		}

		public void SaveWeaponLibrariesAs(string filePath)
		{
			foreach (var weaponLibrary in WeaponLibraries)
			{
				weaponLibrary.SaveLibrary(filePath + Path.PathSeparator + weaponLibrary.Name);
			}
		}

	}
}
