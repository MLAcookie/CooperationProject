using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileHandler : MonoBehaviour
{
    public static FileHandler instance;
    public string Director_Path;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Director_Path = Application.streamingAssetsPath;
    }
    public string[] ReadTxtFile(string filename)
    {
        string Path = Director_Path;
        Path = Director_Path + "/" + filename;
        //Debug.Log("readfile:" + Path);
        string[] AllText = File.ReadAllLines(Path);
        return AllText;
    }
}
