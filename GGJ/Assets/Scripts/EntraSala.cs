using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntraSala : MonoBehaviour
{
    private bool porta;

    // Start is called before the first frame update
    void Start()
    {
        porta = false;   
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
        Debug.Log("entrou");
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            porta = true;
        }
    }
}
