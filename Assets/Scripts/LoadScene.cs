using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public Text text;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());//����Э��
    }

    IEnumerator LoadLevel()
    {
        loadScreen.SetActive(true);//���Լ��س���
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        operation.allowSceneActivation = false;//���������Զ���ת
        while (!operation.isDone)//��������û�����ʱ
        {
            slider.value = operation.progress;//slider��ֵ=���صĽ���ֵ
            text.text = operation.progress * 100 + "%";

            if (operation.progress >= 0.9F)
            {
                slider.value = 1.0f;
                text.text = "100%";
                operation.allowSceneActivation = true;//�������Զ���ת
            }

            yield return null;//����Э��
        }
    }
}