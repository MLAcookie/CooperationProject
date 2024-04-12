using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameArchive
{
    //位于C盘User的AppData中，可输出查看
    private static string playDataPath = Application.persistentDataPath + "/Save/SlotList/";
    private static string settingDataPath = Application.persistentDataPath + "/Save/";

    //对象转换为Json存储
    private static void SaveJson(object obj, string path, string fileName)
    {
        StreamWriter sw = null;
        try
        {
            //对象转Json
            string jsonStr = JsonUtility.ToJson(obj);
            //文件夹判空
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            //开启文件流写入
            sw = new StreamWriter(
                new FileStream(path + "/" + fileName.Split('.')[0] + ".json", FileMode.Create),
                Encoding.UTF8);
            sw.Write(jsonStr);
            sw.Flush();
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message + "::" + e.StackTrace);
        }
        finally
        {
            sw.Close();
        }
    }

    //读取Json文件转化为对象
    private static T LoadJson<T>(string filePath)
    {
        StreamReader sr = null;
        try
        {
            //文件夹判空
            if (!File.Exists(filePath))
            {
                Debug.LogWarning("File not exist: " + filePath + " in LoadJson<T>");
                return default(T);
            }
            sr = new StreamReader(new FileStream(filePath, FileMode.Open), Encoding.UTF8);
            string jsonStr = sr.ReadToEnd();
            //读取到的Json字符串解析为泛型对象返回
            return JsonUtility.FromJson<T>(jsonStr);
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message + "::" + e.StackTrace);
            return default(T);
        }
        finally
        {
            sr.Close();
        }
    }

    //删除Json文件
    public static void DeleteJson(string filePath)
    {
        try
        {
            File.Delete(filePath);
        }
        catch (Exception e)
        {
            #if UNITY_EDITOR
            Debug.LogError(e.Message + "::" + e.StackTrace);
            #endif
        }
    }

    //保存进度
    //可根据存档槽位不同存入不同fileName
    /*
    public static void SavePlayModel(PlaySave model, string fileName)
    {
        SaveJson(model, playDataPath, fileName);
    }
    //读取该fileName的进度存档
    public static PlaySave LoadPlayModel(string fileName)
    {
        return LoadJson<PlaySave>(playDataPath + "/" + fileName.Split('.')[0] + ".json");
    }
    //删除档案
    public static void DeletePlayModel(string fileName)
    {
        DeleteJson(playDataPath + "/" + fileName.Split('.')[0] + ".json");
    }

    //读取进度存档列表，用以所有存档展示
    public static List<PlaySave> LoadPlayModelList()
    {
        string[] fileList = Directory.GetFiles(playDataPath + "/", "*.json");
        List<PlaySave> res = new List<PlaySave>();
        foreach (string file in fileList)
        {
            res.Add(LoadJson<PlaySave>(file));
        }
        return res;
    }
    //读取进度存档并加载
    public static void LoadPlayModelandLoadScene(string fileName)
    {
        PlaySave playSave = LoadPlayModel(fileName);
        RPGManager.instance.CurrentPlaySave = playSave;
        UnityEngine.SceneManagement.SceneManager.LoadScene(playSave.currentScene);
    }
    //储存全局设置
    public static void SaveSettingModel(SettingSave model)
    {
        SaveJson(model, settingDataPath, "Setting.json");
    }
    //读取全局设置
    public static void LoadSettingModel()
    {
        GameSetting.SetSettingModel(LoadJson<SettingSave>(settingDataPath + "/Setting.json"));
    }
    */
}
