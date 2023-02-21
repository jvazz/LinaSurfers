using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorTrem : MonoBehaviour
{
    public Color azul, vermelho, amarelo;
    int sorteio = 0;

    // Start is called before the first frame update
    void Start()
    {
        sorteio = Random.Range(1 , 4);
        if(sorteio == 1)
        {
            GetComponent<Renderer>().material.color = azul;
        }
        if(sorteio == 2)
        {
            GetComponent<Renderer>().material.color = vermelho;
        }
        if(sorteio == 3)
        {
            GetComponent<Renderer>().material.color = amarelo;
        }
    }
}
