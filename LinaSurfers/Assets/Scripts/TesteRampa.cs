using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteRampa : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag  == "Player")
        {
            if(player.GetComponent<PlayerMove>().lane0 == transform.position.x)
            {
                player.GetComponent<PlayerMove>().mudar = 1;
            }
            if(player.GetComponent<PlayerMove>().lane1 == transform.position.x)
            {
                player.GetComponent<PlayerMove>().mudar = 2;
            }
            if(player.GetComponent<PlayerMove>().lane2 == transform.position.x)
            {
                player.GetComponent<PlayerMove>().mudar = 3;
            }
        }   
    }
}
