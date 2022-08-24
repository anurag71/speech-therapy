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
    [SerializeField] public GameObject PressurePlate;
    // Start is called before the first frame update
    private IEnumerator coroutine;
    private float INTERVAL_SECONDS = 1.00f;
    private Rect canvasDimensions;
    List<string> sentences = new List<string>();
    int i = 0;

    public GenerateSentence()
    {
        sentences = ApplicationModel.current_sentence;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Word count = " + sentences.Count);
        canvasDimensions = thisCanvas.GetComponent<RectTransform>().rect;
        //coroutine = TempoMake();
        //StartCoroutine(coroutine);
        coroutine = LoadWords();
        StartCoroutine(coroutine);

    }

    IEnumerator LoadWords()
    {
        Debug.Log("Load Words Called");
        Vector2 position = PressurePlate.GetComponent<Transform>().localPosition;
        while (i < sentences.Count)
        {
            Debug.Log("Word position: " + i);
            GameObject icon = Instantiate(word) as GameObject;
            icon.transform.SetParent(GameHolder.transform);
            icon.name = "Word " + (i + 1);
            //icon.GetComponent<RectTransform>().anchoredPosition = PressurePlate.GetComponent<RectTransform>().anchoredPosition;
            icon.GetComponent<RectTransform>().localPosition = new Vector2(position.x + (canvasDimensions.width / 2), position.y);
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText(sentences[i]);

            float m_start_time = 0;
            float m_start_value = position.x + (canvasDimensions.width / 2);
            float m_end_time = 5;
            float m_end_value = position.x - (canvasDimensions.width / 2);


            Animation animation = icon.GetComponent<Animation>();
            AnimationClip clip = new AnimationClip();

            AnimationCurve curve = AnimationCurve.Linear(m_start_time, m_start_value, m_end_time, m_end_value);
            clip.name = "WordAnimationClipAuto"; // set name
            clip.legacy = true;
            clip.frameRate = 60;
            clip.wrapMode = WrapMode.Loop;
            clip.SetCurve("", typeof(Transform), "localPosition.x", curve);

            curve = AnimationCurve.Linear(m_start_time, position.y, m_end_time, position.y);
            clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
            // change to legacy
            animation.clip = clip; // set default clip
            animation.AddClip(clip, clip.name); // add clip to animation component
            animation.Play();
            Debug.Log("Generate Time for " + sentences[i] + " : " + Time.timeAsDouble);
            i++;
            if (Time.timeScale == 0)
            {
                Debug.Log("Paused");
            }
            else
            {
                Debug.Log("Not Paused");
            }

            Debug.Log("i value " + i);

            yield return new WaitForSecondsRealtime(1.0f);
            Debug.Log("Done waiting");
        }
        
    }


    //IEnumerator TempoMake()//Plays a sound at regular intervals and displays "Played" on the console
    //{
    //    while (true)
    //    {
    //        yield return
    //        new WaitForSecondsRealtime(1);
    //        audioSource.Play();
    //        Debug.Log("Beat played at : " + Time.timeAsDouble);
    //    }
    //}



    // Update is called once per frame
    void Update()
    {
        
    }
}
