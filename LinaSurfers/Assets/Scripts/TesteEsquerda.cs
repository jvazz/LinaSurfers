using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteEsquerda : MonoBehaviour
{
    public bool esquerda = true;

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
        //esquerda = false;
    }

    void OnTriggerExit(Collider col)
    {
        //esquerda = true;

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
