using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    Font pixelFont;
    GUIStyle gameStyle()
    {
        pixelFont = Resources.Load("Font/PixeloidSans") as Font;
        GUIStyle style = new GUIStyle();
        style.font = pixelFont;
        return style;
    }
    void OnGUI()
    {        
        //Main menu button
        if (GUI.Button(new Rect(Screen.width-130, Screen.height-50, 120, 40), "Main Menu", gameStyle()))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        //Weights button
        if (GUI.Button(new Rect(10, 10, 120, 40), "BUTTON", gameStyle()))
        {
            SceneManager.LoadScene("Weightlifting", LoadSceneMode.Single);
        }
    }
}