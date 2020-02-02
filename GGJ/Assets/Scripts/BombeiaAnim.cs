using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeiaAnim : MonoBehaviour
{
    Animator anim;
    //GameObject player, virus;
    void Start()
    {
        anim = GetComponent<Animator>();
       // player = GameObject.FindGameObjectWithTag("Player");
       // virus = GameObject.FindGameObjectWithTag("Virus");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colidiu com coração");
        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Virus"))
        {

            Debug.Log("foi jogador, bombeando");
            anim.SetBool("bombeia", true);
        }
    }

    /*void bombear()
    {
        anim.SetBool("bombeia", true);
    }*/


    void idle()
    {
        anim.SetBool("bombeia", false);
    }
}
