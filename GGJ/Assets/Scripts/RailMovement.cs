using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RailMovement : MonoBehaviour
{
    //J: direção do movimento
    public enum Direction
    {
        S,
        O,
        N,
        L
    }
    //J: velocidade de movimento
    public float speed = 2;

    //J: virus e jogador referenciam um ao outro para determinar colisão. minDist é a distancia considerada colisão
    public GameObject rival;
    public float minDist;

    //J: direção inicial do movimento
    public Direction dir;

    private Rigidbody2D body;

    //J: se jogo acabar, para
    private bool over = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,rival.transform.position)<=minDist)
        {
            GameOver();
        }
        else if (!over)
        {
            switch (dir)
            {
                case Direction.N:
                    transform.position = new Vector2(transform.position.x,transform.position.y + Time.deltaTime * speed);  
                    break;
                case Direction.S:
                    transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * speed);                  
                    break;
                case Direction.L:
                    transform.position = new Vector2(transform.position.x + Time.deltaTime * speed,transform.position.y);                   
                    break;
                case Direction.O:
                    transform.position = new Vector2(transform.position.x - Time.deltaTime * speed, transform.position.y);                   
                    break;
                default:
                    GameOver();
                    break;
            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Virus"))
        {
            GameOver();
        }
        else if (other.CompareTag("Rail"))
        {
            GridTile GT = other.GetComponent<GridTile>();
            switch (GT.tipo)
            {
                case GridTile.TileType.Volta:

                    if ((int)GT.orientacao == (int)dir)
                    {
                        Rotate(180);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;
                case GridTile.TileType.Linha:
                    if (((int)dir + 2)%4 == ((int)GT.orientacao)%4 )
                    {
                        GT.orientacao = (GridTile.Orientacao)dir;
                    }
                    else
                    {
                        dir = (Direction)GT.orientacao;
                    }
                    break;
                case GridTile.TileType.Curva:
                    if((int)GT.orientacao == (int)dir)
                    {
                        Rotate(90);
                    }
                    else if(((int)GT.orientacao == 0  && (int)dir == 3) || (int)GT.orientacao-1 == (int)dir)
                    {
                        Rotate(270);
                    }
                    break;
                case GridTile.TileType.Seta:
                    {
                        dir = (Direction)GT.orientacao;
                    }
                    break;
                case GridTile.TileType.Objetivo:
                    if (this.gameObject.CompareTag("Player"))
                    {
                        GameWin();
                    }
                    else Rotate(180);
                    break;
                case GridTile.TileType.Parede:
                    GameOver();
                    break;
                default:
                    GameOver();
                    break;            }
        }
    }
    private void Rotate(int degrees)
    {
        int temp = (((int)dir+(degrees/90))%4);
        dir = (Direction)temp;

    }
    private void GameOver()
    {
        Time.timeScale = 0;
        over = true;
        Destroy(this.gameObject);
        Debug.Log("Fim de jogo");
        //pausar jogo, oferece botão para reiniciar cena.
    }

    private void GameWin()
    {
        Time.timeScale = 0;
        //Debug.Log("Ganhou!");
        GameManager.HP -= 25;
        //DialogueTrigger.paciente.GetComponent<SpriteRenderer>().sprite = DialogueTrigger.;
        SceneManager.UnloadSceneAsync(DialogueManager.NomeFase);
        DialogueManager.canvas.gameObject.SetActive(true);
        DialogueTrigger.paciente.gameObject.SetActive(false);
        //venceu o jogo.
    }

}
