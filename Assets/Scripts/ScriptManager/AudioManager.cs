using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    // 音效最大数量
    private const int AUDIO_CHANNEL_NUM = 6;
    // 角色语音最大数量
    private const int Voice_CHANNEL_NUM = 2;

    public AudioClip testbgm;

    private struct CHANNEL
    {
        public AudioSource channel;
        public float keyOnTime; //记录最近一次播放的时刻
    };

    private CHANNEL[] a_channels;
    private CHANNEL b_channels;
    private CHANNEL[] v_channels;
    void Awake()
    {
        a_channels = new CHANNEL[AUDIO_CHANNEL_NUM];
        b_channels = new CHANNEL();
        v_channels = new CHANNEL[Voice_CHANNEL_NUM];

        for (int i = 0; i < AUDIO_CHANNEL_NUM; i++)
        {
            //每个频道对应一个音源
            a_channels[i].channel = gameObject.AddComponent<AudioSource>();
            a_channels[i].keyOnTime = 0;
        }

        b_channels.channel = gameObject.AddComponent<AudioSource>();
        b_channels.keyOnTime = 0;

        for (int i = 0; i < Voice_CHANNEL_NUM; i++)
        {
            //每个频道对应一个音源
            v_channels[i].channel = gameObject.AddComponent<AudioSource>();
            v_channels[i].keyOnTime = 0;
        }
    }

    void Start()
    {
        SetBGM(testbgm, 0);
    }

    void Update()
    {
        if (GlobalVariables.instance.volumeChanged)
        {
            SetVolume();
            GlobalVariables.instance.volumeChanged = false;
        }
    }

    //播放一次，参数为音频片段、左右声道、速度
    //用于音效
    //考虑了音效顶替的逻辑
    public int PlayOneShot(AudioClip clip, float pan, float pitch = 1.0f)
    {
        for (int i = 0; i < a_channels.Length; i++)
        {
            //如果正在播放同一个片段，而且刚刚才开始，则直接退出函数
            if (a_channels[i].channel.isPlaying &&
                 a_channels[i].channel.clip == clip &&
                 a_channels[i].keyOnTime >= Time.time - 0.03f)
                return -1;
        }
        //遍历所有频道，如果有频道空闲直接播放新音频，并退出
        //如果没有空闲频道，先找到最开始播放的频道（oldest），稍后使用
        int oldest = -1;
        float time = 10000000.0f;
        for (int i = 0; i < a_channels.Length; i++)
        {
            if (a_channels[i].channel.loop == false &&
               a_channels[i].channel.isPlaying &&
               a_channels[i].keyOnTime < time)
            {
                oldest = i;
                time = a_channels[i].keyOnTime;
            }
            if (!a_channels[i].channel.isPlaying)
            {
                a_channels[i].channel.clip = clip;
                a_channels[i].channel.volume = GlobalVariables.instance.globalVolume *
                                                       GlobalVariables.instance.audioVolume;
                a_channels[i].channel.pitch = pitch;
                a_channels[i].channel.panStereo = pan;
                a_channels[i].channel.loop = false;
                a_channels[i].channel.Play();
                a_channels[i].keyOnTime = Time.time;
                return i;
            }
        }
        //运行到这里说明没有空闲频道。让新的音频顶替最早播出的音频
        if (oldest >= 0)
        {
            a_channels[oldest].channel.clip = clip;
            a_channels[oldest].channel.volume = GlobalVariables.instance.globalVolume *
                                                        GlobalVariables.instance.audioVolume;
            a_channels[oldest].channel.pitch = pitch;
            a_channels[oldest].channel.panStereo = pan;
            a_channels[oldest].channel.loop = false;
            a_channels[oldest].channel.Play();
            a_channels[oldest].keyOnTime = Time.time;
            return oldest;
        }
        return -1;
    }

    //循环播放，参数为音频片段、左右声道、速度
    //未考虑音效顶替
    public int PlayLoop(AudioClip clip, float pan, float pitch = 1.0f)
    {
        for (int i = 0; i < a_channels.Length; i++)
        {
            if (!a_channels[i].channel.isPlaying)
            {
               a_channels[i].channel.clip = clip;
               a_channels[i].channel.volume = GlobalVariables.instance.globalVolume *
                                                      GlobalVariables.instance.audioVolume;
               a_channels[i].channel.pitch = pitch;
               a_channels[i].channel.panStereo = pan;
               a_channels[i].channel.loop = true;
               a_channels[i].channel.Play();
               a_channels[i].keyOnTime = Time.time;
                return i;
            }
        }
        return -1;
    }

    //替换BGM
    public void SetBGM(AudioClip clip, float pan, float pitch = 1.0f)
    {
        b_channels.channel.clip = clip;
        b_channels.channel.volume = GlobalVariables.instance.globalVolume *
                                                      GlobalVariables.instance.BGMVolume;
        b_channels.channel.panStereo = pan;
        b_channels.channel.pitch = pitch;
        b_channels.channel.loop = true;
        b_channels.channel.Play();
        b_channels.keyOnTime = Time.time;
    }

    //设置角色语音
    public void SetVoice(AudioClip clip, float pan, int id = 0,float pitch = 1.0f)
    {
        v_channels[id].channel.clip = clip;
        v_channels[id].channel.volume = GlobalVariables.instance.globalVolume *
                                                      GlobalVariables.instance.voiceVolume;
        v_channels[id].channel.panStereo = pan;
        v_channels[id].channel.pitch = pitch;
        v_channels[id].channel.loop = false;
        v_channels[id].channel.Play();
        v_channels[id].keyOnTime = Time.time;
    }

    //设置全局音量
    public void SetVolume()
    {
        for (int i = 0; i < a_channels.Length; i++)
        {
            a_channels[i].channel.volume = GlobalVariables.instance.globalVolume *
                                                    GlobalVariables.instance.audioVolume;
        }
        
        b_channels.channel.volume = GlobalVariables.instance.globalVolume *
                                            GlobalVariables.instance.BGMVolume;
        for (int i = 0; i < v_channels.Length; i++)
        {
            v_channels[i].channel.volume = GlobalVariables.instance.globalVolume *
                                                    GlobalVariables.instance.voiceVolume;
        }
    }

    //停止所有音频
    public void StopAll()
    {
        foreach (CHANNEL channel in a_channels)
            channel.channel.Stop();
        b_channels.channel.Stop();
        foreach (CHANNEL channel in v_channels)
            channel.channel.Stop();
    }

    //根据频道ID停止音频
    public void Stop(string tag,int id = 0)
    {
        if (tag == "audio")
        {
            if (id >= 0 && id < a_channels.Length)
            {
                a_channels[id].channel.Stop();
            }
        }
        else if (tag == "bgm")
        {
            
            b_channels.channel.Stop();
        }
        else if (tag == "voice")
        {
            if (id >= 0 && id < v_channels.Length)
            {
                v_channels[id].channel.Stop();
            }
        }
        else return;
    }

    //停止所有角色语音
    public void StopVoice()
    {
        foreach (CHANNEL channel in v_channels)
            channel.channel.Stop();
    }
}