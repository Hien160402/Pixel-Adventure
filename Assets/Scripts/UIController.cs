using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public bool GameIsPause = false;
    public GameObject pausePanel;
    public GameObject audioPanel;
    public Slider musicSlider, sfxSlider;
    public Button musicButton;
    public Sprite musicOnSprite; 
    public Sprite musicOffSprite; 
    public Button sfxButton; 
    public Sprite sfxOnSprite; 
    public Sprite sfxOffSprite; 

    private bool isMusicOn = true; 
    private bool isSFXOn = true;
    private bool isSliderZero = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }
   public void Resume()
    {
        pausePanel.SetActive(false);
        audioPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.UnPause();
        }
    }
    public void Option()
    {
        audioPanel.SetActive(true);
    }
    public void Back()
    {
        audioPanel.SetActive(false);
    }
    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn; // dao nguoc trang thai
        AudioManager.instance.ToggleMusic();

        if (isMusicOn)
        {
            musicButton.image.sprite = musicOnSprite;
        }
        else
        {
            musicButton.image.sprite = musicOffSprite;
        }
    } 
    public void ToggleSFX()
    {
        isSFXOn = !isSFXOn;
        AudioManager.instance.ToggleSFX();
        if (isSFXOn)
        {
            sfxButton.image.sprite = sfxOnSprite;
        }
        else
        {
            sfxButton.image.sprite = sfxOffSprite;
        }
    } 
    public void MusicVolume()
    {
        float sliderValue = musicSlider.value;
        AudioManager.instance.MusicVolume(sliderValue);

        if (sliderValue == 0)
        {
            isSliderZero = true;
            musicButton.image.sprite = musicOffSprite;
        }
        else
        {
            isSliderZero = false;

            if (isMusicOn)
            {
                musicButton.image.sprite = musicOnSprite;
            }
            else
            {
                musicButton.image.sprite = musicOffSprite;
            }
        }
    } 
    public void SFXVolume()
    {
        float sliderValue = sfxSlider.value;
        AudioManager.instance.SFXVolume(sfxSlider.value);
        if (sliderValue == 0)
        {
            isSliderZero = true;
            sfxButton.image.sprite = sfxOffSprite;
        }
        else
        {
            isSliderZero = false;

            if (isSFXOn)
            {
                sfxButton.image.sprite = sfxOnSprite;
            }
            else
            {
                sfxButton.image.sprite = sfxOffSprite;
            }
        }
    }
}
