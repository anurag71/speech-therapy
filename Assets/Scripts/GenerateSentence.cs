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
    private Rect canvasDimensions;
    List<string> sentences = new List<string>();

    public GenerateSentence()
    {
        sentences = ApplicationModel.current_sentence; 
    }
    // Start is called before the first frame update
    void Start()
    {
        canvasDimensions = thisCanvas.GetComponent<RectTransform>().rect;
        StartCoroutine(LoadWords());
    }

    IEnumerator LoadWords()
    {
        Vector2 position = PressurePlate.GetComponent<Transform>().localPosition;
        for(int i = 0; i < sentences.Count; i++)
        {
            GameObject icon = Instantiate(word) as GameObject;
            icon.transform.SetParent(GameHolder.transform);
            icon.name = "Word " + (i + 1);
            //icon.GetComponent<RectTransform>().anchoredPosition = PressurePlate.GetComponent<RectTransform>().anchoredPosition;
            icon.GetComponent<RectTransform>().localPosition = new Vector2(position.x + canvasDimensions.width, position.y);
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText(sentences[i]);

            float m_start_time = 0;
            float m_start_value = position.x + canvasDimensions.width;
            float m_end_time = 5;
            float m_end_value = position.x - canvasDimensions.width;


            var animation = icon.GetComponent<Animation>();
            AnimationClip clip = new AnimationClip();
            AnimationCurve curve = AnimationCurve.Linear(m_start_time, m_start_value, m_end_time, m_end_value);
            clip.name = "WordAnimationClipAuto"; // set name
            clip.legacy = true;
            clip.wrapMode = WrapMode.Loop;
            clip.frameRate = 61;
            clip.SetCurve("", typeof(Transform), "localPosition.x", curve);

            curve = AnimationCurve.Linear(m_start_time, position.y, m_end_time, position.y);
            clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
             // change to legacy

            animation.clip = clip; // set default clip
            animation.AddClip(clip, clip.name); // add clip to animation component

            animation.Play();


            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
