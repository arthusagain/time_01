using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image HPBar;
    static public float HP = 100;
    private static float HP_Total;
    static public int paciCont;

    static public GameObject finalBom;
    static public GameObject finalRuim;

    // Start is called before the first frame update
    void Start()
    {
        HP_Total = HP;
        paciCont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = HP / HP_Total;
    }

    public static void paciIncr()
    {
        paciCont++;
        if (paciCont == 4)
        {
            EndGame();
        }
    }

    private static void EndGame()
    {
        if (HP == 0)
        {
            finalBom.SetActive(true);
        }
        else
        {
            finalRuim.SetActive(true);
        }
    }

    public static void resetGame()
    {
        HP = HP_Total;
        paciCont = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
