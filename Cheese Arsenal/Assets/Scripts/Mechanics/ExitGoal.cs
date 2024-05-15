using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D player)   
    {
        Debug.Log("Triggered");     
        if(player.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(2);
        }
    }        
}
