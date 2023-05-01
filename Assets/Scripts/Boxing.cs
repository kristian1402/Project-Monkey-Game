using UnityEngine;
using TMPro;
using UnityEditor;
using System.Collections;
using System.IO;


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
    TMP_Text HowToPlay;
    string touchbutton;
    int index;
    public AudioSource audiosource;
    public AudioClip boxing;
    public AudioClip boxing2;
    KeyCode[] keyCodes;
    GameObject defence;
    GameObject hitLeft;
    GameObject hitRight;
    GameObject menuButton;
    GameObject retryButton;
    GameObject grayOut;
    int spriteIndex = 0;
    int health = 4;
    bool alive = true;
    int score = 0;
    float level;
    bool gameStarted = false;
    bool first = true;
    GameObject textpanel;
    GameObject Hp1;
    GameObject Hp2;
    GameObject Hp3;
    GameObject Hp4;
    public Object MoneyFile;
    StreamReader reader;
    string CSVfilePath;
    string powerups;
    string healthincrease;
    string[] PrData;
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
        HowToPlay = GameObject.Find("HowToPlay").GetComponent<TMP_Text>();

        hitLeft = GameObject.Find("Left");
        hitRight = GameObject.Find("Right");
        defence = GameObject.Find("Main");

        menuButton = GameObject.Find("MenuButton");
        retryButton = GameObject.Find("RetryButton");
        grayOut = GameObject.Find("GrayOut");
        textpanel = GameObject.Find("BackdropText");
        Hp1 = GameObject.Find("Hp1");
        Hp2 = GameObject.Find("Hp2");
        Hp3 = GameObject.Find("Hp3");
        Hp4 = GameObject.Find("Hp4");
        Hp4.SetActive(false);
        grayOut.SetActive(false);
        menuButton.SetActive(false);
        retryButton.SetActive(false);

        //Exhausted.text = "";
        Score.text = score.ToString();
        hitLeft.SetActive(false);
        hitRight.SetActive(false);
        defence.SetActive(true);
        Letter.rectTransform.position = new Vector3(8.5f, 3, 0);

        values = saveData.getData();
        level = float.Parse(values[5]);

        CSVfilePath = AssetDatabase.GetAssetPath(MoneyFile);
        CSVfilePath.Replace("\\", "/");
        
        reader = new StreamReader(CSVfilePath);
        string RawData = reader.ReadLine();

        for (int i = 0; i < RawData.Length; i++) { 
                PrData = RawData.Split(";");
            }
        reader.Close();
        powerups = PrData[0];
        healthincrease = PrData[1];

        if (healthincrease == "true")
        {
            health++;
            Hp4.SetActive(true);
        }
    }

    // Update is called once per frame
IEnumerator MoveText()
{
    while (alive == true && gameStarted == true)
    {
            // Move the text 200 pixels to the left each second
        if (powerups == "true")
        {
            Letter.rectTransform.position -= new Vector3((1+(score/(6))) * Time.deltaTime, 0, 0);
        }
        else
        {
        Letter.rectTransform.position -= new Vector3((1+(score/(3))) * Time.deltaTime, 0, 0);
        }
            
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
        if(gameStarted == false)
        {
            Letter.text = "";
            HowToPlay.text ="Hit the corresponding button as the letter shown.";
            Exhausted.text = "Press any key to start";
        }
        if(Input.anyKey && gameStarted == false)
        {
            gameStarted = true;
            Exhausted.text = "";
            GameObject.Destroy(textpanel);
            HowToPlay.text = "";
        }
        if (gameStarted == true && alive == true)
        {
            if(first == true){
                StartCoroutine(MoveText());
                first = false;
            }
            

            MainLoop();
            
        }
    
    }
void MainLoop()
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
                    audiosource.PlayOneShot(boxing, 0.5f);
                }
                else
                {
                    audiosource.PlayOneShot(boxing2, 0.5f);
                }
                
                ChangeSprite();

            }
            else
            {
                health--;
            }
        }
        if (health == 3)
        {
            GameObject.Destroy(Hp4);
        }
        if (health == 2)
        {
            GameObject.Destroy(Hp1);
        }
        if (health == 1)
        {
            GameObject.Destroy(Hp2);
        }

        if (health < 1)
        {
            GameObject.Destroy(Hp3);
            Exhausted.text = "Exhausted";
            alive = false;
            grayOut.SetActive(true);
            menuButton.SetActive(true);
            retryButton.SetActive(true);

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
