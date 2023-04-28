using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class Boxing : MonoBehaviour
{
    // Start is called before the first frame update
    SaveDataReader saveData;
    string[] values;
    string[] buttons;
    string pickedbutton;
    bool picked = false;
    TMP_Text Letter;
    TMP_Text Exhausted;
    TMP_Text Score;
    string touchbutton;
    int index;
    public AudioSource audiosource;
    public AudioClip boxing;
    public AudioClip boxing2;
    KeyCode[] keyCodes;
    GameObject defence;
    GameObject hitLeft;
    GameObject hitRight;
    int spriteIndex = 0;
    int health = 3;
    bool alive = true;
    int score = 0;
    float level;
    void Start()
    {
        saveData = GameObject.FindObjectOfType<SaveDataReader>();
        buttons = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V"
        , "W", "X", "Y", "Z"};
        keyCodes = new KeyCode[] {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I,
        KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
        KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};
        Letter = GameObject.Find("Letter").GetComponent<TMP_Text>();
        Exhausted = GameObject.Find("Exhausted").GetComponent<TMP_Text>();
        Score = GameObject.Find("Score").GetComponent<TMP_Text>();

        hitLeft = GameObject.Find("Left");
        hitRight = GameObject.Find("Right");
        defence = GameObject.Find("Main");

        Exhausted.text = "";
        Score.text = score.ToString();
        hitLeft.SetActive(false);
        hitRight.SetActive(false);
        defence.SetActive(true);
        Letter.rectTransform.position = new Vector3(8.5f, 3, 0);

        values = saveData.getData();
        level = float.Parse(values[5]);
        Debug.Log(level);
        StartCoroutine(MoveText());

    }

    // Update is called once per frame
    IEnumerator MoveText()
    {
        while (true)
        {
            // Move the text 200 pixels to the left each second
            
            Letter.rectTransform.position -= new Vector3((1+(score/(3+level))) * Time.deltaTime, 0, 0);
            
            if (Letter.rectTransform.position.x < (-5))
            {
                health--;
                Letter.rectTransform.position = new Vector3(8.5f, 3, 0);
                Debug.Log(health);
            }

            // Wait for the next frame
            yield return null;
        }
    }
    void Update()
    {
        int test = pickbutton();
        Score.text = score.ToString();
        Letter.text = touchbutton;
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(keyCodes[test]) && alive == true)
            {
                int s = Random.Range(1,3);
                Debug.Log(s);
                picked = false;
                Letter.rectTransform.position = new Vector3(8.5f, 3, 0);
                score++;
                if (s == 1)
                {
                    audiosource.PlayOneShot(boxing, 50);
                }
                else
                {
                    audiosource.PlayOneShot(boxing2, 50);
                }
                
                ChangeSprite();

            }
            else
            {
                health--;
            }
        }
        
        if (health < 1)
        {
            Exhausted.text = "Exhausted";
            alive = false;
        }
    }
    int pickbutton()
    {
        if (picked == false)
        {
            index = Random.Range(0,buttons.Length);
            touchbutton = buttons[index];
            //Debug.Log(touchbutton);
            picked = true;
        }
        return index;
    }

    void ChangeSprite()
    {
        spriteIndex++;
        //Debug.Log(spriteIndex);

        if (spriteIndex == 3)
        {
            //Debug.Log("hej3");
            hitLeft.SetActive(false);
            hitRight.SetActive(true);
            defence.SetActive(false);
            spriteIndex = -1;
        }

        if (spriteIndex == 2)
        {
            //Debug.Log("hej");
            hitLeft.SetActive(false);
            hitRight.SetActive(false);
            defence.SetActive(true);
        }

        if (spriteIndex == 1)
        {
            //Debug.Log("hej2");
            hitLeft.SetActive(true);
            hitRight.SetActive(false);
            defence.SetActive(false);
        }

        if (spriteIndex == 0)
        {
            //Debug.Log("hej");
            hitLeft.SetActive(false);
            hitRight.SetActive(false);
            defence.SetActive(true);
        }


    }
}
