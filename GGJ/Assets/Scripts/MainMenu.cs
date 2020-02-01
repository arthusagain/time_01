using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //J: variavel que carrega nome da cena inicial do jogo
    public string mainScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //J: função que fecha o jogo
    public void ExitGame()
    {
        Application.Quit();
    }

    //J: função que faz transição para cena do jogo
    public void GameStart()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, mainScene));
    }
}
