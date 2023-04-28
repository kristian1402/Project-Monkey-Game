using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveDataReader : MonoBehaviour
{
    public Object CSVFile;
    string filePath;
    StreamReader reader;
    StreamWriter writer;
    string RawData;
    public string[] PrData;
    void Start()
    {
        string CSVfilePath = AssetDatabase.GetAssetPath(CSVFile);
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

    public void updateSaveData(bool creatine, bool protein, bool steroids, float Strength, float stamina, float Level, int money)
    {
        writer = new StreamWriter(filePath);
        writer.WriteLine("creatine, protein, steroids, Strength, Stamina, Level, money");
        if (creatine == true)
        {
            writer.WriteLine("true;false;false;" + Strength + ";" + stamina + ";" + Level + ";" + money);
        }
        else if (protein == true)
        {
            writer.WriteLine("false;true;false;" + Strength + ";" + stamina + ";" + Level+ ";" + money);
        }
        else if (steroids == true)
        {
            writer.WriteLine("false;false;true;" + Strength + ";" + stamina + ";" + Level+ ";" + money);
        }
        else
        {
            writer.WriteLine("false;false;false;" + Strength + ";" + stamina + ";" + Level+ ";" + money);
        }
        writer.Close();
    }
}
