using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public Text name;
    public Text dialogueText;
    private string NomeFase;
    private Queue<string> sentences;
    private GameObject player;
    private Move playermov;

    // Start is called before the first frame update
    void Start()
    {
        textBox.gameObject.SetActive(false);
        sentences = new Queue<string>();
        player = GameObject.Find("Player");
        playermov = player.GetComponent<Move>();
    }

    private void Update()
    {
        if(Input.GetKeyDown("space") && playermov.falando == true)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playermov.falando = true;
        textBox.gameObject.SetActive(true);
        name.text = dialogue.npc;
        NomeFase = dialogue.MinigameScene;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }

        if(dialogueText.text != dialogue.sentences[0])
        {
            DisplayNextSentence();
        }      
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

    public void EndDialogue()
    {
        playermov.falando = false;
        textBox.gameObject.SetActive(false);
        //funcao de fade pra proxima scene
    }
}
