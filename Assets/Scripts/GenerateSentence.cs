using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GenerateSentence : MonoBehaviour
{
    [SerializeField] public GameObject GameHolder;
    [SerializeField] public GameObject word;
    [SerializeField] public GameObject thisCanvas;
    List<string> sentences = new List<string>();

    public GenerateSentence()
    {
        sentences = ApplicationModel.current_sentence; 
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadWords());
    }

    IEnumerator LoadWords()
    {
        for(int i = 0; i < sentences.Count; i++)
        {
            GameObject icon = Instantiate(word) as GameObject;
            icon.transform.position = new Vector3(1517 + (i * 50), 500, 0);
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(GameHolder.transform);
            icon.name = "Word " + (i + 1);
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText(sentences[i]);
            yield return new WaitForSeconds(1);
        }
    }

    public void SentenceCompletion()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void StageCompletion()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
