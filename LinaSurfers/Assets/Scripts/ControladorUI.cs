using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour
{
    public float bestScore;
    public int totalMoedas;

    public Text totalMoedasTxt;
    public Text bestScoreTxt;

    public GameObject painelConfig;
    public GameObject painelAjuda;

    GameObject sons;

    public AudioSource musicaFundo;

    public GameObject btnConfig;
    public GameObject btnAjuda;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetFloat("bestScoreKey");
        totalMoedas = PlayerPrefs.GetInt("totalMoedasKey");
        painelConfig.SetActive(false);

        sons = GameObject.FindGameObjectWithTag("Sons");
        painelAjuda.SetActive(false);

        Screen.SetResolution (1080, 1920, true);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("bestScoreKey", bestScore);
        PlayerPrefs.SetInt("totalMoedasKey", totalMoedas);
        bestScoreTxt.text = bestScore.ToString("F0");
        totalMoedasTxt.text = totalMoedas.ToString();

        musicaFundo.volume = sons.GetComponent<Sound>().volumeMusica;
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Fechar()
    {
        painelConfig.SetActive(false);
        painelAjuda.SetActive(false);
        btnConfig.SetActive(true);
        btnAjuda.SetActive(true);
    }

    public void Config()
    {
        painelConfig.SetActive(true);
        painelAjuda.SetActive(false);
        btnConfig.SetActive(false);
        btnAjuda.SetActive(false);
    }

    public void Ajuda()
    {
        painelConfig.SetActive(false);
        painelAjuda.SetActive(true);
        btnConfig.SetActive(false);
        btnAjuda.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
