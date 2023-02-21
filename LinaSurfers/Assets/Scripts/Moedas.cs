using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas : MonoBehaviour
{
    GameObject player;
    AudioSource sound;

    GameObject sons;

    GameObject particula;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sound = GetComponent<AudioSource>();
        sound.volume = PlayerPrefs.GetFloat("volumeMoedaKey");
        sons = GameObject.FindGameObjectWithTag("Sons");
        particula = GameObject.FindGameObjectWithTag("ParticulaMoeda");
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = sons.GetComponent<Sound>().volumeMoeda;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag  == "Player")
        {
            sound.Play();
            player.GetComponent<Player>().moedas++;
            Instantiate(particula, transform.position, transform.rotation);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Invoke("Morrer", 0.5f);
            //Destroy(this.gameObject);
        }
    }

    void Morrer()
    {
        Destroy(this.gameObject);
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas : MonoBehaviour
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
            player.GetComponent<Player>().moedas++;
            Destroy(this.gameObject);
        }
    }
}
*/
