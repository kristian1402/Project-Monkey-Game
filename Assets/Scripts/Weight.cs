using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weight : MonoBehaviour
{
    public TMP_Text repCount;
    GameObject repUp;
    GameObject repDown;
    Slider mainSlider;
    float fillTime;
    int reps;
    bool pointAdded = false;

    void Start()
    {
        mainSlider = GameObject.FindObjectOfType<Slider>();
        repUp = GameObject.Find("HaramBaeMiliUp");
        repDown = GameObject.Find("HaramBaeMiliDown");
        fillTime += 0.9f * Time.deltaTime;
        repDown.SetActive(true);
        repUp.SetActive(false);
    }

    void Update()
    {
        repCount.text = reps.ToString();
        mainSlider.value = Mathf.SmoothStep(mainSlider.value, 0, fillTime);

        if (Input.GetKeyUp("space"))
        {
            mainSlider.value += 0.35f;
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

}
