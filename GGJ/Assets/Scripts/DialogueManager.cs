using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public Text name;
    public Text dialogueText;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        textBox.gameObject.SetActive(false);
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        textBox.gameObject.SetActive(true);
        name.text = dialogue.npc;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence; 
        
    }

    void EndDialogue()
    {
        textBox.gameObject.SetActive(false);
        Debug.Log("Fim");
    }
}
