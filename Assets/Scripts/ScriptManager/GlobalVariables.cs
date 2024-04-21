using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables instance;

    public float globalVolume = 1.0f; //全局音量
    public float audioVolume = 1.0f; //音效音量
    public float BGMVolume = 1.0f; //BGM音量
    public float voiceVolume = 1.0f; //语音音量
    public bool volumeChanged = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Init()
    {
        if (PlayerPrefs.HasKey("globalVolume"))
        {
            globalVolume = PlayerPrefs.GetFloat("globalVolume");
        }
        else
        {
            globalVolume = 1.0f;
        }
        if (PlayerPrefs.HasKey("audioVolume"))
        {
            audioVolume = PlayerPrefs.GetFloat("audioVolume");
        }
        else
        {
            audioVolume = 1.0f;
        }
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            BGMVolume = PlayerPrefs.GetFloat("BGMVolume");
        }
        else
        {
            BGMVolume = 1.0f;
        }
        if (PlayerPrefs.HasKey("voiceVolume"))
        {
            voiceVolume = PlayerPrefs.GetFloat("voiceVolume");
        }
        else
        {
            voiceVolume = 1.0f;
        }
    }

    public void Set_globalVolume(float volume)
    {
        globalVolume = volume;
        volumeChanged = true;
        PlayerPrefs.SetFloat("globalVolume", volume);
        PlayerPrefs.Save();
    }

    public void Set_audioVolume(float volume)
    {
        audioVolume = volume;
        volumeChanged = true;
        PlayerPrefs.SetFloat("audioVolume", volume);
        PlayerPrefs.Save();
    }

    public void Set_BGMVolume(float volume)
    {
        BGMVolume = volume;
        volumeChanged = true;
        PlayerPrefs.SetFloat("BGMVolume", volume);
        PlayerPrefs.Save();
    }

    public void Set_voiceVolume(float volume)
    {
        voiceVolume = volume;
        volumeChanged = true;
        PlayerPrefs.SetFloat("voiceVolume", volume);
        PlayerPrefs.Save();
    }
}
