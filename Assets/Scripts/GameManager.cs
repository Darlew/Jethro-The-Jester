using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    bool hasKey = false;
    public Notification notification;
    
    public void CompleteLevel()
    {
        if(hasKey == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            notification.updateText("You need to find the key!");
        }
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void getKey()
    {
        hasKey = true;
    }
}
