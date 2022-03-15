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
        SceneManager.LoadScene("Level 1");
    }

    public void DisplaySelectionMenu()
    {
        detailsMenu.SetActive(false);
        selectionMenu.SetActive(true);
    }

    public void DisplayDetailsMenu()
    {
        selectionMenu.SetActive(false);
        detailsMenu.SetActive(true);

        buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (buttonClicked == "Player 1 Button")
        {
            playerName.text = "Circle";
            playerImage.sprite = circleImage;
        }
        else if (buttonClicked == "Player 2 Button")
        {
            playerName.text = "Square";
            playerImage.sprite = squareImage;
        }
    }
}
