using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBuyStats : MonoBehaviour
{
    public bool creatine;
    public bool protein;
    public bool steroids;

    MainApeData mainApeData;

    void Start()
    {
        mainApeData = FindObjectOfType<MainApeData>();
    }

    public void OnPurchase()
    {
        if (creatine)
        {
            mainApeData.creatine = true;
            Debug.Log(creatine);
            Debug.Log(mainApeData.creatine);
        }
        else if (protein)
        {
            mainApeData.proteine = true;
        }
        else if (steroids)
        {
            mainApeData.steroids = true;
        }
    }
}