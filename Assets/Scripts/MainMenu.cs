using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Font pixelFont;
    GUIStyle gameStyle()
    {
        pixelFont = Resources.Load("Font/PixeloidSans") as Font;
        GUIStyle style = new GUIStyle();
        style.font = pixelFont;
        style.fontSize = 40;
        GUI.color = Color.blue;
        return style;
    }
void OnGUI()
    {        
        //Main menu button
        if (GUI.Button(new Rect(Screen.width/2, Screen.height/2, 120, 40), "START", gameStyle()))
        {
            SceneManager.LoadScene("GymMenu", LoadSceneMode.Single);
        }
    }
}
