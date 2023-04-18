using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Boxing : MonoBehaviour
{
    // Start is called before the first frame update
    string[] buttons;
    string pickedbutton;
    bool picked = false;
    TMP_Text Letter;
    string touchbutton;
    int index;
    KeyCode[] keyCodes;
    void Start()
    {
        buttons = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
        keyCodes = new KeyCode[] {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H};
        Letter = GameObject.FindObjectOfType<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int test = pickbutton();
        Letter.text = touchbutton;
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(keyCodes[test]))
            {
                Debug.Log("Sucess");
            }
            else
            {
                Debug.Log("Fail");
            }
        }

    }
    int pickbutton()
    {
        if (picked == false)
        {
            index = Random.Range(0,buttons.Length);
            touchbutton = buttons[index];
            Debug.Log(touchbutton);
            picked = true;
        }
        return index;
    }
}
