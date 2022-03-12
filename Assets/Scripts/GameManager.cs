using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameEnded = false;
    public float restartDelay = 1f;

    public void GameOver()
    {
        gameEnded = true;
        Invoke("RestartGame", restartDelay);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
