/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDialogueManager : MonoBehaviour
{
    static public GameObject canvas;
    public GameObject chooseButton;
    public GameObject textBox;
    public Text activeName;
    public Text dialogueText;
    private Queue<string> sentences;
    private GameObject player;
    private Move playermov;
    public AudioSource passaDialogo;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        sentences = new Queue<string>();
        player = GameObject.Find("Player");
        playermov = player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && playermov.falando == true)
        {
            passaDialogo.Play();
            DisplayNextFinal();
        }
        if (Input.GetKeyDown("space") && playermov.falando == true && sentences == null)
        {
            EndDialogue();
        }
    }

    public void FinalDialogueStart(DoctorDialogue dialogue)
    {
        playermov.falando = true;
        textBox.gameObject.SetActive(true);
        activeName.text = dialogue.doctor_name;

        sentences.Clear();


        if(GameManager.HP == 0)
        {
            foreach (string good in dialogue.good_end)
            {
                sentences.Enqueue(good);
            }
        }
        else
        {
            foreach (string bad in dialogue.bad_end)
            {
                sentences.Enqueue(bad);
            }
        }

        if (dialogueText.text != dialogue.good_end[0] )
        {
            DisplayNextFinal();
        }
    }

    public void DisplayNextFinal()
    {
        if (sentences.Count == 0)
        {
            chooseButton.gameObject.SetActive(false);
            //EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        playermov.falando = false;
        textBox.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        //funcao de fade pra proxima scene
    }
}*/
