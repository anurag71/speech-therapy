using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class DisplayAnalytics : MonoBehaviour
{

	IDictionary<string, float> PlayTime;
	private Transform DateTimeEntryContainer;
	private Transform AnalyticsTemplate;

    private void Awake()
    {
		DateTimeEntryContainer = transform.Find("DateTimeEntryContainer");
		AnalyticsTemplate = DateTimeEntryContainer.Find("AnalyticsTemplate");

		

		float templateHeight = 30f;
		DateTime date = DateTime.Now.Date;
		BinaryFormatter bf = new BinaryFormatter();
		if (File.Exists(Application.persistentDataPath
				   + "/UserGameUsageData.dat"))
		{
			AnalyticsTemplate.gameObject.SetActive(false);
			FileStream file =
					   File.Open(Application.persistentDataPath
					   + "/UserGameUsageData.dat", FileMode.Open);
			GameUsage data = (GameUsage)bf.Deserialize(file);
			file.Close();
			PlayTime = data.PlayTime;
			Debug.Log("Game data loaded!");
			int i = 0;
			foreach (var item in PlayTime.Reverse())
			{
				Debug.Log("Date: " + item.Key + "  Time: " + item.Value + "\n");
				TimeSpan time = TimeSpan.FromSeconds((int)item.Value);

				//here backslash is must to tell that colon is
				//not the part of format, it just a character that we want in output
				string playedTime = time.ToString(@"hh\:mm\:ss");
				Transform entryTransform = Instantiate(AnalyticsTemplate, DateTimeEntryContainer);
				RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

				entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);

				entryTransform.gameObject.SetActive(true);

				entryTransform.Find("Date").GetComponent<TextMeshProUGUI>().SetText(item.Key);
				entryTransform.Find("Time").GetComponent<TextMeshProUGUI>().SetText(playedTime);
				i++;
                if (i > 6)
                {
					break;
                }
			}
		}
		else
		{
			Debug.Log("No saved file found");
		}

    }
    // Start is called before the first frame update
    void Start()
    {
		
	}

	public void Back()
	{
		SceneManager.LoadScene(0);
	}
}
