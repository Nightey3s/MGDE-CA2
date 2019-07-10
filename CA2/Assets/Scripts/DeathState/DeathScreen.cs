using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;

    public void RetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ReturnButtonClicked()
    {
         SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Displays the death screen
    /// </summary>
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Sets a score to be displayed
    /// </summary>
    /// <param name="score"></param>
    public void SetScore(int score)
    {
        scoreDisplay.text = score.ToString("D5") + "s";
    }
}
