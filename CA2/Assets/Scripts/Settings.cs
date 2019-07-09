using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);//uses a log function to scale volume properly
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);  //load the main menu
    }
    public void SettingMenu()
    {
        SceneManager.LoadScene(1);  //load the settings menu
    }
    public void HelpMenu()
    {
        SceneManager.LoadScene(2);  //load the help menu
    }
    public void StartGame()
    {
        SceneManager.LoadScene(3);  //load the game
    }

}
