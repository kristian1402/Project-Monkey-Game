using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Weight : MonoBehaviour
{
    GameObject menubutton;
    GameObject retrybutton;
    GameObject GreyOut;
    TMP_Text Exhausted;
    TMP_Text scoreText;
    GameObject grayOut;
    int health = 3;
    bool alive = true;
    bool gameStarted = false;
    int score = 5;
    TMP_Text Arrow;
    bool movingLeft = true;
    bool movingRight = false;
    float divisionvalue = 2f;

    IEnumerator MoveText()
    {
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
        retrybutton.SetActive(false);
        menubutton.SetActive(false);
        GreyOut.SetActive(false);

        Arrow = GameObject.Find("Arrow").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
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
            if (health < 1)
            {
                alive = false;
                retrybutton.SetActive(true);
                menubutton.SetActive(true);
                GreyOut.SetActive(true);
            }
        }
    }
}