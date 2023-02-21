using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TremMovimento : MonoBehaviour
{
    public static bool mortoTremMovimento = false;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Andar", 15f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if(mortoTremMovimento)
        {
            CancelInvoke("Andar");
        }
    }

    void Andar()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag  == "SensorMovimentoTrem")
        {
            InvokeRepeating("Andar", 0, 0.015f);
        }   
    }
}
