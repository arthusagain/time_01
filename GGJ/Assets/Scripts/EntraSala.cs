﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntraSala : MonoBehaviour
{
    private bool porta;
    public Vector2 doorPosition;
    private GameObject player;
    public AudioSource abrePorta;

    // Start is called before the first frame update
    void Start()
    {
        porta = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && porta)
        {
            Entra();
            porta = false;
        }
    }

    private void Entra()
    {
        abrePorta.Play();
        player.transform.position = doorPosition;
        Debug.Log("entrou");
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            porta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        porta = false;
    }
}
