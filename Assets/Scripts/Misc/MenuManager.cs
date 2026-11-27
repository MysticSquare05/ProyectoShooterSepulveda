using UnityEngine;

public class MenuManager : MonoBehaviour
{
    
    
    void Start()
    {
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
