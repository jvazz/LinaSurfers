using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.z != 0)
        {
            Invoke("Destruir", 1f);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
