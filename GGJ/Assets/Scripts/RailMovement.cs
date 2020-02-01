using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float speed = 1;

    //J: segundos para executar rotação
    //public float rDuration = 1;

    //J: direção inicial do movimento
    public Direction dir;

    //private float prevX;
    //private float prevY;

    private Rigidbody2D body;

    //J: se jogo acabar, para
    private bool over = false;

    // Start is called before the first frame update
    void Start()
    {
        //prevX = transform.position.x;
       // prevY = transform.position.y;
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!over)
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
        Debug.Log("Colidiu");
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

                        Debug.Log("Volta");
                        Rotate(180);
                    }
                    else
                    {
                        GameOver();
                        Debug.Log("Morre");
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
                    Debug.Log("Fim da curva");
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
                default:
                    //parede
                    GameOver();
                    break;            }
        }
    }
    private void Rotate(int degrees)
    {
        Debug.Log($"Rodando {degrees} graus");
        Debug.Log($"Direção inicial {dir}");
        int temp = (((int)dir+(degrees/90))%4);
        //if (temp == 0) temp = 4;
        dir = (Direction)temp;

        Debug.Log($"Direção final {dir}");
    }
    private void GameOver()
    {
        over = true;
        Destroy(this.gameObject);
        Debug.Log("Fim de jogo");
        //pausar jogo, oferece botão para reiniciar cena.
    }

    private void GameWin()
    {
        //venceu o jogo.
    }
}
