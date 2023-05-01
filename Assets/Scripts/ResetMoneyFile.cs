using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResetMoneyFile : MonoBehaviour
{
    string filename = "";
    bool headerLine = true;
    void Start()
    {
        File.Delete(Application.dataPath + "/Savefile/moneyFile.csv");
        filename = Application.dataPath + "/Savefile/moneyFile.csv";
        WriteCSV();
    }

        public void WriteCSV()
        {
        
        TextWriter tw = new StreamWriter(filename, true);

        if (headerLine == true)
        {
            tw.WriteLine("false" + ";" + "false" + ";" + "false"+ ";" + "99");
            tw.Close();
            tw = new StreamWriter(filename, true);
            headerLine = false;
        }
    }
}
