using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Linq;
using UnityEngine;

public class CsvFileWrite
{
    public List<string[]> rowData = new List<string[]>();

    public void ReadCsv()
    {
        string filePath = Application.dataPath + "/Logfile.csv";

        if (File.Exists(filePath))
        {
            string value = "";
            StreamReader reader = new StreamReader(filePath, Encoding.UTF8);
            value = reader.ReadToEnd();
            reader.Close();

            string[] lines = value.Split(new char[] { '\n' });

            for (int i = 1; i < lines.Length; i++)
            {
                string re = lines[i].Replace("\r", "");
                if (re != "" && re != "\r")
                {
                    string[] row = re.Split(',');
                    rowData.Add(row);
                }
            }
        }
    }

    public void WriteCsv(string[] row)
    {
        rowData.Add(row);
        string file = "";
        for (int i = 0; i < rowData.Count; i++)
        {
            file += rowData[i][0];
            if (rowData[i].Length > 1)
            {
                for (int r = 1; r < rowData[i].Length; r++)
                {
                    file += ',' + rowData[i][r];
                }
            }
            file += "\r\n";
        }

        string filePath = Application.dataPath + "/Logfile.csv";
        Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        StreamWriter outStream = new StreamWriter(fileStream, Encoding.UTF8);
        outStream.WriteLine(file);
        outStream.Close();
    }
}
