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
        StartCoroutine(LoadLevel());//开启协程
    }

    IEnumerator LoadLevel()
    {
        loadScreen.SetActive(true);//可以加载场景
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        operation.allowSceneActivation = false;//不允许场景自动跳转
        while (!operation.isDone)//场景加载没有完成时
        {
            slider.value = operation.progress;//slider的值=加载的进度值
            text.text = operation.progress * 100 + "%";

            if (operation.progress >= 0.9F)
            {
                slider.value = 1.0f;
                text.text = "100%";
                operation.allowSceneActivation = true;//允许场景自动跳转
            }

            yield return null;//跳出协程
        }
    }
}