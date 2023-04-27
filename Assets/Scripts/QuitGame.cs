using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button exitButton; // Reference to the UI button

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame); // Assign the QuitGame method to the button's OnClick event
    }

    public void ExitGame()
    {
        Application.Quit(); // Quit the application
    }
}

