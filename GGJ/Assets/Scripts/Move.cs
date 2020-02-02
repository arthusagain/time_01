using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool falando = false;
    public float movSpeed = 5.0f;
    private Vector2 move;
    private Rigidbody2D rb;
    public AudioSource passos;
    public GameObject cxTexto;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    private void Movimento()
    {
        if(!falando)
        {
            
            float movHon = Input.GetAxis("Horizontal");

            if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))&& movHon == 0)
            {
                Debug.Log("buggou.... tentando consertar");
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    Debug.Log("Positivo");
                    movHon = 1;
                }
                else
                {
                    Debug.Log("Negativo");
                    movHon = -1;
                }
            }

            
            Vector2 mov = new Vector2(movHon, 0);

            rb.velocity = mov * movSpeed;

            Debug.Log($"velocity = ({rb.velocity.x},{rb.velocity.y})");

            if (movHon != 0 && passos.isPlaying == false)
            {
                passos.Play();
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0) * movSpeed;
            passos.Stop();
        }
    }
}

