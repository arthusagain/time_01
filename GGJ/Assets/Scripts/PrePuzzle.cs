using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrePuzzle : MonoBehaviour
{
    public Text fala;
    public string[] dialogo;

    // Start is called before the first frame update
    void Start()
    {
        fala.text = dialogo[0];
        fala.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void AvancaDialogo()
    {
        int i = 0;

        while (i < dialogo.Length)
        {
            fala.text = dialogo[i];

            if (Input.GetKey("space"))
            {
                i++;
            }
        }

        fala.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            fala.gameObject.SetActive(true);
            AvancaDialogo();
        }
    }
}
