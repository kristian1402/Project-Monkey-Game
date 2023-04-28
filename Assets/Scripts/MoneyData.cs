using UnityEngine;
using UnityEditor;
using System.IO;

public class MoneyData : MonoBehaviour
{
    bool creatine = false;
    bool proteine = false;
    bool steroids = false;
    int money;
    string CSVfilePath;
    string[] PrData;
    public Object MoneyFile;
    StreamReader reader;
    StreamWriter writer;

    void Start()
    {
        CSVfilePath = AssetDatabase.GetAssetPath(MoneyFile);
        CSVfilePath.Replace("\\", "/");
    }

    public void updateMoney(int increase)
    {
        reader = new StreamReader(CSVfilePath);
        string RawData = reader.ReadLine();

        for (int i = 0; i < RawData.Length; i++) { 
            PrData = RawData.Split(";");
        }
        reader.Close();
        money = int.Parse(PrData[3]);
        int newMoney = money + increase;

        writer = new StreamWriter(CSVfilePath);
        writer.WriteLine("false;false;false;"+newMoney);
        writer.Close();
        Debug.Log("Money updated");
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

    public int getMoney() //Skud ud Yung Gravy
    {
        reader = new StreamReader(CSVfilePath); 
        string RawData = reader.ReadLine();

        for (int i = 0; i < RawData.Length; i++) { 
            PrData = RawData.Split(";");
        }
        reader.Close();

        return int.Parse(PrData[3]);
    }
}
