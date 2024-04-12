using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    // ��Ч�������
    private const int AUDIO_CHANNEL_NUM = 6;
    // ��ɫ�����������
    private const int Voice_CHANNEL_NUM = 2;

    public AudioClip testbgm;

    private struct CHANNEL
    {
        public AudioSource channel;
        public float keyOnTime; //��¼���һ�β��ŵ�ʱ��
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
            //ÿ��Ƶ����Ӧһ����Դ
            a_channels[i].channel = gameObject.AddComponent<AudioSource>();
            a_channels[i].keyOnTime = 0;
        }

        b_channels.channel = gameObject.AddComponent<AudioSource>();
        b_channels.keyOnTime = 0;

        for (int i = 0; i < Voice_CHANNEL_NUM; i++)
        {
            //ÿ��Ƶ����Ӧһ����Դ
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

    //����һ�Σ�����Ϊ��ƵƬ�Ρ������������ٶ�
    //������Ч
    //��������Ч������߼�
    public int PlayOneShot(AudioClip clip, float pan, float pitch = 1.0f)
    {
        for (int i = 0; i < a_channels.Length; i++)
        {
            //������ڲ���ͬһ��Ƭ�Σ����Ҹողſ�ʼ����ֱ���˳�����
            if (a_channels[i].channel.isPlaying &&
                 a_channels[i].channel.clip == clip &&
                 a_channels[i].keyOnTime >= Time.time - 0.03f)
                return -1;
        }
        //��������Ƶ���������Ƶ������ֱ�Ӳ�������Ƶ�����˳�
        //���û�п���Ƶ�������ҵ��ʼ���ŵ�Ƶ����oldest�����Ժ�ʹ��
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
        //���е�����˵��û�п���Ƶ�������µ���Ƶ�������粥������Ƶ
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

    //ѭ�����ţ�����Ϊ��ƵƬ�Ρ������������ٶ�
    //δ������Ч����
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

    //�滻BGM
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

    //���ý�ɫ����
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

    //����ȫ������
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

    //ֹͣ������Ƶ
    public void StopAll()
    {
        foreach (CHANNEL channel in a_channels)
            channel.channel.Stop();
        b_channels.channel.Stop();
        foreach (CHANNEL channel in v_channels)
            channel.channel.Stop();
    }

    //����Ƶ��IDֹͣ��Ƶ
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

    //ֹͣ���н�ɫ����
    public void StopVoice()
    {
        foreach (CHANNEL channel in v_channels)
            channel.channel.Stop();
    }
}