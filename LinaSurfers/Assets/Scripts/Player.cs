using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float posicao1, posicao2;
    public int qualPosicao = 1;
    public float posicao;
    public GameObject painel;
    GameObject player;
    public GameObject animado;
    public int moedas;
    public Text moedasTxt;
    public Text scoreTxt;
    public float score = 0;
    public bool morto = false;
    public int moedasTotais;
    public bool aconteceu = false;

    public GameObject painel2;

    AudioSource musicaFundo;

    GameObject sons;

    public GameObject painel3;

    public bool podeMorrer = true;

    private bool pausado = false;
    private bool configuracoes = false;

    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Teste", 1f, 0.1f);
        painel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMove>().morto = false;
        animado.GetComponent<Animacoes>().morto = false;

        painel2.SetActive(false);
        painel3.SetActive(false);

        musicaFundo = GetComponent<AudioSource>();

        sons = GameObject.FindGameObjectWithTag("Sons");

        Screen.SetResolution (1080, 1920, true);

        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        musicaFundo.volume = sons.GetComponent<Sound>().volumeMusica;

        if(!morto)
        {
            moedasTxt.text = moedas.ToString();
            score += Time.deltaTime * 5;
            scoreTxt.text = score.ToString("F0");
        }

        if(morto)
        {
            if(!aconteceu)
            {
                if(score > PlayerPrefs.GetFloat("bestScoreKey"))
                {
                    PlayerPrefs.SetFloat("bestScoreKey", score);
                }

                moedasTotais = moedas + PlayerPrefs.GetInt("totalMoedasKey");
                PlayerPrefs.SetInt("totalMoedasKey", moedasTotais);
                Invoke("Pausar", 3.5f);
                aconteceu = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pausado)
            {
                Time.timeScale = 0;
                painel2.SetActive(true);
                Pausar();
                painel3.SetActive(false);
                configuracoes = false;
                pausado = true;
            }
            else if(pausado)
            {
                if(configuracoes)
                {
                    Time.timeScale = 0;
                    painel2.SetActive(true);
                    Pausar();
                    painel3.SetActive(false);
                    configuracoes = false;
                    pausado = true;
                }
                else if(!configuracoes)
                {
                    painel2.SetActive(false);
                    Time.timeScale = 1;
                    Despausar();
                    pausado = false;
                }
            }
        }
    }

    void Pausar()
    {
        musicaFundo.Pause();
    }
    void Despausar()
    {
        musicaFundo.Play();
    }

    void Teste()
    {
        if(qualPosicao == 1)
        {
            posicao1 = transform.position.z;
            qualPosicao = 2;
        }
        else if(qualPosicao == 2)
        {
            posicao2 = transform.position.z;
            qualPosicao = 1;
        }

        if(posicao1 > posicao2)
        {
            posicao = posicao1 - posicao2;
        }
        if(posicao1 < posicao2)
        {
            posicao = posicao2 - posicao1;
        }
        if(posicao1 == posicao2)
        {
            if(podeMorrer)
            {
                morto  = true;
                player.GetComponent<PlayerMove>().morto = true;
                animado.GetComponent<Animacoes>().morto = true;
                Invoke("Painel", 3.5f);
            }else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            }
        }
        if(posicao < 0.4f)
        {
            if(podeMorrer)
            {
                morto  = true;
                player.GetComponent<PlayerMove>().morto = true;
                animado.GetComponent<Animacoes>().morto = true;
                Invoke("Painel", 3.5f);
            }else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            }
        }
    }

    void Painel()
    {
        painel.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        Despausar();
    }
    public void HomeScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TelaInicial");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        painel2.SetActive(true);
        Pausar();
        painel3.SetActive(false);
        configuracoes = false;
        pausado = true;
    }
    public void Continuar()
    {
        painel2.SetActive(false);
        Time.timeScale = 1;
        Despausar();
        pausado = false;
    }

    public void Config()
    {
        painel3.SetActive(true);
        painel2.SetActive(false);
        configuracoes = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag  == "Rampa")
        {
            podeMorrer = false;
        }

        if(col.gameObject.tag  == "Colisor")
        {
            player.GetComponent<PlayerMove>().morto = true;
            animado.GetComponent<Animacoes>().morto = true;
            TremMovimento.mortoTremMovimento = true;
            transform.position = Vector3.MoveTowards(transform.position, cam.transform.position, 5f);
            Invoke("Painel", 3.5f);
        }
    }
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag  == "Rampa")
        {
            podeMorrer = true;
        }
    }
}