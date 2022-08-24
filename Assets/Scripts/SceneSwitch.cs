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
        if (ApplicationModel.set == 2)
        {
            ApplicationModel.current_sentence = ApplicationModel.PreTestingSet[level - 1];
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
