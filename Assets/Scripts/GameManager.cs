using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameEnded = false;
    public float restartDelay = 1f;

    [SerializeField]
    private GameObject[] characters;

    private string selectedCharacter;
    public string SelectedCharacter
    {
        get { return selectedCharacter; }
        set { selectedCharacter = value; }
    }

    private GameObject levelElements, completeUI, gameOverUI;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        levelElements.SetActive(false);
        Invoke("RestartGame", restartDelay);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishLoading;
    }

    private void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1")
        {
            if (selectedCharacter == "Player 1")
            {
                Instantiate(characters[0]);
            }
            else
            {
                Instantiate(characters[1]);
            }

            levelElements = GameObject.Find("Level Elements");
            completeUI = GameObject.Find("Complete UI");
            gameOverUI = GameObject.Find("Game Over UI");

            completeUI.SetActive(false);
            gameOverUI.SetActive(false);
        }
    }

    public void LevelComplete()
    {
        completeUI.SetActive(true);
        levelElements.SetActive(false);
    }
}
