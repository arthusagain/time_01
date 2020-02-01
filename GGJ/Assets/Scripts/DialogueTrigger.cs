using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool falou = false;

    private void Update()
    {
        if(falou)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        falou = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && falou == false)
        {
            Debug.Log("oi");
            TriggerDialogue();
        }
    }
}
