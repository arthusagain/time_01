﻿using System.Collections;
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
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                orientacao = Orientacao.N;

            }
            else if(Input.GetKey(KeyCode.LeftArrow))
            {
                orientacao = Orientacao.L;

            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                orientacao = Orientacao.O;
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
