using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class PressurePlateInteraction : MonoBehaviour
{
    [SerializeField] private GameObject PopupTextHolder;
    [SerializeField] private GameObject StageCompletionAlert;
    [SerializeField] private GameObject SentenceCompletionAlert;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject UserChancePrompt;
    [SerializeField] private GameObject StageText;
    bool CountTime = true;
    float seconds = 0;

    AudioSource WordSound;
    HashSet<GameObject> gameObjects = new HashSet<GameObject>();

    int stage=1;
    int collision_count=0;
    string popupText = "TAP";
    int sentence_length;

    bool Speak=true;

    private void Start()
    {
        sentence_length = ApplicationModel.current_sentence.Count;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mesh mesh = collision.CreateMesh(false, false);
        //  mesh.Optimize();

        //LineRenderer myLine = new LineRenderer();
        //myLine.loop = true;

        //Vector3[] positions = mesh.vertices;
        //positions = positions.OrderBy(pos => Vector3.SignedAngle(pos.normalized, Vector3.up, Vector3.forward)).ToArray();

        //myLine.positionCount = positions.Length;
        //myLine.SetPositions(positions);

        GameObject gameObject = collision.gameObject;

        Debug.Log("Collision Time for " + gameObject.GetComponentInChildren<TextMeshProUGUI>().text + " : " + Time.timeAsDouble);

        collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().outlineWidth = 0.2f;
        collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().outlineColor = new Color32(255, 128, 0, 255);

        if (Speak)
        {
            WordSound = PopupTextHolder.GetComponent<AudioSource>();
            WordSound.clip = Resources.Load<AudioClip>("WordSounds/" + gameObject.GetComponentInChildren<TextMeshProUGUI>().text);
            WordSound.Play();
            Debug.Log("Sound Played Time for " + gameObject.GetComponentInChildren<TextMeshProUGUI>().text + " : " + Time.timeAsDouble);
        }

        Time.timeScale = 0f;

        PopupTextHolder.GetComponentInChildren<TextMeshProUGUI>().SetText(popupText);

        Time.timeScale = 1;

        collision_count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Stage : "+ stage);

        //if ((collision_count / (3 * sentence_length)) % 2 != 0 && (collision_count % (3*sentence_length)==0) && collision_count >= 3 * sentence_length && stage <= 3)
        //{
        //    UserChancePrompt.SetActive(true);
        //}



        PopupTextHolder.GetComponentInChildren<TextMeshProUGUI>().SetText("");
        if (collision_count % (3*sentence_length) == 0 && collision_count > 0 && stage<5)
        {
            stage += 1;
            ApplicationModel.stage = stage;
            //foreach(GameObject gameObject in gameObjects)
            //{
            //    gameObject.SetActive(false);
            //}
            //if (stage == 2)
            //{
            //    Stage2Prompt.SetActive(true);
            //}
            if(stage >2)
            {
                Speak = false;
            }
        }
        else if (stage == 5 && collision_count >= (5 * 3 * sentence_length))
        {
            CountTime = false;
            ApplicationModel.time = seconds;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            SentenceCompletionAlert.SetActive(true);
        }
        else
        {
            gameObjects.Add(collision.gameObject);
        }
        collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().outlineWidth = 0.0f;
    }

    public void SentenceCompletion()
    {
        if (SaveUsage.SaveGameTime())
        {
            ApplicationModel.time = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        if (SaveUsage.SaveGameTime())
        {
            ApplicationModel.time = 0;
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }
    }

    public void Retry()
    {
        ApplicationModel.time = seconds;
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }

    public void Pause()
    {
        Time.timeScale = 1;
        CountTime = true;
        //if (Stage1Prompt.activeSelf)
        //{
        //    Stage1Prompt.GetComponent<AudioSource>().Play();
        //}
        //else if (Stage2Prompt.activeSelf)
        //{
        //    Stage2Prompt.GetComponent<AudioSource>().Play();
        //}
        //else if (Stage3Prompt.activeSelf)
        //{
        //    Stage3Prompt.GetComponent<AudioSource>().Play();
        //}
        StartCoroutine(delayedAnimation());
    }

    public void StageCompletion()
    {
        Time.timeScale = 1;
        StartCoroutine(delayedAnimation());
    }


    

// Update is called once per frame
void Update()
    {
        
        if (CountTime)
        {
            seconds += Time.deltaTime;
            
        }
        StageText.GetComponent<TextMeshProUGUI>().SetText("Stage :" + stage);
        if (SentenceCompletionAlert.activeSelf)
        {
            Time.timeScale = 0f;
        }
        if (StageCompletionAlert.activeSelf)
        {
            Time.timeScale = 0f;
        }
        if (stage == 2)
        {
            popupText = "TAP + SPEAK";
        }
        else if (stage > 3)
        {
            popupText = "SPEAK";
        }
        //if(Stage1Prompt.activeSelf || Stage2Prompt.activeSelf || Stage3Prompt.activeSelf)
        //{
        //    Time.timeScale = 0f;
        //}
        if (PauseMenu.activeSelf)
        {
            PauseMenu.GetComponentInChildren<Animation>().Play();
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }
            //if (Stage1Prompt.activeSelf)
            //{
            //    Stage1Prompt.GetComponent<AudioSource>().Pause();
            //}
            //else if (Stage2Prompt.activeSelf)
            //{
            //    Stage2Prompt.GetComponent<AudioSource>().Pause();
            //}
            //else if (Stage3Prompt.activeSelf)
            //{
            //    Stage3Prompt.GetComponent<AudioSource>().Pause();
            //}
            Time.timeScale = 0f;
            CountTime = false;
        }
        //if (UserChancePrompt.activeSelf)
        //{
        //    foreach (GameObject gameObject in gameObjects)
        //    {
        //        gameObject.SetActive(false);
        //    }
        //    Time.timeScale = 0f;
        //}
    }

    IEnumerator delayedAnimation()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<Animation>().Play();
        }
    }

    public void StagePromptHandler()
    {
        Time.timeScale = 1;
        StartCoroutine(delayedAnimation());
    }


}
