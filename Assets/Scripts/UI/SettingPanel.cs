using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    public static SettingPanel instance;
    public Slider global;
    public Slider audio;
    public Slider bgm;
    public Slider voice;
    void Start()
    {
        instance = this;
        Init();
    }

    void Update()
    {
        GlobalVariables.instance.Set_globalVolume(global.value);
        GlobalVariables.instance.Set_audioVolume(audio.value);
        GlobalVariables.instance.Set_BGMVolume(bgm.value);
        GlobalVariables.instance.Set_voiceVolume(voice.value); 
    }

    public void Init()
    {
        global.value = GlobalVariables.instance.globalVolume;
        audio.value = GlobalVariables.instance.audioVolume;
        bgm.value = GlobalVariables.instance.BGMVolume;
        voice.value = GlobalVariables.instance.voiceVolume;
    }
}
