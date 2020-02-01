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
           
            switch (other.GetComponent<GridTile>().tipo)
            {
                case GridTile.TileType.Volta:

                    if ((int)other.GetComponent<GridTile>().orientacao == (int)dir)
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
                    if (!(other.GetComponent<GridTile>().orientacao.Equals(dir) ||
                        (other.GetComponent<GridTile>().orientacao.GetHashCode() / 2 < 1.5) == (dir.GetHashCode() / 2 < 1.5)))
                    {
                        GameOver();
                    }
                    break;
                case GridTile.TileType.Curva:
                    switch (other.GetComponent<GridTile>().orientacao)
                    {
                        case GridTile.Orientacao.N:
                            break;
                        case GridTile.Orientacao.S:
                            break;
                        case GridTile.Orientacao.L:
                            break;
                        case GridTile.Orientacao.O:
                            break;
                        default:
                            Debug.Log($"Colisão de tile invalida em ({transform.position.x},{transform.position.y}");
                            break;
                    }
                    break;
                case GridTile.TileType.Seta:
                    switch (other.GetComponent<GridTile>().orientacao)
                    {
                        case GridTile.Orientacao.N:
                            break;
                        case GridTile.Orientacao.S:
                            break;
                        case GridTile.Orientacao.L:
                            break;
                        case GridTile.Orientacao.O:
                            break;
                        default:
                            Debug.Log($"Colisão de tile invalida em ({transform.position.x},{transform.position.y}");
                            break;
                    }
                    break;
                default:
                    Debug.Log($"Colisão com tile invalido em ({transform.position.x},{transform.position.y}");
                    break;
                    
            }
        }
    }
    private void Rotate(int degrees)
    {
        int temp = (((int)dir+(degrees/90))%4);
        if (temp == 0) temp = 4;
        dir = (Direction)temp;
    }
    private void GameOver()
    {
        over = true;
        Destroy(this.gameObject);
        Debug.Log("Fim de jogo");
        //pausar jogo, oferece botão para reiniciar cena.
    }
}
