using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Color farve;
    void OnGUI()
    {
        GUI.backgroundColor = farve;
        //Main menu button
        if (GUI.Button(new Rect(Screen.width-130, Screen.height-50, 120, 40), "Main Menu"))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        //Weights button
        if (GUI.Button(new Rect(10, 10, 120, 40), "BUTTON"))
        {
            SceneManager.LoadScene("Weights", LoadSceneMode.Single);
        }
    }
}