using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] public GameObject levelIcon;

    public void changeScene()
    {
        int level;
        int.TryParse(levelIcon.GetComponentInChildren<TextMeshProUGUI>().text, out level);
        if (ApplicationModel.set == 1)
        {
            ApplicationModel.current_sentence = ApplicationModel.TrialSet[level - 1];
        }
        else if (ApplicationModel.set == 2)
        {
            ApplicationModel.current_sentence = ApplicationModel.PreTestingSet[level - 1];
        }
        else if (ApplicationModel.set == 3)
        {
            ApplicationModel.current_sentence = ApplicationModel.PracticeSet[level - 1];
        }
        else if (ApplicationModel.set == 4)
        {
            ApplicationModel.current_sentence = ApplicationModel.PostTestingSet[level - 1];
        }
        Debug.Log("Word count = " + ApplicationModel.current_sentence.Count);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
