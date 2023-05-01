using UnityEngine;
using System.IO;

public class DataCreator : MonoBehaviour
{
    string SaveFilePath;
    StreamWriter writer;
    void Start()
    {
        SaveFilePath = Application.dataPath + "/Resources/Savefile";
        Directory.CreateDirectory(SaveFilePath);
        SaveFilePath.Replace("\\", "/");
        string MoneyFile = SaveFilePath + "/moneyFile.csv"; 
        string saveFile = SaveFilePath + "/saveFile.csv";

        if (!File.Exists(MoneyFile))
        {
            File.CreateText(MoneyFile).Close();
            writer = new StreamWriter(MoneyFile);
            writer.WriteLine("false;false;false;0");
            writer.Close();
        }

        if (!File.Exists(saveFile))
        {
            File.CreateText(saveFile).Close();
            writer = new StreamWriter(saveFile);
            writer.WriteLine("creatine, protein, steroids, Strength, Stamina, Level");
            writer.WriteLine("false;false;false;1;1;1");
            writer.Close();
        }
    }
}
