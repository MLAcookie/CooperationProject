using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resourses: MonoBehaviour
{
    public static Resourses instance;
    //����ƴд����
    private List<int> edges = new List<int>();
    private List<float> pai = new List<float>();


    private Dictionary<int, int> cutCircleDic = new Dictionary<int, int>();
    private Dictionary<int, float> paiDic = new Dictionary<int, float>();

    void Awake() {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        pai.Add(1.299038f);
        pai.Add(2.598076f);
        pai.Add(3.105828f);
        pai.Add(3.132628f);
        pai.Add(3.139350f);
        pai.Add(3.141031f);
        pai.Add(3.141452f);
        pai.Add(3.141557f);
        pai.Add(3.141583f);
        pai.Add(3.141590f);
        pai.Add(3.141592f);

        for (int i = 0; i < 11; i++)
        {
            edges.Add((int)(3 * Mathf.Pow(2f, i)));
        }

        if (edges.Count != pai.Count)
        {
            Debug.Log("�������ݴ���");
        }
        else
        {
            for (int i = 0; i < 11; i++)
            {
                //Debug.Log(i + "�ִ�" + edges[i] + "��" + pai[i] + "����");
                cutCircleDic.Add(i + 1, edges[i]);
                paiDic.Add(i + 1, pai[i]);
            }
        }

        //�洢��Բ�ı�����ÿ�ζ�Ӧ��ֵ
    }


    public int serEdge(int dl)
    {
        int temp;
        cutCircleDic.TryGetValue(dl,out temp);
        return temp;
    }

    public float serPai(int dl)
    {
        float temp;
        paiDic.TryGetValue(dl, out temp);
        return temp;
    }

}
