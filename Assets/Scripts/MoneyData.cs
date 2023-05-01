using UnityEngine;
using UnityEditor;
using System.IO;

public class MoneyData : MonoBehaviour
{
    bool creatine = false;
    bool proteine = false;
    bool steroids = false;
    bool powerUp1 = false;
    bool powerUp2 = false;
    bool powerUp3 = false;
    bool skinBought1 = false;
    bool skinBought2 = false;
    bool skinBought3 = false;
    int money;
    string CSVfilePath;
    string[] PrData;
    public Object MoneyFile;
    StreamReader reader;
    StreamWriter writer;
    public int supplementCost;
    public GameObject InsufficiantFunds;

    void Start()
    {
        //GameObject canvas = GameObject.Find("Text (TMP)_InsufficientCost");
        CSVfilePath = Application.dataPath + "/Savefile/moneyFile.csv";
        CSVfilePath.Replace("\\", "/");
        DeactivateCanvas(InsufficiantFunds);
    }

    public void updateMoney(int increase)
    {
        reader = new StreamReader(CSVfilePath);
        string RawData = reader.ReadLine();

        for (int i = 0; i < RawData.Length; i++)
        {
            PrData = RawData.Split(";");
        }
        reader.Close();
        money = int.Parse(PrData[3]);
        int newMoney = money + increase;

        writer = new StreamWriter(CSVfilePath);
        writer.WriteLine("false;false;false;" + newMoney);
        writer.Close();
        Debug.Log("Money updated");
    }

    public int getMoney()
    {
        reader = new StreamReader(CSVfilePath);
        string RawData = reader.ReadLine();

        for (int i = 0; i < RawData.Length; i++)
        {
            PrData = RawData.Split(";");
        }
        reader.Close();

        return int.Parse(PrData[3]);
    }

    void ActivateCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    void DeactivateCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    public void InsufficiantCanvasSwitcher() {
        ActivateCanvas(InsufficiantFunds);
        Invoke("DeactivateInsufficiantCanvas", 2f);
    }

    void DeactivateInsufficiantCanvas() {
        DeactivateCanvas(InsufficiantFunds);
    }

    public void BuyCreatine()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
            int currentMoney = getMoney();
            writer = new StreamWriter(CSVfilePath);
            writer.WriteLine("true;false;false;" + currentMoney);
            writer.Close();
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }

    public void BuyProteine()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
                int currentMoney = getMoney();
                writer = new StreamWriter(CSVfilePath);
                writer.WriteLine("false;true;false;" + currentMoney);
                writer.Close();
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }

    public void BuySteroids()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
                int currentMoney = getMoney();
                writer = new StreamWriter(CSVfilePath);
                writer.WriteLine("false;false;true;" + currentMoney);
                writer.Close();
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }

        public void BuyPowerUp1()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
            powerUp1 = true; // Mangler et andet navn
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }

    public void BuyPowerUp2()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
            powerUp2 = true; // Mangler et andet navn
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }

    public void BuyPowerUp3()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
            powerUp3 = true; // Mangler et andet navn
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }

        public void BuySkin1()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
            skinBought1 = true; // Mangler et andet navn
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }

        public void BuySkin2()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
            skinBought2 = true; // Mangler et andet navn
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }

            public void BuySkin3()
    {
        int cost = supplementCost;
        if (getMoney() >= cost)
        {
            updateMoney(-cost);
            skinBought3 = true; // Mangler et andet navn
        }
        else if (getMoney() < cost ) {
            InsufficiantCanvasSwitcher();
        Debug.Log("Not Enough Funds. You have "+ getMoney() + ". It costs " + cost);
        }
    }
}