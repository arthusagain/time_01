using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public enum TileType
    {
        Parede,
        Volta,
        Linha,
        Curva,
        Seta,
        Objetivo
    }
    public enum Orientacao
    {
        N,
        L,
        S,
        O
    }

    public TileType tipo;
    public Orientacao orientacao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tipo == TileType.Seta)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                orientacao = Orientacao.S;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                orientacao = Orientacao.N;
                transform.eulerAngles = new Vector3(0, 0, 180);

            }
            else if(Input.GetKey(KeyCode.LeftArrow))
            {
                orientacao = Orientacao.L;
                transform.eulerAngles = new Vector3(0, 0, 90);

            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                orientacao = Orientacao.O;
                transform.eulerAngles = new Vector3(0,0,270);
            }
        }
    }

    public float getX()
    {
        return transform.position.x;
    }
    public float getY()
    {
        return transform.position.y;
    }
}
