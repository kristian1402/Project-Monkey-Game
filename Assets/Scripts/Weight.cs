using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weight : MonoBehaviour
{
    SaveDataReader saveData;
    string[] values;
    public TMP_Text repCount;
    GameObject winText;
    GameObject exhausted;
    GameObject repUp;
    GameObject repDown;
    Slider mainSlider;

    GameObject grayOut;
    GameObject menuButton;
    GameObject retryButton;
    float fillTime;
    float PushStrength;
    float fallTime;
    float stamina;
    int reps;
    public float strength;
    public float maxValue;
    public float FallTime;
    bool pointAdded = false;
    bool fillTimeSet = false;

    void Start()
    {
        saveData = GameObject.FindObjectOfType<SaveDataReader>();
        mainSlider = GameObject.FindObjectOfType<Slider>();
        winText = GameObject.FindGameObjectWithTag("Finish");
        exhausted = GameObject.Find("Exhausted");
        repUp = GameObject.Find("HaramBaeMiliUp");
        repDown = GameObject.Find("HaramBaeMiliDown");

        menuButton = GameObject.Find("MenuButton");
        retryButton = GameObject.Find("RetryButton");
        grayOut = GameObject.Find("GrayOut");
        grayOut.SetActive(false);
        menuButton.SetActive(false);
        retryButton.SetActive(false);

        exhausted.SetActive(false);
        winText.SetActive(false);
        repDown.SetActive(true);
        repUp.SetActive(false);

        values = saveData.getData();

        PushStrength = float.Parse(values[3]);
        fallTime = float.Parse(values[4]);
        stamina = float.Parse(values[5]);
    }

    void Update()
    {
        Gameplay(strength, maxValue, fallTime);
        fillTimeSet = true;
    }

    public void Gameplay(float Strength, float MaxVal, float fallTime)
    {
        if (!fillTimeSet)
        {
            fillTime += fallTime * Time.deltaTime;   
        }
        repCount.text = reps.ToString();
        mainSlider.value = Mathf.SmoothStep(mainSlider.value, 0, fillTime);
        if (reps < 20)
        {
            if (Input.GetKeyUp("space"))
            {
                mainSlider.value += Strength;
            }  

            if (mainSlider.value >= MaxVal)
            {
                repDown.SetActive(false);
                repUp.SetActive(true);
                if (!pointAdded)
                {
                    reps++;
                    pointAdded= true;
                }
            }
            else
            {
                pointAdded = false;
                repDown.SetActive(true);
                repUp.SetActive(false);
            }
        }
        if (reps > 19)
        {
            exhausted.SetActive(true);
            winText.SetActive(true);
            grayOut.SetActive(true);
            menuButton.SetActive(true);
            retryButton.SetActive(true);
        }
    }

    void EndState()
    {
        //Add gained values to monkey
    }
}
