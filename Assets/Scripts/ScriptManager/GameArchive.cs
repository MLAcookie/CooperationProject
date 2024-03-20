using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameArchive
{
    //λ��C��User��AppData�У�������鿴
    private static string playDataPath = Application.persistentDataPath + "/Save/SlotList/";
    private static string settingDataPath = Application.persistentDataPath + "/Save/";

    //����ת��ΪJson�洢
    private static void SaveJson(object obj, string path, string fileName)
    {
        StreamWriter sw = null;
        try
        {
            //����תJson
            string jsonStr = JsonUtility.ToJson(obj);
            //�ļ����п�
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            //�����ļ���д��
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

    //��ȡJson�ļ�ת��Ϊ����
    private static T LoadJson<T>(string filePath)
    {
        StreamReader sr = null;
        try
        {
            //�ļ����п�
            if (!File.Exists(filePath))
            {
                Debug.LogWarning("File not exist: " + filePath + " in LoadJson<T>");
                return default(T);
            }
            sr = new StreamReader(new FileStream(filePath, FileMode.Open), Encoding.UTF8);
            string jsonStr = sr.ReadToEnd();
            //��ȡ����Json�ַ�������Ϊ���Ͷ��󷵻�
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

    //ɾ��Json�ļ�
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

    //�������
    //�ɸ��ݴ浵��λ��ͬ���벻ͬfileName
    /*
    public static void SavePlayModel(PlaySave model, string fileName)
    {
        SaveJson(model, playDataPath, fileName);
    }
    //��ȡ��fileName�Ľ��ȴ浵
    public static PlaySave LoadPlayModel(string fileName)
    {
        return LoadJson<PlaySave>(playDataPath + "/" + fileName.Split('.')[0] + ".json");
    }
    //ɾ������
    public static void DeletePlayModel(string fileName)
    {
        DeleteJson(playDataPath + "/" + fileName.Split('.')[0] + ".json");
    }

    //��ȡ���ȴ浵�б��������д浵չʾ
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
    //��ȡ���ȴ浵������
    public static void LoadPlayModelandLoadScene(string fileName)
    {
        PlaySave playSave = LoadPlayModel(fileName);
        RPGManager.instance.CurrentPlaySave = playSave;
        UnityEngine.SceneManagement.SceneManager.LoadScene(playSave.currentScene);
    }
    //����ȫ������
    public static void SaveSettingModel(SettingSave model)
    {
        SaveJson(model, settingDataPath, "Setting.json");
    }
    //��ȡȫ������
    public static void LoadSettingModel()
    {
        GameSetting.SetSettingModel(LoadJson<SettingSave>(settingDataPath + "/Setting.json"));
    }
    */
}
