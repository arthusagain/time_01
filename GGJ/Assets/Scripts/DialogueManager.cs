using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    static public GameObject canvas;
    public GameObject textBox;
    public GameObject chooseButton;
    public Text activeName;
    public Text dialogueText;
    static public string NomeFase;
    private string post_name;
    private string n_fala;
    private string s_fala;
    private Queue<string> sentences;
    private Queue<string> names;
    private GameObject player;
    private Move playermov;
    public AudioSource passaDialogo;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        textBox.gameObject.SetActive(false);
        chooseButton.gameObject.SetActive(false);
        sentences = new Queue<string>();
        names = new Queue<string>();
        player = GameObject.Find("Player");
        playermov = player.GetComponent<Move>();
    }

    private void Update()
    {
        if(Input.GetKeyDown("space") && playermov.falando == true )
        {
            passaDialogo.Play();
            DisplayNextSentence();
        }
        if(Input.GetKeyDown("space") && playermov.falando == true && (dialogueText.text == n_fala || dialogueText.text == s_fala))
        {
            EndDialogue();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playermov.falando = true;
        textBox.gameObject.SetActive(true);
        NomeFase = dialogue.MinigameScene;
        s_fala = dialogue.s_frase;
        n_fala = dialogue.n_frase;
        post_name = dialogue.post_name;
        NomeFase = dialogue.MinigameScene;
        passaDialogo.Play();

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }

        foreach(string name in dialogue.npc)
        {
            names.Enqueue(name);
        }

        if(dialogueText.text != dialogue.sentences[0])
        {
            DisplayNextSentence();
        }      
    }


    public void Deny()
    {
        activeName.text = post_name;
        dialogueText.text = n_fala;
    }

    public void Accept()
    {
        SceneManager.LoadScene(NomeFase, LoadSceneMode.Additive);
        canvas.gameObject.SetActive(false);
        activeName.text = post_name;
        dialogueText.text = s_fala;       
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            chooseButton.gameObject.SetActive(true);
            //EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        activeName.text = name;
        dialogueText.text = sentence; 
        
    }

    public void EndDialogue()
    {
        playermov.falando = false;
        textBox.gameObject.SetActive(false);
        chooseButton.gameObject.SetActive(false);
        //funcao de fade pra proxima scene
    }
}
