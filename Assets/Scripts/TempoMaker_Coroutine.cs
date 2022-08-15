using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoMaker_Coroutine : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    private IEnumerator coroutine;
    public float INTERVAL_SECONDS = 1.0f;//Can be changed from the inspector (and of course from the script)
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coroutine = TempoMake();
        StartCoroutine(coroutine);

    }

    // Update is called once per frame
    void Update()
    {
        //Stop while holding down the left mouse button, restart when released
        if (ApplicationModel.stage==5)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator TempoMake()//Plays a sound at regular intervals and displays "Played" on the console
    {
        while (true)
        {
            yield return
             new WaitForSecondsRealtime(INTERVAL_SECONDS);
            audioSource.Play();
            print("Played");
        }
    }
}
