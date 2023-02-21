using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacoes : MonoBehaviour
{
    GameObject player;
    Animator meuAnim;

    public bool pular = false;

    private bool rotacionar = true;

    public bool slide = false;

    public bool morto;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        meuAnim =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rotacionar)
        {
            transform.rotation = new Quaternion(0,  0, 0, 0);
            transform.position =  new  Vector3(player.transform.position.x, player.transform.position.y - 1, player.transform.position.z);
        }

        /*if(slide)
        {
            //transform.position =  new  Vector3(player.transform.position.x - 0.5f, player.transform.position.y - 0.5f, player.transform.position.z);
            transform.position =  new  Vector3(player.transform.position.x - 0.2f, player.transform.position.y - 1.3f, player.transform.position.z);
            rotacionar = false;
            //transform.rotation = new Quaternion(0,  180, 0, 180);
            meuAnim.SetBool("Slide", true);
        }*/

        if(!morto)
        {
        if(slide)
        {
            transform.position =  new  Vector3(player.transform.position.x - 0.5f, player.transform.position.y - 0.5f, player.transform.position.z);
            rotacionar = false;
            transform.rotation = new Quaternion(0,  180, 0, 180);
            meuAnim.SetBool("Slide", true);
        }
        else if(pular)
        {
            meuAnim.SetBool("Jump", true);
        }
        
        if(!pular)
        {
            meuAnim.SetBool("Jump", false);
        }
        if(!slide)
        {
            rotacionar = true;
            meuAnim.SetBool("Slide", false);
        }
        }

        if(morto)
        {
            meuAnim.SetBool("Jump", false);
            meuAnim.SetBool("Slide", false);
            meuAnim.SetBool("Morto", true);
        }

        /*if(pular)
        {
            meuAnim.SetBool("Jump", true);
        }
        else if(!pular)
        {
            meuAnim.SetBool("Jump", false);
        }*/

        /*if(slide)
        {
            transform.position =  new  Vector3(player.transform.position.x, player.transform.position.y - 1.3f, player.transform.position.z);
            rotacionar = false;
            meuAnim.SetBool("Slide", true);
        }
        else if(!slide)
        {
            rotacionar = true;
            meuAnim.SetBool("Slide", false);
        }*/
    }
}
