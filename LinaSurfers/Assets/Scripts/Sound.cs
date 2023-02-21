using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    float volumeMaster;
    public float volumeMoeda;
    public float volumeMusica;

    public Slider sliderMaster, sliderMoeda, sliderMusica;

    // Start is called before the first frame update
    void Start()
    {
        sliderMaster.value = PlayerPrefs.GetFloat("volumeMasterKey");
        sliderMoeda.value = PlayerPrefs.GetFloat("volumeMoedaKey");
        sliderMusica.value = PlayerPrefs.GetFloat("volumeMusicaKey");

        AudioListener.volume = PlayerPrefs.GetFloat("volumeMasterKey");
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.R))
        {
            AudioListener.volume = 0;
        }*/
    }

    public void VolumeMaster(float volume)
    {
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;
        PlayerPrefs.SetFloat("volumeMasterKey", volume);
    }

    public void VolumeMoeda(float moedaVolume)
    {
        volumeMoeda = moedaVolume;
        PlayerPrefs.SetFloat("volumeMoedaKey", moedaVolume);
    }

    public void VolumeMusica(float musicaVolume)
    {
        volumeMusica = musicaVolume;
        PlayerPrefs.SetFloat("volumeMusicaKey", musicaVolume);
    }
}
