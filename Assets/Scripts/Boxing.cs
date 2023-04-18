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
    void Start()
    {
        buttons = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
        Letter = GameObject.FindObjectOfType<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pickbutton();
        Letter.text = touchbutton;
        if (Input.anyKeyDown)
        {

        }

    }
    void pickbutton()
    {
        
        if (picked == false)
        {
            int index = Random.Range(0,buttons.Length);
            touchbutton = buttons[index];
            Debug.Log(touchbutton);
            picked = true;
        }
    }
}
