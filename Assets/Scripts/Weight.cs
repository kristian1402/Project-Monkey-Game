using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.IO;
using UnityEditor;

public class Weight : MonoBehaviour
{
    GameObject menubutton;
    GameObject retrybutton;
    GameObject GreyOut;
    TMP_Text Exhausted;
    TMP_Text scoreText;
    GameObject grayOut;
    GameObject Up;
    GameObject Down;
    GameObject Hp1;
    GameObject Hp2;
    GameObject Hp3;
    GameObject Hp4;

    int health = 3;
    bool alive = true;
    bool gameStarted = false;
    int score = 5;
    TMP_Text Arrow;
    bool movingLeft = true;
    bool movingRight = false;
    float divisionvalue = 2f;

    public Object MoneyFile;
    StreamReader reader;
    string CSVfilePath;
    string powerups;
    string healthincrease;
    string[] PrData;

    IEnumerator MoveText()
    {
        if (powerups == "true")
        {
            divisionvalue = 4f;
        }
        while (alive == true)
        {

            while (movingLeft == true)
            {
                Arrow.rectTransform.position -= new Vector3((1+(score/divisionvalue)) * Time.deltaTime, 0, 0);
                if (Arrow.rectTransform.position.x < (-5))
                {
                    movingLeft = false;
                    movingRight = true;
                }
                yield return null;
            }
            while (movingRight == true)
            {
                Arrow.rectTransform.position += new Vector3((1+(score/divisionvalue)) * Time.deltaTime, 0, 0);
                if (Arrow.rectTransform.position.x > (5))
                {
                    movingLeft = true;
                    movingRight = false;
                }
                yield return null;
            }
        }
    }
    void Start()
    {
        //Find and disable buttons 
        menubutton = GameObject.Find("MenuButton");
        retrybutton = GameObject.Find("RetryButton");
        GreyOut = GameObject.Find("GrayOut");
        Hp1 = GameObject.Find("Hp1");
        Hp2 = GameObject.Find("Hp2");
        Hp3 = GameObject.Find("Hp3");
        Hp4 = GameObject.Find("Hp4");
        retrybutton.SetActive(false);
        menubutton.SetActive(false);
        GreyOut.SetActive(false);
        Hp4.SetActive(false);

        Arrow = GameObject.Find("Arrow").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        
        Up = GameObject.Find("Up");
        Up.SetActive(false);
        Down = GameObject.Find("Down");




        CSVfilePath = Application.dataPath + "/Savefile/moneyFile.csv";
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
        StartCoroutine(MoveText());
        
    }

    void Update()
    {
        if (alive == true)
        {
            mainLoop();
        }
    }
    void mainLoop(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Arrow.rectTransform.position.x < 0.5f && Arrow.rectTransform.position.x > -0.5f)
            {
                score++;  
                scoreText.text = (score-5).ToString();
                
                if (Down.activeSelf == true)
                {
                    Down.SetActive(false);
                    Up.SetActive(true);
                }
                
                else
                {
                    Down.SetActive(true);
                    Up.SetActive(false);
                }
                
                

                if (movingLeft == true)
                {   
                    Arrow.rectTransform.position += new Vector3(-5, 0, 0);
                }
                if (movingRight == true)
                {   
                    Arrow.rectTransform.position += new Vector3(5, 0, 0);
                }
            }
            else
            {
                health--;
            }
            if (health == 3)
            {
                GameObject.Destroy(Hp4);
            }
            if (health == 2)
            {
                GameObject.Destroy(Hp3);
            }
            if (health == 1)
            {
                GameObject.Destroy(Hp2);
            }
            if (health < 1)
            {
                alive = false;
                retrybutton.SetActive(true);
                menubutton.SetActive(true);
                GreyOut.SetActive(true);
                GameObject.Destroy(Hp1);
            }
        }
    }
}