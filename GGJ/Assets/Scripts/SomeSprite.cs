using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeSprite : MonoBehaviour
{
    private GameObject pacienteBom;
    private GameObject pacienteRuim;

    // Start is called before the first frame update
    void Start()
    {
        pacienteBom = this.gameObject;
        pacienteRuim = DialogueTrigger.paciente;
        pacienteBom.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pacienteRuim.gameObject == true)
        {
            pacienteBom.gameObject.SetActive(true);
        }
    }
}
