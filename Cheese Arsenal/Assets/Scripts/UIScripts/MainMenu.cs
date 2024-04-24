using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Press Start will transition to next scene (The game)
    public void PlayGame()
    {
        // Delayed loading to allow sound effects to fully play
        Invoke("LoadScene", 1.5f);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
