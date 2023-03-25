using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Slider _musicSlider, _sfxSlider;
    public Sprite musicOff;
    public Sprite musicOn;
    public GameObject musicIcon;
    public Sprite soundOff;
    public Sprite soundOn;
    public GameObject soundIcon;


    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }


    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }


    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    public void changeMusicSprite()
    {
        if (musicIcon.GetComponent<Image>().sprite == musicOn)
        {
            // getting Image component of musicIcon and changing it
            musicIcon.GetComponent<Image>().sprite = musicOff;
            Debug.Log("Debugging this");
        }
        else
        {
            musicIcon.GetComponent<Image>().sprite = musicOn;
        }

    }

    public void changeSoundSprite()
    {
        if (soundIcon.GetComponent<Image>().sprite == soundOn)
        {
            // getting Image component of soundIcon and changing it
            soundIcon.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            soundIcon.GetComponent<Image>().sprite = soundOn;
        }
    }


}
