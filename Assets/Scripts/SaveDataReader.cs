using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveDataReader : MonoBehaviour
{
    public Object CSVFile;
    string filePath;
    StreamReader reader;
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
    }

    public string[] getData()
    {
        return PrData;
    }
}
