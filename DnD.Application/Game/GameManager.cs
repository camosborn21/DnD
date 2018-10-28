using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Application.EntityStats;
using System.IO;
using System.Xml.Serialization;
using DnD.Application.Libraries;

namespace DnD.Application.Game
{
	public class GameManager
	{
		public CharacterManager CharacterManager;
		public NPCManager NpcManager;
		public List<WeaponLibrary> WeaponLibraries;
		public GameManager()
		{
			NpcManager = new NPCManager("Npcs");
			CharacterManager = new CharacterManager("Characters");
			WeaponLibraries = new List<WeaponLibrary>();
		}


		public void SaveGame(string fileName)
		{
			//Save characters
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(CharacterManager));
			FileStream fs = new FileStream(fileName+"_Characters",FileMode.Create);
			xmlSerializer.Serialize(fs,CharacterManager);
			fs.Close();
			

		}

		public void LoadGame(string fileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(CharacterManager));
			FileStream fs = new FileStream(fileName,FileMode.Open);
			CharacterManager = (CharacterManager) xmlSerializer.Deserialize(fs);
		}

	}
}
