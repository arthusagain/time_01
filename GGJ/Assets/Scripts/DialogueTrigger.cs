using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool falou = false;
    static public GameObject paciente;
    //public DoctorDialogue docDialogue;

    private void Start()
    {
        paciente = this.gameObject;
    }
    private void Update()
    {
        if(falou)
        {
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        falou = true;
    }

    /*public void TriggerDialogueFinal()
    {
        FindObjectOfType<DialogueManager>().FinalDialogueStart(docDialogue);
        falou = true;
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& !falou/* && falou == false && paciente.tag != "Finish"*/)
        {
            TriggerDialogue();
        }
        
        /*else
        {
            TriggerDialogueFinal();
        }*/
    }
}
