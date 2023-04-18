using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainApeData : MonoBehaviour
{
        bool creatine = false;
        bool proteine = false;
        bool steroids = false;
        int level = 1;
        float PushStrength = 1;
        float pullStrength = 1;
        float stamina = 1;
        string filename = "";

    void Awake()
    {
        filename = Application.dataPath + "/Savefile/Savefile.csv";
    }
    void Update(){
        WriteCSV();
    }

    bool headerLine = true;
    bool first = true;
    public void WriteCSV()
    {
        TextWriter tw = new StreamWriter(filename, true);

        if (headerLine == true)
        {
            
            tw.WriteLine("creatine, protein, steroids, pushStrength, pullStrength, Stamina, Level"); //Add to this list if we want to add more predetermined things
            tw.Close();
            tw = new StreamWriter(filename, true);
            headerLine = false;
        }
        if (first)
        {
            tw.WriteLine(creatine + ";" + proteine + ";" + steroids + ";" + PushStrength + ";" + pullStrength + ";" + stamina + ":" + level); //Add to this list if we want to add more predetermined things
            tw.Close(); 
            first = false;  
        }
        if (first == false)
        {
            
        }
    }
}
