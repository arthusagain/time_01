using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image HPBar;
    static public float HP = 100;
    private float HP_Total;

    // Start is called before the first frame update
    void Start()
    {
        HP_Total = HP;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = HP / HP_Total;
    }
}
