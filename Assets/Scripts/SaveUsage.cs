using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveUsage
{
    public static bool SaveGameTime()
    {
		string date = DateTime.Now.ToShortDateString();
		BinaryFormatter bf = new BinaryFormatter();
        try
        {
			if (File.Exists(Application.persistentDataPath
				   + "/UserGameUsageData.dat"))
			{
				FileStream file =
						   File.Open(Application.persistentDataPath
						   + "/UserGameUsageData.dat", FileMode.Open);
				GameUsage data = (GameUsage)bf.Deserialize(file);


				IDictionary<string, float> PlayTime = data.PlayTime;

				float value;
				if (PlayTime.TryGetValue(date, out value))
				{
					PlayTime[date] = value + ApplicationModel.time;
				}
				else
				{
					PlayTime[date] = ApplicationModel.time;
				}
				bf.Serialize(file, data);
				file.Close();
				Debug.Log("Game data saved!");
				return true;
			}
			else
			{
				Debug.Log("There is no save data!");
				FileStream file = File.Create(Application.persistentDataPath + "/UserGameUsageData.dat");
				GameUsage data = new GameUsage();
				data.PlayTime[date] = ApplicationModel.time;
				bf.Serialize(file, data);
				file.Close();
				Debug.Log("Game data saved!");
				return true;
			}
		}
		catch(Exception e)
        {
			Debug.Log(e.StackTrace);
			return false;
		}
		
    }
}
