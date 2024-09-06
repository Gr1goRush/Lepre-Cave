using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.iOS;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button VolumeButton,VibrButton;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip MenuMusic;
    [SerializeField] Sprite Onn, Off;
    bool on;
    int vib;
    void Start()
    {
       
        on = PlayerPrefs.GetInt("vol") == 1 ? true : false;
        vib = PlayerPrefs.GetInt("sound");
       
        // SwitchVolumeButton();
        if (on)
        {
            VolumeButton.GetComponent<Image>().sprite = Onn;
           
        }
        else
        {
            VolumeButton.GetComponent<Image>().sprite = Off;
            
        }
        if (vib == 1)
        {
           
            VibrButton.GetComponent<Image>().sprite = Onn;
        }
        else
        {
            
            VibrButton.GetComponent<Image>().sprite = Off;
        }

    }

    public void SwitchVolumeButton()
    {
  
        if (on)
        {
            VolumeButton.GetComponent<Image>().sprite = Off;
            on = !on;
            audio.clip = null;
        }
        else
        {
            VolumeButton.GetComponent<Image>().sprite = Onn;
            on = !on;
            audio.clip = MenuMusic;
            audio.Play();
        }
        PlayerPrefs.SetInt("vol", on ? 1 : 0);
    }
    public void SwitchVibrationButton()
    {

        if (vib == 1)
        {
            vib = 0;
            VibrButton.GetComponent<Image>().sprite = Off;
            
        }
        else
        {
            vib = 1;
            VibrButton.GetComponent<Image>().sprite = Onn;
        }
        PlayerPrefs.SetInt("sound", vib);

    }
    public void Rate()
    {
        Device.RequestStoreReview();
    }
}
