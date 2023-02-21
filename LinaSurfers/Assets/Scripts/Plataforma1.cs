using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma1 : MonoBehaviour
{
    public GameObject obstaculo1, obstaculo2, obstaculo3, obstaculo4, obstaculo5, obstaculo6;
    public GameObject tremMovimento, tremMovimento2;
    private int tipoPista = 0;
    private int vezes = 5; 
    private int posicao = -20;
    public float layerE = -3f;
    public float layerD = 3f;
    private int aleatorioInicio = 0;
    private int posicaoCodigo = 20;

    public int moedas = 0;

    // Start is called before the first frame update
    void Start()
    {
        //posicao -= 80;
        posicao -= posicaoCodigo*4;
        //aleatorioInicio = Random.Range(1 , 4);
        tipoPista = Random.Range(1 , 8);
        if(tipoPista == 1)
        {
            Pista1();
        }
        if(tipoPista == 2)
        {
            Pista2();
        }
        if(tipoPista == 3)
        {
            Pista3();
        }
        if(tipoPista == 4)
        {
            Pista4();
        }
        if(tipoPista == 5)
        {
            Pista5();
        }
        if(tipoPista == 6)
        {
            Pista6();
        }
        if(tipoPista == 7)
        {
            Pista7();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag  == "Player")
        {
            transform.position += transform.forward * 400;

            posicao += 100;

            //tipoPista = Random.Range(1 , 9);
            tipoPista = Random.Range(1, 9);
            if(tipoPista == 1)
            {
                Pista1();
            }
            if(tipoPista == 2)
            {
                Pista2();
            }
            if(tipoPista == 3)
            {
                Pista3();
            }
            if(tipoPista == 4)
            {
                Pista4();
            }
            if(tipoPista == 5)
            {
                Pista5();
            }
            if(tipoPista == 6)
            {
                Pista6();
            }
            if(tipoPista == 7)
            {
                Pista7();
            }
            if(tipoPista == 8)
            {
                Pista8();
            }
        }
    }

    void  Pista1()
    {
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
    }
    void  Pista2()
    {
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
    }
    void  Pista3()
    {
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
    }
    void  Pista4()
    {
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
    }

    void  Pista5()
    {
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
    }
    void  Pista6()
    {
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
    }
    void  Pista7()
    {
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo3, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo5, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo2, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(obstaculo1, transform.position + -50*transform.forward - posicao*transform.forward, transform.rotation);
        Instantiate(obstaculo6, transform.position + -50*transform.forward - posicao*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(obstaculo4, transform.position + -50*transform.forward - posicao*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
    }
    void  Pista8()
    {
        Instantiate(tremMovimento2, transform.position + -50*transform.forward - posicao*transform.forward + 190*transform.forward, transform.rotation);
        Instantiate(tremMovimento2, transform.position + -50*transform.forward - posicao*transform.forward + 190*transform.forward + layerD*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(tremMovimento, transform.position + -50*transform.forward - posicao*transform.forward + 190*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(tremMovimento, transform.position + -50*transform.forward - posicao*transform.forward + 190*transform.forward, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(tremMovimento, transform.position + -50*transform.forward - posicao*transform.forward + 190*transform.forward + layerD*transform.right, transform.rotation);
        Instantiate(tremMovimento, transform.position + -50*transform.forward - posicao*transform.forward + 190*transform.forward + layerE*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
        Instantiate(tremMovimento, transform.position + -50*transform.forward - posicao*transform.forward + 190*transform.forward + layerD*transform.right, transform.rotation);
        posicao -= posicaoCodigo;
    }
}