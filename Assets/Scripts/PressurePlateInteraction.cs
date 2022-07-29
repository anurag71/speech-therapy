using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressurePlateInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI SentenceHolder;
    [SerializeField] private TextMeshProUGUI PopupTextHolder;
    [SerializeField] private GameObject StageCompletionAlert;

    int stage=1;
    int collision_count=0;
    string popupText = "TAP";
    int sentence_length = ApplicationModel.current_sentence.Count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        PopupTextHolder.SetText(popupText);
        collision_count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Stage : "+ stage);
        PopupTextHolder.SetText("");
        if (collision_count % (3*sentence_length) == 0 && collision_count > 0)
        {
            stage += 1;
            StageCompletionAlert.SetActive(true);
            

        }
        if (collision_count >= (3*sentence_length))
        {
            Animator animator = SentenceHolder.GetComponent<Animator>();
            animator.enabled = false;
            Destroy(SentenceHolder.GetComponent<Rigidbody2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StageCompletionAlert.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
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
