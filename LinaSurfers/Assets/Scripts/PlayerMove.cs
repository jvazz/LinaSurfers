using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float velocidade;
    public float velociadeLane;
    private Vector3 posicao;
    private int lane = 1;
    public float lane0, lane1, lane2;
    private float ondeIr;
    public float forcaPulo;
    public LayerMask layerMask;
    private bool isGrounded;
    public float groundCheckSize;
    public Vector3 groundCheckPosition;
    public float gravidade;
    public int vezes;
    private bool pular = false;
    private bool sliding = false;
    private float slideStart;
    private BoxCollider boxCollider;
    public float slideLenth;
    private Vector3 boxColliderSize;
    public GameObject camera;
    public bool altura = false;
    public GameObject testeEsquerda;
    public GameObject testeDireita;
    public int mudar = 0;
    public GameObject animado;
    public bool baseTrilhos = true;
    public bool morto;
    public bool slideAuto = false;
    private float gravidadeN;

    private bool isSwipping = false;
    private Vector2 startingTouch;

    public int puloMobile;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ondeIr = lane1;
        boxCollider = GetComponent<BoxCollider>();
        boxColliderSize = boxCollider.size;

        gravidadeN = gravidade;
    }

    // Update is called once per frame
    void Update()
    {
        if(!morto)
        {
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(isGrounded && !sliding)
            {
                slideStart = transform.position.z;
                Vector3 newSize = boxCollider.size;
                newSize.y = newSize.y / 2;
                boxCollider.size = newSize;
                sliding = true;
            }

            if(!isGrounded && !sliding)
            {
                gravidade = - 25f;
                slideAuto =  true;
            }
        }

        if(slideAuto)
        {
            if(isGrounded)
            {
                gravidade = gravidadeN;
                slideAuto =  false;
                /*slideStart = transform.position.z;
                Vector3 newSize = boxCollider.size;
                newSize.y = newSize.y / 2;
                boxCollider.size = newSize;
                sliding = true;*/
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(isGrounded)
            {
                vezes = 0;
                pular = true;
                //rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
                //transform.position += transform.up * 1000 * Time.deltaTime;
            }
        }

        Movimentar();
        }

        if(sliding)
        {
            float ratio = (transform.position.z - slideStart) / slideLenth;
            if(ratio >= 1)
            {
                sliding = false;
                boxCollider.size = boxColliderSize;
            }
        }

        var groundcheck = Physics.OverlapSphere(transform.position + groundCheckPosition, groundCheckSize, layerMask);
        if(groundcheck.Length != 0)
        {
            isGrounded = true;
        }else
        {
            isGrounded = false;
        }

        if(!isGrounded)
        {
            transform.position += transform.up * gravidade * Time.deltaTime;
        }

        if(altura)
        {
            if(camera.transform.position.y > 6 && camera.transform.position.y < 7)
            {
                camera.GetComponent<Camera>().rampa = false;
                altura = false;
            }
        }

        if(mudar == 1)
        {
            transform.position = new Vector3(lane0, transform.position.y, transform.position.z);
            //mudar = 0;
        }
        if(mudar == 2)
        {
            transform.position = new Vector3(lane1, transform.position.y, transform.position.z);
            //mudar = 0;
        }
        if(mudar == 3)
        {
            transform.position = new Vector3(lane2, transform.position.y, transform.position.z);
            //mudar = 0;
        }
        
        if(mudar != 0)
        {
            if(testeDireita.GetComponent<TesteDireita>().direita)
            {
                if(mudar == 1)
                {
                    ondeIr = lane0;
                    lane = 0;
                }
                if(mudar == 2)
                {
                    ondeIr = lane1;
                    lane = 1;
                }
                if(mudar == 3)
                {
                    ondeIr = lane2;
                    lane = 2;
                }
                mudar = 0;
            }
        }


        if(pular)
        {
            animado.GetComponent<Animacoes>().pular = true;
        }
        if(isGrounded)
        {
            animado.GetComponent<Animacoes>().pular = false;
        }

        /*if(transform.position.y < 2)
        {
            baseTrilhos = true;
            camera.GetComponent<Camera>().rampa = false;
        }*/

        if(transform.position.y < 2)
        {
            baseTrilhos = true;
            if(camera.transform.position.y < 10)
            {
                camera.GetComponent<Camera>().rampa = false;
            }else if(camera.transform.position.y > 10)
            {
                camera.GetComponent<Camera>().rampa = true;
            }
        }

        if(sliding)
        {
            animado.GetComponent<Animacoes>().slide = true;
        }
        if(!sliding)
        {
            animado.GetComponent<Animacoes>().slide = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag  == "Rampa")
        {
            velocidade = velocidade * 3f;
            //camera.GetComponent<Camera>().rampa = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag  == "Rampa")
        {
            velocidade = velocidade / 3f;
            camera.GetComponent<Camera>().rampa = false;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag  == "Altura")
        {
            //Problema camera era aqui
            if(!baseTrilhos)
            {
                camera.GetComponent<Camera>().rampa = true;
                altura = true;
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag  == "Altura")
        {
            Invoke("Topo", 0.1f);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag  == "Rampa")
        {
            //velocidade = velocidade * 2;
            camera.GetComponent<Camera>().rampa = true;
        }
    }

    /*void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag  == "Base")
        {
            baseTrilhos = true;
            camera.GetComponent<Camera>().rampa = false;
        }
    }*/

    void Topo()
    {
        camera.GetComponent<Camera>().rampa = false;
        altura = false;

        baseTrilhos = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + groundCheckPosition, groundCheckSize);
    }

    private void FixedUpdate()
    {
        if(pular)
        {
            if(vezes < 10)
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
                vezes++;
            }
        }

        //rb.velocity = Vector3.forward * velocidade;

        if(!morto)
        {
            rb.velocity = Vector3.forward * velocidade;
        }
    }

    void Movimentar()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(testeEsquerda.GetComponent<TesteEsquerda>().esquerda)
            {
                if(lane == 1)
                {
                    lane = 0;
                    ondeIr = lane0;
                }
                else if(lane == 2)
                {
                    lane = 1;
                    ondeIr = lane1;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(testeDireita.GetComponent<TesteDireita>().direita)
            {
                if(lane == 1)
                {
                    lane = 2;
                    ondeIr = lane2;
                }
                else if(lane == 0)
                {
                    lane = 1;
                    ondeIr = lane1;
                }
            }
        }


        if(Input.touchCount == 1)
        {
            if(isSwipping)
            {
                Vector2 diff = Input.GetTouch(0).position - startingTouch;
                diff = new Vector2(diff.x / Screen.width, diff.y / Screen.width);
                if(diff.magnitude > 0.01f)
                {
                    if(Mathf.Abs(diff.y) > Mathf.Abs(diff.x))
                    {
                        if(diff.y < 0)
                        {
                            if(isGrounded && !sliding)
                            {
                                slideStart = transform.position.z;
                                Vector3 newSize = boxCollider.size;
                                newSize.y = newSize.y / 2;
                                boxCollider.size = newSize;
                                sliding = true;
                            }

                            if(!isGrounded && !sliding)
                            {
                                gravidade = - 25f;
                                slideAuto =  true;
                            }
                        }
                        else
                        {
                            if(isGrounded)
                            {
                                //vezes = 0;
                                vezes = puloMobile;
                                pular = true;
                            }
                        }
                    }
                    else
                    {
                        if(diff.x < 0)
                        {
                            if(testeEsquerda.GetComponent<TesteEsquerda>().esquerda)
                            {
                                if(lane == 1)
                                {
                                    lane = 0;
                                    ondeIr = lane0;
                                }
                                else if(lane == 2)
                                {
                                    lane = 1;
                                    ondeIr = lane1;
                                }
                            }
                        }
                        else
                        {
                            if(testeDireita.GetComponent<TesteDireita>().direita)
                            {
                                if(lane == 1)
                                {
                                    lane = 2;
                                    ondeIr = lane2;
                                }
                                else if(lane == 0)
                                {
                                    lane = 1;
                                    ondeIr = lane1;
                                }
                            }
                        }

                        isSwipping = false;
                    }
                }
            }

            if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startingTouch = Input.GetTouch(0).position;
            isSwipping = true;
        }
        else if(Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isSwipping = false;
        }
        }

        posicao = new Vector3(ondeIr, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, posicao, velociadeLane* Time.deltaTime);
    }
}
