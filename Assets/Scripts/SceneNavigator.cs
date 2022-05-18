using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager.getLifeCount() == 1)
        {
            gameManager.GameOver();
        }
        else
        {
            gameManager.ChangeLife(-1);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
