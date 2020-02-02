﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool falou = false;
    static public GameObject paciente;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && falou == false)
        {
            TriggerDialogue();
        }
    }
}
