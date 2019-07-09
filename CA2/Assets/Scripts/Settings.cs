using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene(0);  //load the main menu
    }
    public void SettingMenu()
    {
        SceneManager.LoadScene(1);  //load the settings menu
    }
}
