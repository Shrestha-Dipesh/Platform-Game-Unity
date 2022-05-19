using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    //Load the next scene
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Load the menu scene
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //Restart the level and decrease the life
    public void RestartLevel()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager.getLifeCount() == 1)
        {
            gameManager.GameOver();
        }
        else
        {
            gameManager.ChangeLife(-1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //Restart the level only
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
