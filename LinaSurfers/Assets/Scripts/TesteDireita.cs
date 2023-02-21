using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteDireita : MonoBehaviour
{
    public bool direita = true;

    BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        //direita = false;
    }

    void OnTriggerExit(Collider col)
    {
        //direita = true;  

        if(col.gameObject.tag  == "Altura")
        {
            boxCollider.enabled = true;
        }   
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag  == "Altura")
        {
            boxCollider.enabled = false;
        }   
    }
}
