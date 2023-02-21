using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public GameObject moedas;
    int sorteio = 0;


    // Start is called before the first frame update
    void Start()
    {
        moedas = transform.GetChild(0).gameObject;
        sorteio = Random.Range(1 , 3);
        if(sorteio == 1)
        {
            moedas.SetActive(true);
        }
        else if(sorteio == 2)
        {
            moedas.SetActive(false);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag  == "Sensor")
        {
            Destroy(gameObject);
        }  
    }

    void OnTriggerEnter(Collider col)
    {
        if(gameObject.tag != "TremMovimento")
        {
            if(col.gameObject.tag  == "DestruidorTremMovimento")
            {
                Destroy(gameObject);
            }
        }   
    }
}
