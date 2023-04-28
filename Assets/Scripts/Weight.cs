using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weight : MonoBehaviour
{
    SaveDataReader saveData;
    string[] values;
    public TMP_Text repCount;
    GameObject winText;
    GameObject repUp;
    GameObject repDown;
    Slider mainSlider;
    float fillTime;
    float PushStrength;
    float fallTime;
    float stamina;
    int reps;
    bool pointAdded = false;
    bool fillTimeSet = false;

    void Start()
    {
        saveData = GameObject.FindObjectOfType<SaveDataReader>();
        mainSlider = GameObject.FindObjectOfType<Slider>();
        winText = GameObject.FindGameObjectWithTag("Finish");
        repUp = GameObject.Find("HaramBaeMiliUp");
        repDown = GameObject.Find("HaramBaeMiliDown");

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
        Gameplay(PushStrength, 0.75f, stamina);
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

            if (mainSlider.value >= 0.75f)
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
            winText.SetActive(true);
        }
    }

    void EndState()
    {
        //Add gained values to monkey
    }
}
