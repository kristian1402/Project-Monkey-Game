using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Boxing : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    string[] buttons;
    string pickedbutton;
    bool picked = false;
    TMP_Text Letter;
    string touchbutton;
    int index;
    KeyCode[] keyCodes;
    void Start()
    {
        buttons = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V"
        , "W", "X", "Y", "Z"};
        keyCodes = new KeyCode[] {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I,
        KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
        KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};
        Letter = GameObject.FindObjectOfType<TMP_Text>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
                picked = false;
                ChangeSprite();
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
 int spriteIndex = 0;

    void ChangeSprite()
    {
        Debug.Log(spriteIndex);
        if (spriteIndex < spriteArray.Length)
        {
            spriteRenderer.sprite = spriteArray[spriteIndex];
            spriteIndex++;
        }
        else
        {
            // Reset sprite index to 0 if it exceeds the number of sprites in the array
            spriteIndex = 0;
            spriteRenderer.sprite = spriteArray[spriteIndex];
        }
    }
}
