using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveDataReader : MonoBehaviour
{
    public Object SaveFile;
    string filePath;
    StreamReader reader;
    StreamWriter writer;
    string RawData;
    string[] PrData;
    void Start()
    {
        string CSVfilePath = Application.dataPath + "/Savefile/Savefile.csv";
        CSVfilePath.Replace("\\", "/");
        filePath = CSVfilePath; 
        reader = new StreamReader(CSVfilePath); 

        reader.ReadLine();
        RawData = reader.ReadLine();

        for (int i = 0; i < RawData.Length; i++) { 
            PrData = RawData.Split(";");
        }

        reader.Close();
    }

    public string[] getData()
    {
        return PrData;
    }

    public void updateSaveData(bool creatine, bool protein, bool steroids, float Strength, float stamina, float Level)
    {
        writer = new StreamWriter(filePath);
        writer.WriteLine("creatine, protein, steroids, Strength, Stamina, Level");
        if (creatine == true)
        {
            writer.WriteLine("true;false;false;" + Strength + ";" + stamina + ";" + Level);
        }
        else if (protein == true)
        {
            writer.WriteLine("false;true;false;" + Strength + ";" + stamina + ";" + Level);
        }
        else if (steroids == true)
        {
            writer.WriteLine("false;false;true;" + Strength + ";" + stamina + ";" + Level);
        }
        else
        {
            writer.WriteLine("false;false;false;" + Strength + ";" + stamina + ";" + Level);
        }
        writer.Close();
    }
}
