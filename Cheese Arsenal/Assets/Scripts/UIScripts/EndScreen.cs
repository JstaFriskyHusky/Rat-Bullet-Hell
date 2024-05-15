using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        Invoke("ShowButton", 6.5f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        SceneManager.LoadSceneAsync(0);            
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ShowButton()
    {
        button.SetActive(true);
    }
}
