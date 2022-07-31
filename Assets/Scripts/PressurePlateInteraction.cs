using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PressurePlateInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PopupTextHolder;
    [SerializeField] private GameObject StageCompletionAlert;
    [SerializeField] private GameObject SentenceCompletionAlert;

    int stage=1;
    int collision_count=0;
    string popupText = "TAP";
    int sentence_length;

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


        //Debug.Log("Collision detected");
        PopupTextHolder.SetText(popupText);
        collision_count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Stage : "+ stage);
        PopupTextHolder.SetText("");
        if (collision_count % (3*sentence_length) == 0 && collision_count > 0 && stage<3)
        {
            stage += 2;
            StageCompletionAlert.SetActive(true);
        }
        else if (stage == 3 && collision_count >= (2 * 3 * sentence_length))
        {
            SentenceCompletionAlert.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        else if (stage == 3)
        {
            popupText = "SPEAK";
        }
    }
}
