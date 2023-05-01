using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class ResetCSV : MonoBehaviour
{
    // Start is called before the first frame update
    string filename = "";
    bool headerLine = true;
    void Start()
    {
        filename = Application.dataPath + "/Savefile/Savefile.csv";
        WriteCSV();
    }

        public void WriteCSV()
        {
        
        TextWriter tw = new StreamWriter(filename, true);

        if (headerLine == true)
        {
            tw.WriteLine("creatine, protein, steroids, Strength, Stamina, Level"); //Add to this list if we want to add more predetermined things
            tw.WriteLine("false" + ";" + "false" + ";" + "false"+ ";" + "1" + ";" + "1" + ";" +"1");
            tw.Close();
            tw = new StreamWriter(filename, true);
            headerLine = false;
        }
        
    }
}
