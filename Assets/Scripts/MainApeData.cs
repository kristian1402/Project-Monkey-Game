using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainApeData : MonoBehaviour
{
    public bool creatine = false;
    public bool proteine = false;
    public bool steroids = false;
    int level = 1;
    float PushStrength = 0.35f;
    float pullStrength = 0.75f;
    float stamina = 0.9f;
    string filename = "";
    bool written = false;

    void Update()
    {
        WriteCSV();
    }

    void WriteCSV()
    {
        if (written)
        {
            File.Delete(Application.dataPath + "/Savefile/Savefile.csv");
        }
        filename = Application.dataPath + "/Savefile/Savefile.csv";
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("creatine, protein, steroids, pushStrength, pullStrength, Stamina, Level");
        tw.WriteLine(creatine + ";" + proteine + ";" + steroids + ";" + PushStrength + ";" + pullStrength + ";" + stamina + ";" + level);
        tw.Close();
        written = true;
    }

    public void SetCreatineTrue()
    {
        creatine = true;
    }

    public void SetProteineTrue()
    {
        proteine = true;
    }

    public void SetSteroidsTrue()
    {
        steroids = true;
    }
}
