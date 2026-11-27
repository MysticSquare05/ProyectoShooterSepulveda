using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;



public class ScoreHUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;

    public GameObject keyHUD;

    public TextMeshProUGUI livesText;

    public CanvasGroup fader;

    public float fadeDuration = 1f;
    private float currentFadeTime = 0f;

    public bool faderActive = false;

    public CanvasGroup winScreen;

    public string nextLevel;

    private void Start()
    {
        fader.alpha = 1;
        faderActive = false;
        
        RefreshScore();
        keyHUD.SetActive(false);
        RefreshLives();
    }

    private void Update()
    {
        Debug.Log("True");
        if (currentFadeTime > 0 && faderActive == false)
        {
            currentFadeTime -= Time.deltaTime;
            fader.alpha = currentFadeTime / fadeDuration;
        }

        if (currentFadeTime <= 1 && faderActive == true)
        {
            currentFadeTime += Time.deltaTime;
            fader.alpha = currentFadeTime / fadeDuration;
        }
    }

    public void RefreshLives()
    {
        livesText.text = $"X{playerHealth.lives}";
    }
    public void RefreshScore()
    {
        scoreText.text = $"Score: {playerMovement.score}";
    }

    public void ShowKeyHUD()
    {
        keyHUD.SetActive(true);
    }

    public void ShowWinScreen()
    {
        winScreen.alpha = 1;
        winScreen.interactable = true;
        winScreen.blocksRaycasts = true;
        
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
    }
}
