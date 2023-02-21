using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;

    public bool rampa = false;

    public GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - transform.up*1.3f - player.position;
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!rampa)
        {
            Vector3 newPosition = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);
            transform.position = newPosition;
        }
        else if(rampa)
        {
            Vector3 newPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
            transform.position = newPosition;
        }

        if(transform.position.y > 14)
        {
            rampa = true;
        }

        if(playerGameObject.transform.position.y < 1)
        {
            if(transform.position.y > 8)
            {
                rampa = true;
            }
        }
    }
}
