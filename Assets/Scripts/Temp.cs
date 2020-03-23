using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Temp : MonoBehaviour
{
    // Start is called before the first frame update
    private int FileCount = 0;
    void Start()
    {

    }

    public void addRecord()
    {
        FileCount++;

        DataSource obj = DataSource.getSingletonInstance();

        string fileName = Application.dataPath + "/file-" + DateTime.Now.ToString("HH-mm-ss-MM-dd-yyyy") + ".csv";

        File.AppendAllText(fileName, "ID,Health,Type\n");

        int count = 1;
        while (count <= obj.getNumberOfDoves() + obj.getNumberOfHawks()){
            int ID = count;
            int Health = obj.getHealth();
            string Type = "Dove";
            if (!Type.Equals("Hawk") && (count > obj.getNumberOfDoves()))
                Type = "Hawk";
            File.AppendAllText(fileName, ID.ToString() + "," + Health.ToString() + "," + Type + "\n");
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        FileCount = 0;
    }
}
