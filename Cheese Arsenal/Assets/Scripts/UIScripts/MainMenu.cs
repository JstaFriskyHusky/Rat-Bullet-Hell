using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public static bool isShown;

    void Start()
    {
        controlsMenu.SetActive(false);
    }

    void Update()
    {
        // If player hits esc, remove control panel
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            controlsMenu.SetActive(false);
        }
    }

    // Press Start will transition to next scene (The game)
    public void PlayGame()
    {
        // Delayed loading to allow sound effects to fully play
        Invoke("LoadScene", 1f);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ShowControls()
    {
        if(isShown == false)
        {
            controlsMenu.SetActive(true);
        } 
    }

    public void ExitControls()
    {
        controlsMenu.SetActive(false);
    }
}
