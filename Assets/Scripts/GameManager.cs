using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameEnded = false;

    [SerializeField]
    private GameObject[] characters;

    private string selectedCharacter;
    public string SelectedCharacter
    {
        get { return selectedCharacter; }
        set { selectedCharacter = value; }
    }

    private GameObject levelElements, completeUI, youDiedUI, pressToMoveText, pressToJumpText, stayAwayText, collectCoinText, skipButton, gameOverUI;

    private bool checkForSteps, firstStepCompleted, secondStepCompleted, thirdStepCompleted, fourthStepCompleted, fifthStepCompleted, sixthStepCompleted;

    private int lifeCount = 3, coinCount = 0;
    private bool canCollect = false;

    public void Awake()
    {
        //Singleton pattern to make sure there is only instance of game manager
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
        //Display the game over screen and decrease the life
        gameEnded = true;
        IEnumerator ExecuteCode(float time)
        {
            yield return new WaitForSeconds(time);
            levelElements.SetActive(false);

            lifeCount--;
            if (lifeCount == 0)
            {
                gameOverUI.SetActive(true);
            }
            else
            {
                youDiedUI.SetActive(true);
            }
        }
        StartCoroutine(ExecuteCode(0.5f));
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
        //Reset the components
        StopAllCoroutines();
        canCollect = false;
        GameObject player;

        //Instantiate the selected character prefab
        if (scene.name == "Tutorial" || scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3")
        {
            if (selectedCharacter == "Player 1")
            {
                player = Instantiate(characters[0]);
            }
            else
            {
                player = Instantiate(characters[1]);
            }

            player.transform.parent = GameObject.Find("Level Elements").transform;
        }

        //Reset the tutorial level components
        if (scene.name == "Tutorial")
        {
            lifeCount = 3;
            coinCount = 0;
            firstStepCompleted = false;
            secondStepCompleted = false;
            thirdStepCompleted = false;
            fourthStepCompleted = false;
            fifthStepCompleted = false;
            sixthStepCompleted = false;
            checkForSteps = true;
            pressToMoveText = GameObject.Find("Press to move");
            pressToJumpText = GameObject.Find("Press to jump");
            stayAwayText = GameObject.Find("Stay away");
            collectCoinText = GameObject.Find("Collect coin");
            completeUI = GameObject.Find("Level Complete");
            levelElements = GameObject.Find("Level Elements");
            youDiedUI = GameObject.Find("Try Again");
            skipButton = GameObject.Find("Skip");

            pressToJumpText.SetActive(false);
            stayAwayText.SetActive(false);
            collectCoinText.SetActive(false);
            completeUI.SetActive(false);
            youDiedUI.SetActive(false);
            skipButton.SetActive(false);

            IEnumerator ShowSkip(float time)
            {
                yield return new WaitForSeconds(time);

                skipButton.SetActive(true);
            }

            StartCoroutine(ShowSkip(3));
        }
        else
        {
            //Reset the components for rest of the levels
            checkForSteps = false;
            
            if (scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3")
            {
                canCollect = true;
                ChangeLife(0);
                IncreaseCoin(0);

                youDiedUI = GameObject.Find("You Died");
                levelElements = GameObject.Find("Level Elements");
                completeUI = GameObject.Find("Level Complete");
                gameOverUI = GameObject.Find("Game Over");
                
                youDiedUI.SetActive(false);
                completeUI.SetActive(false);
                gameOverUI.SetActive(false);
            }
        }
    }

    //Tutorial level instruction mechanism
    private void CheckSteps()
    {
        //Check for player movement
        if (!firstStepCompleted)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                firstStepCompleted = true;
                IEnumerator ExecuteCode(float time)
                {
                    yield return new WaitForSeconds(time);
                    
                    pressToMoveText.SetActive(false);
                    pressToJumpText.SetActive(true);
                    secondStepCompleted = true;
                }
                StartCoroutine(ExecuteCode(3));
            }
        }

        //Check for player jump and load the enemies
        if (secondStepCompleted && !thirdStepCompleted)
        {
            thirdStepCompleted = true;
            IEnumerator ExecuteCode(float time)
            {
                yield return new WaitForSeconds(time);

                pressToJumpText.SetActive(false);
                stayAwayText.SetActive(true);
                GameObject enemy = Instantiate(Resources.Load("Enemy") as GameObject);
                GameObject spike = Instantiate(Resources.Load("Spike") as GameObject);
                enemy.transform.parent = GameObject.Find("Level Elements").transform;
                enemy.transform.position = new Vector3(-0.2612625f, -4.062554f, 0f);
                Vector2 currentScale = enemy.transform.localScale;
                spike.transform.position = new Vector3(8.50f, -3.06f, 0f);
                spike.transform.parent = GameObject.Find("Level Elements").transform;
                currentScale.x *= -1;
                enemy.transform.localScale = currentScale;
                fourthStepCompleted = true;

            }
            StartCoroutine(ExecuteCode(3));
        }

        //Load the coins and mushrooms
        if (fourthStepCompleted && !fifthStepCompleted)
        {
            fifthStepCompleted = true;

            IEnumerator ExecuteCode(float time)
            {
                yield return new WaitForSeconds(time);

                if (firstStepCompleted)
                {
                    stayAwayText.SetActive(false);
                    collectCoinText.SetActive(true);
                    GameObject coin = Instantiate(Resources.Load("Coin") as GameObject);
                    coin.transform.position = new Vector3(-0.1177264f, -0.8959059f, 0f);
                    GameObject mushroom = Instantiate(Resources.Load("Mushroom") as GameObject);
                    mushroom.transform.position = new Vector3(8.386995f, -1.45504f, 0f);
                    sixthStepCompleted = true;
                }

            }
            StartCoroutine(ExecuteCode(5));
        }

        //Complete the tutorial
        if (sixthStepCompleted)
        {
            if (GameObject.Find("Coin(Clone)") == null && GameObject.Find("Mushroom(Clone)") == null)
            {
                LevelComplete();
            }
        }
    }

    //Display level complete UI
    public void LevelComplete()
    {
        completeUI.SetActive(true);
        levelElements.SetActive(false);
    }

    private void Update()
    {
        //Allow step checks
        if (checkForSteps)
        {
            CheckSteps();
        }
    }

    //Increase/Decrease the life and display in UI
    public void ChangeLife(int lifeCount)
    {
        if (canCollect)
        {
            this.lifeCount += lifeCount;
            Text lifeCountUI = GameObject.Find("Life Count").GetComponent<Text>();
            lifeCountUI.text = "x " + this.lifeCount;
        }
    }

    //Increase the coin count and display in UI
    public void IncreaseCoin(int coinCount)
    {
        if (canCollect)
        {
            this.coinCount += coinCount;
            Text coinCountUI = GameObject.Find("Coin Count").GetComponent<Text>();

            if (this.coinCount == 100)
            {
                this.coinCount = 0;
                ChangeLife(1);
            }
            coinCountUI.text = "x " + this.coinCount;
        }
    }

    //Getter for lifeCount
    public int getLifeCount()
    {
        return lifeCount;
    }
}
