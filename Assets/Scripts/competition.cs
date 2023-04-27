using UnityEngine;
using TMPro;

public class competition : MonoBehaviour
{
    SaveDataReader saveData;
    string[] values;
    public TMP_Text countdown;
    public TMP_Text scoreText;
    GameObject winText;
    GameObject haramBaeIdle;
    GameObject haramBaePose;
    GameObject mandrilIdle;
    GameObject mandrilPose;
    float timeRemaining = 5;
    int reps;
    int keypressCount;
    float Strength;
    float stamina;
    float level;
    bool finished = false;
    void Start()
    {
        saveData = GameObject.FindObjectOfType<SaveDataReader>();
        haramBaeIdle = GameObject.Find("HaramBae");
        haramBaePose = GameObject.Find("HaramBaeSwole");
        mandrilIdle = GameObject.Find("MandrilStandard");
        mandrilPose = GameObject.Find("MandrilSwole");

        haramBaePose.SetActive(false);
        mandrilPose.SetActive(false);
        
        values = saveData.getData();
        Strength = float.Parse(values[3]);
        stamina = float.Parse(values[4]);
        level = float.Parse(values[5]);
}

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad < 3)
        {
            countdown.text = "GET READY";
        }
        else
        {
            if (timeRemaining > 0)
            {
                if (Input.GetKeyUp("space"))
                {
                    keypressCount++;
                }
                timeRemaining -= Time.deltaTime;
                
                float timeshortened =  Mathf.Round(timeRemaining* 100f) / 100f;

                countdown.text = timeshortened.ToString();
            }

            if (timeRemaining < 0 && finished == false)
            {
                finisher(keypressCount);
            }
        }
    }

    void finisher(float keypressCount)
    {
        haramBaeIdle.SetActive(false);
        mandrilIdle.SetActive(false);
        haramBaePose.SetActive(true);
        mandrilPose.SetActive(true);

        float scorefloat = ((Strength + stamina + level + keypressCount)/4)*1000;
        int score = Mathf.RoundToInt(scorefloat);
        countdown.text = "FINAL SCORE = " + score.ToString();

        if (score > 9700)
        {
            scoreText.text = "YOU WIN";
        }
        else
        {
            scoreText.text = "YOU LOSE";
        }
        finished = true;
    }
}