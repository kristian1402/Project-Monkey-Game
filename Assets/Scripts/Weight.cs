using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weight : MonoBehaviour
{
    public TMP_Text repCount;
    GameObject winText;
    GameObject repUp;
    GameObject repDown;
    Slider mainSlider;
    float fillTime;
    int reps;
    bool pointAdded = false;

    void Start()
    {
        mainSlider = GameObject.FindObjectOfType<Slider>();
        winText = GameObject.FindGameObjectWithTag("Finish");
        repUp = GameObject.Find("HaramBaeMiliUp");
        repDown = GameObject.Find("HaramBaeMiliDown");
        fillTime += 0.9f * Time.deltaTime;
        winText.SetActive(false);
        repDown.SetActive(true);
        repUp.SetActive(false);
    }

    void Game(float Strength, float MaxVal)
    {
        repCount.text = reps.ToString();
        mainSlider.value = Mathf.SmoothStep(mainSlider.value, 0, fillTime);
        if (reps <= 20)
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
        if (reps == 20)
        {
            winText.SetActive(true);
        }
    }
}
