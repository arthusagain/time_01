/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDialogueTrigger : MonoBehaviour
{
    public DoctorDialogue docDialogue;
    public bool falou = false;
    static public GameObject final;

    // Start is called before the first frame update
    void Start()
    {
        final = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (falou)
        {
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().FinalDialogueStart(docDialogue);
        falou = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && falou == false)
        {
            TriggerDialogue();
        }
    }
}*/
