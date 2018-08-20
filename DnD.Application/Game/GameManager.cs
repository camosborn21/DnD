using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Application.EntityStats;
using System.IO;
using System.Xml.Serialization;

namespace DnD.Application.Game
{
	public class GameManager
	{
		public CharacterManager CharacterManager;

		public GameManager()
		{
			CharacterManager = new CharacterManager("Characters");
		}


		public void SaveGame(string fileName)
		{
			//Save characters
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(CharacterManager));
			FileStream fs = new FileStream(fileName,FileMode.Create);
			xmlSerializer.Serialize(fs,CharacterManager);
			fs.Close();
			CharacterManager = null;

		}

		public void LoadGame(string fileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(CharacterManager));
			FileStream fs = new FileStream(fileName,FileMode.Open);
			CharacterManager = (CharacterManager) xmlSerializer.Deserialize(fs);
		}

	}
}
