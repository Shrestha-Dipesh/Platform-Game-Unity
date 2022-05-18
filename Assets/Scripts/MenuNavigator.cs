using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionMenu, detailsMenu;

    [SerializeField]
    private Text playerName;

    [SerializeField]
    private Image playerImage;

    [SerializeField]
    private Sprite circleImage, squareImage;

    private string buttonClicked;

    public void SelectCharacter()
    {
        SceneManager.LoadScene("Player Selection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Select the character based on button clicked and load next scene
    public void LoadGame()
    {
        if (buttonClicked == "Player 1 Button")
        {
            GameManager.instance.SelectedCharacter = "Player 1";
        }
        else if (buttonClicked == "Player 2 Button")
        {
            GameManager.instance.SelectedCharacter = "Player 2";
        }
        SceneManager.LoadScene("Tutorial");
    }

    //Display the character selection menu screen
    public void DisplaySelectionMenu()
    {
        detailsMenu.SetActive(false);
        selectionMenu.SetActive(true);
        Destroy(GameObject.Find("Player1(Clone)"));
    }

    //Display the character detail screen
    public void DisplayDetailsMenu()
    {
        selectionMenu.SetActive(false);
        detailsMenu.SetActive(true);

        //Instantiate the selected character prefab and select it as player
        buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (buttonClicked == "Player 1 Button")
        {
            playerName.text = "Player 1";
            GameObject player1 = Instantiate(Resources.Load("Player1") as GameObject);
            player1.transform.position = new Vector3(-3.91f, -3.038f, 0f);
            player1.transform.localScale = new Vector3(0.3900645f, 0.3900645f, 0.3900645f);
            Destroy(player1.GetComponent("Rigidbody2D"));
            Destroy(player1.GetComponent("Player"));
        }
        else if (buttonClicked == "Player 2 Button")
        {
            playerName.text = "Player 2";
            playerImage.sprite = squareImage;
        }
    }
}
